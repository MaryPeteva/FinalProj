using Microsoft.EntityFrameworkCore;
using OnlyTools.Infrastructure.Data.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.TipsValidationConstants;
namespace OnlyTools.Infrastructure.Data.Models
{
    public class Tip
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(TipTitleMaxLen)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TipContentMaxLen)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; } = null!;

        [Required]
        public DateTime PubllishedOn { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("category, obj representation")]
        public TipCategory Category { get; set; } = null!;

        public ICollection<Like> LikedBy { get; set; } = new List<Like>();
    }
}