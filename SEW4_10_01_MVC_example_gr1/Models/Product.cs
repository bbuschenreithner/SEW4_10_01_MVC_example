using System.ComponentModel.DataAnnotations;

namespace SEW4_10_01_MVC_example_gr1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Range(0, 9999999.99)]
        public double Price { get; set; }
    }
}
