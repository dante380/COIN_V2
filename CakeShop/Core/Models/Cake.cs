using System.ComponentModel.DataAnnotations;

namespace CakeShop.Core.Models
{
    public class Cake
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(1024)]
        public string LongDescription { get; set; }

        [Required]
        [StringLength(1024)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(1024)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(1024)]
        public bool IsCakeOfTheWeek { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
