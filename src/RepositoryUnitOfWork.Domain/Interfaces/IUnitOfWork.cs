using System.Threading.Tasks;

namespace RepositoryUnitOfWork.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
