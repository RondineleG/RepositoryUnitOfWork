using RepositoryUnitOfWork.Domain.Interfaces;
using RepositoryUnitOfWork.Domain.Users;

namespace RepositoryUnitOfWork.Domain.Salaries
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        Salary AddUserSalary(User user, float coefficientsSalary, float workdays);
    }
}
