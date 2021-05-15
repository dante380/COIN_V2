using System.ComponentModel.DataAnnotations;

namespace FavoursShop.Core.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string FavourName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
