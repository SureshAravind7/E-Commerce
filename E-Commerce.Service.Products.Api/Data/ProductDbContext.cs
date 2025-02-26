using System;
using System.Collections.Generic;
using E_Commerce.Service.Products.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.Products.Api.Data;

public partial class ProductDbContext : DbContext
{


    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }


}
