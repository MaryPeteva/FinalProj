﻿using OnlyTools.Infrastructure.Data.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.JobListingValidationConstants;

namespace OnlyTools.Infrastructure.Data.Models
{
    public class JobListing
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
    }
}
