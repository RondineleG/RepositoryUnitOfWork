using RepositoryUnitOfWork.Domain.Base;
using RepositoryUnitOfWork.Domain.Departments;
using RepositoryUnitOfWork.Domain.Salaries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryUnitOfWork.Domain.Users
{
    [Table("Users")]
    public partial class User : DeleteEntity<int>
    {
        public User()
        {
            Salaries = new HashSet<Salary>();
        }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public short DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
