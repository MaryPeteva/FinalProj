using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Category;
using OnlyTools.Infrastructure.Data;

namespace OnlyTools.Core.Services
{
    public class CategoriesServices:ICategoriesServices
    {
        private readonly OnlyToolsDbContext context;

        public CategoriesServices(OnlyToolsDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<CategoryModel>> GetToolCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(t => new CategoryModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryModel>> GetTipCategoriesAsync()
        {
            return await context.TipCategories
                .AsNoTracking()
                .Select(t => new CategoryModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
