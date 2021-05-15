using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    [Route("/service")]
    public class FavourController : Controller
    {
        private readonly IFavourRepository _cakeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FavourController(IFavourRepository cakeRepository, ICategoryRepository categoryRepository)
        {
            _cakeRepository = cakeRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{category?}")]
        public async Task<IActionResult> List(string category)
        {
            var selectedCategory = !string.IsNullOrWhiteSpace(category) ? category : null;
            var cakesListViewModel = new CakesListViewModel
            {
                Cakes = await _cakeRepository.GetFavours(selectedCategory),
                CurrentCategory = selectedCategory ?? "All services"
            };
            return View(cakesListViewModel);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var cake = await _cakeRepository.GetFavourById(id);

            return View(cake);
        }
    }
}
