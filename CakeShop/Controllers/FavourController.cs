using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FavoursShop.Core.Models;
using FavoursShop.Core.ViewModel;

namespace FavoursShop.Controllers
{
    [Route("/service")]
    public class FavourController : Controller
    {
        private readonly IFavourRepository _favourRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FavourController(IFavourRepository favourRepository, ICategoryRepository categoryRepository)
        {
            _favourRepository = favourRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{category?}")]
        public async Task<IActionResult> List(string category)
        {
            var selectedCategory = !string.IsNullOrWhiteSpace(category) ? category : null;
            var favoursListViewModel = new FavoursListViewModel
            {
                Favours = await _favourRepository.GetFavours(selectedCategory),
                CurrentCategory = selectedCategory ?? "All services"
            };
            return View(favoursListViewModel);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var favour = await _favourRepository.GetFavourById(id);

            return View(favour);
        }
    }
}
