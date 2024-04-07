using Microsoft.EntityFrameworkCore;
using OnlyTools.Infrastructure.Data.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Models.ToolCategory;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;

namespace OnlyTools.Infrastructure.Data.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the tool to be displayed")]
        [MaxLength(ToolNameMaxLen)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ToolDescriptionMaxLen)]
        [Comment("Description of the tool to be displayed")]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OwnerID))]
        [Comment("Foreign key referencing the owner of the tool")]
        public Guid OwnerID { get; set; }

        [Comment("Navigation property representing the owner of the tool")]
        public ApplicationUser Owner { get; set; } = null!;

        [ForeignKey(nameof(RenterID))]
        [Comment("Foreign key referencing the renter of the tool")]
        public Guid? RenterID { get; set; }

        [Comment("Navigation property representing the renter of the tool")]
        public ApplicationUser? Renter { get; set; }

        [Required]
        [Comment("Indicates whether the tool is currently rented out")]
        public bool IsRented { get; set; } = false;

        [Comment("Picture of the tool, stored as a byte array, optional")]
        public byte[]? ToolPicture { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Price for renting the tool")]
        public decimal RentPrice { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("category, obj representation")]
        public ToolCategory Category { get; set; } = null!;
    }
}