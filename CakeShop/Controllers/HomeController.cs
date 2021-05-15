using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFavourRepository _cakeRepository;

        public HomeController(IFavourRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                CakeOfTheWeek = await _cakeRepository.GetFavoursOfTheWeek()
            });
        }
    }
}