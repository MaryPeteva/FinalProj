using OnlyTools.Core.Models.Category;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;
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
