using System;
using System.Collections.Generic;
using FavoursShop.Core.Dto;

namespace FavoursShop.Core.ViewModel
{
    public class MyOrderViewModel
    {
        public OrderDto OrderPlaceDetails { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlacedTime { get; set; }
        public IEnumerable<MyFavourOrderInfo> FavourOrderInfos { get; set; }

    }

    public class MyFavourOrderInfo
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
