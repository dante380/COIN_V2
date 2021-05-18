using System.Collections.Generic;
using FavoursShop.Core.Models;

namespace FavoursShop.Core.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Favour> FavourOfTheWeek { get; set; }
    }
}
