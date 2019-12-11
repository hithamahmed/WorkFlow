using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWorkFlow.Data.Entity;
using WFlow.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Flow.Web.UI.Pages
{
    public class UsersModel : PageModel
    {
        private readonly IUsers usersService;
        public ICollection<User> Users { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<AppWorkFlow.Data.Entity.WorkFlow> flows { get; set; }

        public UsersModel(IUsers _usersService)
        {
            usersService = _usersService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Users = await usersService.GetUsers();
                Departments = await usersService.GetDepartmentsList();
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }
          
        }
        public async Task<IActionResult> OnGetAddEditUserAsync(int userid)
        {
            try
            {
                
                User user = new User();
                if(userid==0)
                    return Partial("_AddEditUser", user);

                user = await usersService.GetSingleUser(userid);
                return Partial("_AddEditUser", user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }

        }
        public async Task<IActionResult> OnPostSaveUserAsync(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = await usersService.AddEditUser(user);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }
           
        }
        public async Task<IActionResult> OnPostRemoveUserAsync(int userid)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = await usersService.RemoveUser(userid);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }
        }


        public async Task<IActionResult> OnGetDepartmentsAsync()
        {
            try
            {
                Departments = await usersService.GetDepartmentsList();
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }

        }
        public async Task<IActionResult> OnGetAddEditDepartmentAsync(int id)
        {
            try
            {

                Department department = new Department();
                var users = await usersService.GetUsers();
                department.UsersEnumerable = users;
                if (id == 0)
                    return Partial("_AddEditDepartment", department);

                department = await usersService.GetSingleDepartment(id);
                department.UsersEnumerable = users;
                return Partial("_AddEditDepartment", department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }

        }
        public async Task<IActionResult> OnPostSaveDepartmentAsync(Department department)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = await usersService.AddEditDepartment(department);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }

        }
    }
}