using OnlyTools.Infrastructure.Data.IdentityModels;
using OnlyTools.Infrastructure.Data.Models;
namespace OnlyTools.Core.Models.JobListing
{
    public class JobListingAllModel
    {

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime Posted { get; set; } = DateTime.Now;

        public Guid PosterId { get; set; }
        public virtual ApplicationUser Poster { get; set; }
        public int CategoryId { get; set; }

        public JobListingCategory Category { get; set; } = null!;

        public bool IsServiceOffered { get; set; }
    }
}
