using Microsoft.AspNetCore.Identity;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace OnlyTools.Core.Models
{
    public class ToolModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(ToolNameMaxLen, MinimumLength =ToolNameMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Name { get; set; }
        [Required]
        [StringLength(ToolDescriptionMaxLen, MinimumLength = ToolDescriptionMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(OwnerID))]
        public string OwnerID { get; set; }

        //public virtual IdentityUser? Owner { get; set; }

        [Required]
        public bool IsRented { get; set; }

        public byte[]? ToolPicture { get; set; }

        [Required]
        public decimal RentPrice { get; set; }
    }
}
