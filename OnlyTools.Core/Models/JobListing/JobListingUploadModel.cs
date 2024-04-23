using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Models.Category;
using OnlyTools.Infrastructure.Data.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.JobListingValidationConstants;
namespace OnlyTools.Core.Models.JobListing
{
    public class JobListingUploadModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(JobListingTitleMaxLen)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(JobListingDescriptionMaxLen)]
        public string Description { get; set; } = null!;
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime Posted { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(PosterId))]
        public Guid PosterId { get; set; }
        public virtual ApplicationUser Poster { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Comment("category, obj representation")]
        public CategoryModel Category { get; set; } = null!;

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        [Required]
        [Comment("Indicates if the listing is for offering a service or looking for handyman")]
        public bool IsServiceOffered { get; set; }
    }
}
