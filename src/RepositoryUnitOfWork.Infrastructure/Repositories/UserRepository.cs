using RepositoryUnitOfWork.Domain.Departments;
using RepositoryUnitOfWork.Domain.Users;
using System;

namespace RepositoryUnitOfWork.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public User NewUser(string userName, string email, Department department)
        {
            var user = new User(userName, email, department);
            if (user.ValidOnAdd())
            {
                this.Add(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }
    }
}
