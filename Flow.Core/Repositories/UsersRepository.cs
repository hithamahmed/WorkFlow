using AppWorkFlow.Data;
using AppWorkFlow.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFlow.Core.Interface;

namespace WFlow.Core.Repositories
{
    public class UsersRepository : IUsers
    {
        private readonly FlowContext _db;
        public UsersRepository(FlowContext db)
        {
            _db = db;
        }

        public async Task<int> AddEditDepartment(Department department)
        {
            try
            {
                if (department.Id == 0)
                {
                    _db.Departments.Add(department);
                }
                else
                {
                    _db.Update(department);
                }

                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddEditUser(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    _db.Users.Add(user);
                }
                else
                {
                    _db.Update(user);
                }

                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Department>> GetDepartmentsList()
        {
            try
            {
                return await _db.Departments.Include(x => x.UserHead).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Department> GetSingleDepartment(int id)
        {
            try
            {
                var user = await _db.Departments.FindAsync(id);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetSingleUser(int userid)
        {
            try
            {
                var user = await _db.Users.FindAsync(userid);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<User>> GetUsers()
        {
            try
            {
                return await _db.Users.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> RemoveUser(int userid)
        {
            try
            {
                var user = await _db.Users.FindAsync(userid);
                _db.Users.Remove(user);

                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
