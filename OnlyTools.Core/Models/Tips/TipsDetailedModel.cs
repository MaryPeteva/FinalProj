using OnlyTools.Core.Models.Category;
using OnlyTools.Infrastructure.Data.IdentityModels;

namespace OnlyTools.Core.Models.Tips
{
    public class TipsDetailedModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public DateTime PublishedOn { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
