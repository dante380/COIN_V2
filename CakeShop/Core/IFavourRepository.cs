using CakeShop.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Core.Models
{
    public interface IFavourRepository
    {
        Task<IEnumerable<Cake>> GetFavours(string category = null);
        Task<IEnumerable<Cake>> GetFavoursOfTheWeek();

        Task<Cake> GetFavourById(int favourId);

        Task<IEnumerable<CakeNameIdDto>> GetAllFavoursNameId();

        void UpdateFavour(Cake favour);
        Task AddFavourAsync(Cake favour);
        void Delete(int id);
    }
}
