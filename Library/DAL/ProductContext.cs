using Library.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public class ProductContext : DbContext
    {
            // Constructer
        public ProductContext(DbContextOptions<ProductContext> o) : base(o)
        {
            Database.EnsureCreated();
        }

        // Product Database
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
