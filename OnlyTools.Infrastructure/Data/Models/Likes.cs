using OnlyTools.Infrastructure.Data.IdentityModels;

namespace OnlyTools.Infrastructure.Data.Models
{
    public class Like
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; } = null!;
    }
}
