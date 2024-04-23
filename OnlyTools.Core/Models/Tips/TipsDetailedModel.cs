using OnlyTools.Core.Models.Category;
using OnlyTools.Core.Models.Like;
using OnlyTools.Infrastructure.Data.IdentityModels;
using System.ComponentModel.DataAnnotations;

namespace OnlyTools.Core.Models.Tips
{
    public class TipsDetailedModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public DateTime PublishedOn { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public IList<LikeModel> Likes { get; set; } = new List<LikeModel>();
    }
}
