using System.ComponentModel.DataAnnotations;

namespace FavoursShop.Core.Dto
{
    public class OrderDto
    {


        [StringLength(1024)]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя нужно")]
        public string FirstName { get; set; }

        [StringLength(1024)]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия нужна")]
        public string LastName { get; set; }

        [StringLength(1024)]
        [Display(Name = "Адрес 1")]
        [Required(ErrorMessage = "Адрес 1 нужен")]
        public string AddressLine1 { get; set; }

        [StringLength(1024)]
        [Display(Name = "Адрес 2")]
        public string AddressLine2 { get; set; }

        [StringLength(1024)]
        [Display(Name = "Город")]
        [Required(ErrorMessage = "город нужен")]
        public string City { get; set; }

        [StringLength(1024)]
        [Display(Name = "Область")]
        [Required(ErrorMessage = "Область нужна")]
        public string State { get; set; }

        [StringLength(1024)]
        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Страна нужна")]
        public string Country { get; set; }

        [StringLength(6)]
        [Required(ErrorMessage = "Почтовый индекс нужен")]
        [Display(Name = "Почтовый индекс")]
        public string ZipCode { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Номер телефона нужен")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(1024)]
        [Required(ErrorMessage = "Електронная почта нужна")]
        [Display(Name = "Електронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
