using OnlyTools.Core.Models.Category;
namespace OnlyTools.Core.Models.Tool
{
    public class ToolModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public Guid OwnerID { get; set; }

        public byte[]? ToolPicture { get; set; }

        public decimal RentPrice { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
