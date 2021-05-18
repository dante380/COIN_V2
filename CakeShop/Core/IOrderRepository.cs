using System.Collections.Generic;
using System.Threading.Tasks;
using FavoursShop.Core.ViewModel;

namespace FavoursShop.Core.Models
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync(string userId);
    }
}