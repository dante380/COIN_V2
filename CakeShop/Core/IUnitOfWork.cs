using System.Threading.Tasks;

namespace FavoursShop.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
