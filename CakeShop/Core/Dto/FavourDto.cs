using System.ComponentModel.DataAnnotations;

namespace FavoursShop.Core.Dto
{
    public class FavourDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название услуги")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Краткое описание")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Длинное название")]
        [MaxLength(1024)]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Ссылка картинки")]
        public string ImageUrl { get; set; }

        [Display(Name = "Это услуга недели?")]
        public bool IsCakeOfTheWeek { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
    }
}
