using System.Collections.Generic;
using FavoursShop.Core.Dto;
using FavoursShop.Core.Models;

namespace FavoursShop.Core.ViewModel
{
    public class FavourCreateUpdateViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public FavourDto FavourDto { get; set; }

        public FavourCreateUpdateViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
