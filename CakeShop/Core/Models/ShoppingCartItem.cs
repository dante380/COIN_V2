using System.ComponentModel.DataAnnotations;

namespace FavoursShop.Core.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        public int FavourId { get; set; }

        public Favour Favour { get; set; }

        [Required]
        [StringLength(1024)]
        public string ShoppingCartId { get; set; }
    }
}
