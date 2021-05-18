using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoursShop.Core.Models;

namespace FavoursShop.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FavourShopDbContext _context;

        public CategoryRepository(FavourShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
