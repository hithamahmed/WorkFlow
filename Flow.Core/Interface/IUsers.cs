using AppWorkFlow.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WFlow.Core.Interface
{
    public interface IUsers
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetSingleUser(int userid);
        Task<int> AddEditUser(User user);
        Task<int> RemoveUser(int userid);

        Task<ICollection<Department>> GetDepartmentsList();
        Task<Department> GetSingleDepartment(int id);
        Task<int> AddEditDepartment(Department department);
    }
}
