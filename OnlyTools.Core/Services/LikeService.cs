using OnlyTools.Core.Contracts;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.IdentityModels;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Core.Services
{
    public class LikeService : ILikeServices
    {
        private readonly OnlyToolsDbContext context;

        public LikeService(OnlyToolsDbContext _context)
        {
            context = _context;
        }

        public async Task LikeTipAsync(Guid userId, int tipId)
        {
            ApplicationUser user = await context.Users.FindAsync(userId);
            Tip tip = await context.TipsAndTricks.FindAsync(tipId);
            Like like = new Like()
            {
                UserId = userId,
                User = user,
                TipId = tipId,
                Tip = tip
            };
            tip.LikedBy.Add(like);
            await context.Likes.AddAsync(like);
            await context.SaveChangesAsync();
        }
    }
}
