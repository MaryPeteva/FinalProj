using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Infrastructure.Data.Seed
{
    internal class TipsCategorySeeder
    {
        private readonly OnlyToolsDbContext _context;
        public TipsCategorySeeder(OnlyToolsDbContext context)
        {
            _context = context;
        }

        private async void SeedAsync() 
        {
            if (!_context.TipCategories.Any()) 
            {
                var tipCategories = new List<TipCategory>() {
                        new TipCategory()
                       {
                           Id = 1,
                           Name = "Kitchen Renovations"
                       },
                       new TipCategory()
                       {
                           Id = 2,
                           Name = "Bathroom Renovations"
                       },
                       new TipCategory()
                       {
                           Id = 3,
                           Name = "Flooring Solutions"
                       },
                       new TipCategory()
                       {
                           Id = 4,
                           Name = "Interior Painting"

                       },
                       new TipCategory()
                       {
                           Id = 5,
                           Name = "Exterior Upgrades"


                       },
                       new TipCategory()
                       {

                           Id = 6,
                           Name = "Plumbing Fixes"
                       },
                       new TipCategory()
                       {

                           Id = 7,
                           Name = "Electrical Repairs"
                       },
                       new TipCategory()
                       {

                           Id = 8,
                           Name = "HVAC Maintenance"
                       },
                       new TipCategory()
                       {

                           Id = 9,
                           Name = "Foundation and Structural Repairs"
                       },
                       new TipCategory()
                       {

                           Id = 10,
                           Name = "DIY Home Improvement"
                       }
                };
            }
        }
    }
}
