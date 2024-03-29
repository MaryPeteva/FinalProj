namespace OnlyTools.Core.Models
{
    public class ToolDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string OwnerID { get; set; }

        public bool IsRented { get; set; }

        public byte[]? ToolPicture { get; set; }

        public decimal RentPrice { get; set; }

        public string RenterId { get; set; }
    }
}
