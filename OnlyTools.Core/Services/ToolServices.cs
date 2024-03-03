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

        public async Task AddNewToolAsync(ToolModel tool, string userId)
        {
            var newTool = new Tool() 
            {
                Name = tool.Name,
                Description = tool.Description,
                RentPrice = tool.RentPrice,
                OwnerID = userId,
            };

            await context.Tools.AddAsync(newTool);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToolModel>> GetAllToolsAsync() 
        {
            return await context.Tools
                .Select(t => new ToolModel() 
                {
                    Name = t.Name,
                    Description = t.Description,
                    IsRented = t.IsRented,
                    //Owner = t.Owner,
                    RentPrice = t.RentPrice,
                    ToolPicture = t.ToolPicture
                })
                .Where(t=>t.IsRented == false)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
