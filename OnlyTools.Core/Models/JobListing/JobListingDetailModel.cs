using OnlyTools.Core.Models.Category;
using OnlyTools.Infrastructure.Data.IdentityModels;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Core.Models.JobListing
{
    public class JobListingDetailModel
    {

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }


        public DateTime Posted { get; set; } = DateTime.Now;

        public Guid PosterId { get; set; }
        public virtual ApplicationUser Poster { get; set; } = null!;

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; } = null!;

        public bool IsServiceOffered { get; set; }
    }
}
