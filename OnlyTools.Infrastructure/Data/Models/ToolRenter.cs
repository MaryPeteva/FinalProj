using Microsoft.AspNetCore.Identity;

namespace OnlyTools.Infrastructure.Data.Models
{
    public class ToolRenter:IdentityUser
    {
        public virtual ICollection<Tool> RentedTools { get; set; } = new List<Tool>();
    }
}