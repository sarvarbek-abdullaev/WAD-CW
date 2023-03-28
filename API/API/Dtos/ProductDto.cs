using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is mandatory field")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is mandatory field")]
        [StringLength(int.MaxValue, MinimumLength = 2)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is mandatory field")]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public Category ProductCategory { get; set; }
        [Required(ErrorMessage = "Caategory is mandatory field")]
        [Range(0, int.MaxValue)]
        public int ProductCategoryId { get; set; }
    }
}
