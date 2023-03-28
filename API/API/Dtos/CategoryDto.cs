using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CategoryDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is mandatory field")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is mandatory field")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Description { get; set; }
    }
}
