using System;

namespace API.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
