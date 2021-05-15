using System.Collections.Generic;
using System.Threading.Tasks;
using FavoursShop.Core.Dto;

namespace FavoursShop.Core.Models
{
    public interface IFavourRepository
    {
        Task<IEnumerable<Favour>> GetFavours(string category = null);
        Task<IEnumerable<Favour>> GetFavoursOfTheWeek();

        Task<Favour> GetFavourById(int favourId);

        Task<IEnumerable<FavourNameIdDto>> GetAllFavoursNameId();

        void UpdateFavour(Favour favour);
        Task AddFavourAsync(Favour favour);
        void Delete(int id);
    }
}
