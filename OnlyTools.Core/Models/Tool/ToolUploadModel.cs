using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Models.Category;
using OnlyTools.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;

namespace OnlyTools.Core.Models.Tool
{
    public class ToolUploadModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(ToolNameMaxLen, MinimumLength = ToolNameMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(ToolDescriptionMaxLen, MinimumLength = ToolDescriptionMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(OwnerID))]
        public Guid OwnerID { get; set; }

        [Required]
        public bool IsRented { get; set; }
        public IFormFile? ToolPicture { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public decimal RentPrice { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Comment("category, obj representation")]
        public CategoryModel Category { get; set; } = null!;

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
