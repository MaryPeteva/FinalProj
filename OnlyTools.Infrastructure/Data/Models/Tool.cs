using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlyTools.Infrastructure.Data.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the tool to be displayed")]
        [MaxLength(ToolNameMaxLen)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ToolDescriptionMaxLen)]
        [Comment("Description of the tool to be displayed")]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(OwnerID))]
        [Comment("Foreign key referencing the owner of the tool")]
        public string OwnerID { get; set; }

        [Comment("Navigation property representing the owner of the tool")]
        public ToolOwner Owner { get; set; }

        [ForeignKey(nameof(RenterID))]
        [Comment("Foreign key referencing the renter of the tool")]
        public string? RenterID { get; set; }

        [Comment("Navigation property representing the renter of the tool")]
        public ToolRenter? Renter { get; set; }

        [Required]
        [Comment("Indicates whether the tool is currently rented out")]
        public bool IsRented { get; set; } = false;

        [Comment("Picture of the tool, stored as a byte array, optional")]
        public byte[]? ToolPicture { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Price for renting the tool")]
        public decimal RentPrice { get; set; }
    }
}

