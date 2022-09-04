using RepositoryUnitOfWork.Domain.Salaries;
using RepositoryUnitOfWork.Domain.Users;
using System;

namespace RepositoryUnitOfWork.Infrastructure.Repositories
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public Salary AddUserSalary(User user, float coefficientsSalary, float workdays)
        {
            var salary = new Salary(user, coefficientsSalary, workdays);
            if (salary.ValidOnAdd())
            {
                this.Add(salary);
                return salary;
            }
            else
                throw new Exception("Salary invalid");
        }
    }
}
