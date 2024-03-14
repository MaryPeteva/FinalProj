using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.Models;
namespace OnlyTools.Core.Services
{
    public class ToolServices:IToolServices
    {
        private readonly OnlyToolsDbContext context;

        public ToolServices(OnlyToolsDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewToolAsync(ToolUploadModel tool)
        {
            var newTool = new Tool() 
            {
                Name = tool.Name,
                Description = tool.Description,
                RentPrice = tool.RentPrice,
                OwnerID = tool.OwnerID
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
                    ToolPicture = t.ToolPicture
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ToolDetailsModel> GetSpecificToolById(int id)
        {
            Tool tool = await context.Tools.FindAsync(id);

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
                ToolPicture = tool.ToolPicture
            };

            return toolDetails;
        }

        public async Task UpdateToolAsync(int id, ToolUploadModel tool)
        {
            Tool t = await context.Tools.FindAsync(id);
            t.Name = tool.Name;
            t.Description = tool.Description;
            t.RentPrice = tool.RentPrice;
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
