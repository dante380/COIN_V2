using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FavoursShop.Core.Models;
using FavoursShop.Core.ViewModel;

namespace FavoursShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFavourRepository _favourRepository;
        private readonly IShoppingCartService _shoppingCart;

        public ShoppingCartController(IFavourRepository favourRepository, IShoppingCartService shoppingCart)
        {
            _favourRepository = favourRepository;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Index()
        {
            await _shoppingCart.GetShoppingCartItemsAsync();
            var shoppingCartCountTotal = await _shoppingCart.GetCartCountAndTotalAmmountAsync();
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartItemsTotal = shoppingCartCountTotal.ItemCount,
                ShoppingCartTotal = shoppingCartCountTotal.TotalAmmount,
            };


            return View(shoppingCartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(int favourId)
        {
            var favourById = await _favourRepository.GetFavourById(favourId);
            if (favourById == null)
            {
                return NotFound();
            }

            await _shoppingCart.AddToCartAsync(favourById);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromShoppingCart(int favourId)
        {
            var favourById = await _favourRepository.GetFavourById(favourId);
            if (favourById == null)
            {
                return NotFound();
            }

            await _shoppingCart.RemoveFromCartAsync(favourById);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllCart()
        {
            await _shoppingCart.ClearCartAsync();
            return RedirectToAction("Index");
        }
    }
}