using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoursShop.Core.Dto;
using FavoursShop.Core.Models;

namespace FavoursShop.Persistence
{
    public class FavourRepository : IFavourRepository
    {
        private readonly FavourShopDbContext _context;

        public FavourRepository(FavourShopDbContext context)
        {
            _context = context;
        }


        public async Task<Favour> GetFavourById(int favourId)
        {
            return await _context.Favours.FirstAsync(e => e.Id == favourId);
        }


        public async Task<IEnumerable<Favour>> GetFavours(string category = null)
        {

            var query = _context.Favours
                .Include(c => c.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(c => c.Category.Name == category);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Favour>> GetFavoursOfTheWeek()
        {
            return await _context.Favours
                .Where(e => e.IsFavourOfTheWeek)
                .Include(e => e.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<FavourNameIdDto>> GetAllFavoursNameId()
        {
            return await _context.Favours
                 .Select(e => new FavourNameIdDto
                 {
                     Id = e.Id,
                     Name = e.Name
                 })
                 .ToListAsync();
        }


        public void UpdateFavour(Favour favour)
        {
            _context.Favours.Update(favour);
        }

        public async Task AddFavourAsync(Favour favour)
        {
            await _context.Favours.AddAsync(favour);
        }

        public void Delete(int id)
        {
            var favour = new Favour { Id = id };
            _context.Entry(favour).State = EntityState.Deleted;
        }
    }
}
