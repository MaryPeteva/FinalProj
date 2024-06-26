﻿namespace OnlyTools.Core.Models.Tool
{
    public class ToolDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerID { get; set; }

        public bool IsRented { get; set; }

        public byte[]? ToolPicture { get; set; }

        public decimal RentPrice { get; set; }

        public Guid RenterId { get; set; }

        public string Category { get; set;}
    }
}
