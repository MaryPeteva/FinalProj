using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlyTools.Infrastructure.Data.Utils.Errors.ErrorMessages;
using static OnlyTools.Infrastructure.Data.Utils.ValidationsConstants.ToolValidationConstants;
namespace OnlyTools.Core.Models
{
    public class ToolModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerID { get; set; }

        public byte[]? ToolPicture { get; set; }

        public decimal RentPrice { get; set; }
    }
}
