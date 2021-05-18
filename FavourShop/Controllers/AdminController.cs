using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FavoursShop.Core;
using FavoursShop.Core.Dto;
using FavoursShop.Core.Models;
using FavoursShop.Core.ViewModel;

namespace FavoursShop.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/admin/manageCakes")]
    public class AdminController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFavourRepository _favourRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(
            IOrderRepository orderRepository,
            IFavourRepository favourRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository)
        {
            _orderRepository = orderRepository;
            _favourRepository = favourRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("allOrders")]
        public async Task<IActionResult> AllOrders()
        {
            ViewBag.ActionTitle = "All Orders";
            var orders = await _orderRepository.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet("")]
        public async Task<IActionResult> ManageFavours()
        {
            var allFavoursNameId = await _favourRepository.GetAllFavoursNameId();
            return View(allFavoursNameId);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddFavour()
        {
            var category = await _categoryRepository.GetCategories();
            return View(new FavourCreateUpdateViewModel
            {
                Categories = category
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFavour(FavourDto favourDto)
        {
            if (!ModelState.IsValid)
            {
                var category = await _categoryRepository.GetCategories();
                return View(new FavourCreateUpdateViewModel
                {
                    FavourDto = favourDto,
                    Categories = category
                });
            }
            var favour = _mapper.Map<FavourDto, Favour>(favourDto);
            await _favourRepository.AddFavourAsync(favour);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("ManageFavours");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditFavour(int id)
        {
            var favour = await _favourRepository.GetFavourById(id);
            var favourDto = _mapper.Map<Favour, FavourDto>(favour);
            var category = await _categoryRepository.GetCategories();

            return View(new FavourCreateUpdateViewModel
            {
                Categories = category,
                FavourDto = favourDto
            });
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditFavour(int id, [FromForm]FavourDto favourDto)
        {
            if (!ModelState.IsValid)
            {
                var category = await _categoryRepository.GetCategories();
                return View(new FavourCreateUpdateViewModel
                {
                    Categories = category,
                    FavourDto = favourDto
                });
            }
            var favour = _mapper.Map<FavourDto, Favour>(favourDto);
            favour.Id = id;
            _favourRepository.UpdateFavour(favour);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction("ManageFavours");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavour(int id)
        {
            _favourRepository.Delete(id);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}