using Microsoft.AspNetCore.Identity;

namespace OnlyTools.Infrastructure.Data.Models
{
    public class ToolOwner : IdentityUser
    {
        public virtual ICollection<Tool> OwnedTools { get; set; } = new List<Tool>();
    }
}
