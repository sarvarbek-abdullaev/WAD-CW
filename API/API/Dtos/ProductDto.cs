using API.Models;

namespace API.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
