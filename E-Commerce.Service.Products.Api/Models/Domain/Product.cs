using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Service.Products.Api.Models.Domain;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;
    [Required]
    public string? Description { get; set; }
    [Required]
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }
    [Required]
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }
  
    public DateTime? CreatedDate { get; set; }
   
    public DateTime? ModifiedDate { get; set; }
   
  
}
