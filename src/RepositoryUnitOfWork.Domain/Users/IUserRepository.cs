using RepositoryUnitOfWork.Domain.Departments;
using RepositoryUnitOfWork.Domain.Interfaces;

namespace RepositoryUnitOfWork.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User NewUser(string userName
            , string email
            , Department department);
    }
}
