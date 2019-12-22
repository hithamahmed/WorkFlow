using AppWorkFlow.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFlow.Core.Interface;

namespace WFlow.Web.UI.Pages
{
    public class FlowsModel : PageModel
    {
        private readonly IFlow _service;
        private readonly IUsers _gservice;
        public ICollection<WorkFlow> flows { get; set; }

        public FlowsModel(IFlow service,
            IUsers gservice)
        {
            _service = service;
            _gservice = gservice;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                flows = await _service.GetWFlows();
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }

        }
        public async Task<IActionResult> OnGetAddEditAsync(int id)
        {
            try
            {

                WorkFlow flow = new WorkFlow();
                var depts = await _gservice.GetDepartmentsList();
                flow.DepartmentIEnumerable = depts;
                if (id == 0)
                {
                    return Partial("_AddEditFlow", flow);
                }

                flow = await _service.GetSingleFlow(id);
                flow.DepartmentIEnumerable = depts;
                return Partial("_AddEditFlow", flow);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }

        }
        public async Task<IActionResult> OnPostSaveAsync(WorkFlow flow)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToPage();
                }

                int i = await _service.AddEditFlow(flow);
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