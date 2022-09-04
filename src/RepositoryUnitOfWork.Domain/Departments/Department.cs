using RepositoryUnitOfWork.Domain.Base;
using RepositoryUnitOfWork.Domain.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryUnitOfWork.Domain.Departments
{
    [Table("Departments")]
    public partial class Department : AuditEntity<short>
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public string DepartmentName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
