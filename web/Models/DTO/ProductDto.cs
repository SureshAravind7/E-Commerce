﻿
namespace web.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }

       
    }
}

