using Microsoft.AspNetCore.Identity;
using OnlyTools.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlyTools.Infrastructure.Data.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Tool> OwnedTools { get; set; } = null!;
        public ICollection<Tool> RentedTools { get; set; } = null!;
        public ICollection<Like> LikedTips { get; set; } = null!;
    }
}
