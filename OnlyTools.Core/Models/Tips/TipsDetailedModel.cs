using OnlyTools.Core.Models.Category;

namespace OnlyTools.Core.Models.Tips
{
    public class TipsDetailedModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }

        public DateTime PublishedOn { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
