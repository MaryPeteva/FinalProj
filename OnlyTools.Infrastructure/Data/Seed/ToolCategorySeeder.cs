using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Infrastructure.Data.Seed
{
    internal class ToolCategorySeeder
    {
        private readonly OnlyToolsDbContext _context;
        public ToolCategorySeeder(OnlyToolsDbContext context)
        {
            _context = context;
        }

        private async void SeedAsync()
        {
            if (!_context.ToolCategories.Any())
            {
                var toolCategories = new List<ToolCategory>() {
                    new ToolCategory()
                   {
                       Id = 1,
                       Name = "Power Tools"
                   },
                   new ToolCategory()
                   {
                       Id = 2,
                       Name = "Hand Tools"
                   },
                   new ToolCategory()
                   {
                       Id = 3,
                       Name = "Gardening Tools"
                   },
                   new ToolCategory()
                   {
                       Id = 4,
                       Name = "Woodworking Tools"
                   },
                   new ToolCategory()
                   {
                       Id = 5,
                       Name = "Measuring Tools"
                   },
                   new ToolCategory()
                   {
                       Id = 6,
                       Name = "Masonry Tool"
                   },
                   new ToolCategory()
                   {
                       Id = 7,
                       Name = "Other Tools"
                   }
                };
            }
        }
    }
}
