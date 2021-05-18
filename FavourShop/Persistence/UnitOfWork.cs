using System.Threading.Tasks;
using FavoursShop.Core;

namespace FavoursShop.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FavourShopDbContext _context;

        public UnitOfWork(FavourShopDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync() =>
            await _context.SaveChangesAsync();
    }
}
