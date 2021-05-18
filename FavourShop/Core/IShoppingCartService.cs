using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoursShop.Core.Models
{
    public interface IShoppingCartService
    {
        string Id { get; set; }
        IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        Task<int> AddToCartAsync(Favour favour, int qty = 1);
        Task ClearCartAsync();
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync();
        Task<int> RemoveFromCartAsync(Favour favour);
        Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync();
    }
}