using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoursShop.Core.Models
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
