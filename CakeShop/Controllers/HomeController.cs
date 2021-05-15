using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FavoursShop.Core.Models;
using FavoursShop.Core.ViewModel;

namespace FavoursShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFavourRepository _favourRepository;

        public HomeController(IFavourRepository favourRepository)
        {
            _favourRepository = favourRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                FavourOfTheWeek = await _favourRepository.GetFavoursOfTheWeek()
            });
        }
    }
}