using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.CategoryValidationConstants;
namespace OnlyTools.Infrastructure.Data.Models
{
    public class ToolCategory
    {
        [Key]
        [Comment("unique integer category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLen)]
        [Comment("Category name, string representation")]
        public string Name { get; set; } = string.Empty;

        [Comment("All the tools with this category")]
        public IList<Tool> Tools { get; set; } = new List<Tool>();
    }
}

