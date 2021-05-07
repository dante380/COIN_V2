using System.ComponentModel.DataAnnotations;

namespace CakeShop.Core.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        public int CakeId { get; set; }

        public Cake Cake { get; set; }

        [Required]
        [StringLength(1024)]
        public string ShoppingCartId { get; set; }
    }
}
