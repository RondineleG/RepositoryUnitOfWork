using RepositoryUnitOfWork.Domain.Interfaces;

namespace RepositoryUnitOfWork.Domain.Departments
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department AddDepartment(string departmentName);
    }
}
