using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Category;
using OnlyTools.Core.Models.Tips;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Core.Services
{
    public class TipServices:ITipServices
    {
        private readonly OnlyToolsDbContext context;


        public TipServices(OnlyToolsDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewTipAsync(TipPostModel tip)
        {
            TipCategory cat = await context.TipCategories.FindAsync(tip.CategoryId);
            var newTip = new Tip()
            {
                Title = tip.Title,
                Content = tip.Content,
                AuthorId = tip.AuthorId,
                Author = tip.Author,
                PubllishedOn = DateTime.Now,
                CategoryId = tip.CategoryId,
                Category = cat
            };

            await context.TipsAndTricks.AddAsync(newTip);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTipAsync(int id)
        {
            var tip = await context.TipsAndTricks.FindAsync(id);
            context.Remove(tip);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TipsAllModel>> GetAllTipsAsync()
        {
            return await context.TipsAndTricks
                .Select(t => new TipsAllModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Content = t.Content,
                    AuthorId = t.AuthorId,
                    Author = t.Author,
                    CategoryId = t.CategoryId,
                    Category = new CategoryModel()
                    {
                        Id = t.CategoryId,
                        Name = t.Category.Name
                    }
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TipsDetailedModel> GetSpecificTipByIdAsync(int id)
        {
            var tip = await context.TipsAndTricks.FindAsync(id);
            TipCategory cat = await context.TipCategories.FindAsync(tip.CategoryId);
            TipsDetailedModel Dtip = new TipsDetailedModel() 
            {
                Title = tip.Title,
                Content = tip.Content,
                PublishedOn = tip.PubllishedOn,
                AuthorId= tip.AuthorId,
                Author = tip.Author,
                CategoryId= tip.CategoryId,
                Category = new CategoryModel() {
                    Id = cat.Id,
                    Name = cat.Name
                }
            };

            return Dtip;
        }

        public Task UpdateTipAsync(int id, TipPostModel tip)
        {
            throw new NotImplementedException();
        }
    }
}
