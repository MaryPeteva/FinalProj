using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;

namespace OnlyTools.Core.Models
{
    public class ToolUploadModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(ToolNameMaxLen, MinimumLength = ToolNameMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Name { get; set; }
        [Required]
        [StringLength(ToolDescriptionMaxLen, MinimumLength = ToolDescriptionMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(OwnerID))]
        public string OwnerID { get; set; }

        [Required]
        public bool IsRented { get; set; }
        public IFormFile? ToolPicture { get; set; }

        [Required]
        public decimal RentPrice { get; set; }
    }
}
