using OnlyTools.Infrastructure.Data.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.TipsValidationConstants;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Models.Category;

namespace OnlyTools.Core.Models.Tips
{
    public class TipUploadModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(TipTitleMaxLen, MinimumLength = TipTitleMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TipContentMaxLen)]
        [StringLength(TipContentMaxLen, MinimumLength = TipContentMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; } = null!;

        [Required]
        public DateTime PubllishedOn { get; set; } = DateTime.Now;

        [Required(ErrorMessage = RequiredField)]
        [Comment("category, obj representation")]
        public CategoryModel Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
