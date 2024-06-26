﻿using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Category;
using OnlyTools.Core.Models.Tool;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.Models;
namespace OnlyTools.Core.Services
{
    public class ToolServices : IToolServices
    {
        private readonly OnlyToolsDbContext context;

        public ToolServices(OnlyToolsDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewToolAsync(ToolUploadModel tool, Guid userId)
        {
            ToolCategory cat = await context.ToolCategories.FindAsync(tool.CategoryId);
            var user = await context.Users.FindAsync(userId);
            var newTool = new Tool()
            {
                Name = tool.Name,
                Description = tool.Description,
                RentPrice = tool.RentPrice,
                OwnerID = userId,
                Owner = user,
                CategoryId = tool.CategoryId,
                Category = cat
            };

            if (tool.ToolPicture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    try
                    {
                        await tool.ToolPicture.CopyToAsync(memoryStream);
                        newTool.ToolPicture = memoryStream.ToArray();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log it, return an error response)
                        await Console.Out.WriteLineAsync($"Error uploading picture: {ex.Message}");
                        // Rethrow the exception to indicate failure
                    }
                }
            }

            try
            {
                await context.Tools.AddAsync(newTool);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle database-related exceptions (e.g., constraint violations)
                await Console.Out.WriteLineAsync($"Error saving tool to database: {ex.Message}");
                throw; // Rethrow the exception to indicate failure
            }
        }

        public async Task DeleteToolAsync(int id)
        {
            Tool tool = await context.Tools.FindAsync(id);
            if (tool.IsRented) 
            {
                throw new Exception("Cannot remove rented tool!");
            }
            context.Remove(tool);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToolModel>> GetAllToolsAsync()
        {
            return await context.Tools
                .Select(t => new ToolModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    OwnerID = t.OwnerID,
                    RentPrice = t.RentPrice,
                    ToolPicture = t.ToolPicture,
                    Category = new CategoryModel()
                    {
                        Id = t.CategoryId,
                        Name = t.Category.Name
                    },
                    CategoryId = t.CategoryId,
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ToolModel>> GetMyRentedToolsAsync(Guid myId)
        {
            return await context.Tools
               .Where(t => t.RenterID == myId)
               .Select(t => new ToolModel()
               {
                   Id = t.Id,
                   Name = t.Name,
                   OwnerID = t.OwnerID,
                   RentPrice = t.RentPrice,
                   ToolPicture = t.ToolPicture,
                   Category = new CategoryModel()
                   {
                       Id = t.CategoryId,
                       Name = t.Category.Name
                   },
                   CategoryId = t.CategoryId
               })
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<IEnumerable<ToolModel>> GetMyToolsAsync(Guid myId)
        {
            return await context.Tools
                .Where(t => t.OwnerID == myId)
                .Select(t => new ToolModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    OwnerID = t.OwnerID,
                    RentPrice = t.RentPrice,
                    ToolPicture = t.ToolPicture,
                    Category = new CategoryModel()
                    {
                        Id = t.CategoryId,
                        Name = t.Category.Name
                    },
                    CategoryId = t.CategoryId,
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ToolDetailsModel> GetSpecificToolByIdAsync(int id)
        {
            Tool tool = await context.Tools.FindAsync(id);
            ToolCategory cat = await context.ToolCategories.FindAsync(tool.CategoryId);

            if (tool == null)
            {
                return null;
            }

            var toolDetails = new ToolDetailsModel
            {
                Id = tool.Id,
                Name = tool.Name,
                Description = tool.Description,
                OwnerID = tool.OwnerID,
                IsRented = tool.IsRented,
                RentPrice = tool.RentPrice,
                ToolPicture = tool.ToolPicture,
                Category = cat.Name
            };

            return toolDetails;
        }

        public async Task RentToolAsync(int toolId, Guid userId)
        {
            var tool = await context.Tools.FindAsync(toolId);
            tool.IsRented = true;
            tool.RenterID = userId;
            await context.SaveChangesAsync();
        }

        public async Task ReturnToolAsync(int id)
        {
            var tool = await context.Tools.FindAsync(id);
            tool.IsRented = false;
            tool.RenterID = null;
            await context.SaveChangesAsync();
        }

        public async Task UpdateToolAsync(int id, ToolUploadModel tool)
        {
            Tool t = await context.Tools.FindAsync(id);
            ToolCategory cat = await context.ToolCategories.FindAsync(tool.CategoryId);
            t.Name = tool.Name;
            t.Description = tool.Description;
            t.RentPrice = tool.RentPrice;
            t.CategoryId = tool.CategoryId;
            t.Category = cat;
            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await tool.ToolPicture.CopyToAsync(memoryStream);
                    t.ToolPicture = memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it, return an error response)
                    await Console.Out.WriteLineAsync($"Error uploading picture: {ex.Message}");
                    // Rethrow the exception to indicate failure
                }
            }

            await context.SaveChangesAsync();
        }

    }
}
