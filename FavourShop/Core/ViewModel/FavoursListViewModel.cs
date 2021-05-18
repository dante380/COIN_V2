using System.Collections.Generic;
using FavoursShop.Core.Models;

namespace FavoursShop.Core.ViewModel
{
    public class FavoursListViewModel
    {
        public IEnumerable<Favour> Favours { get; set; }
        public string CurrentCategory { get; set; }
    }
}
