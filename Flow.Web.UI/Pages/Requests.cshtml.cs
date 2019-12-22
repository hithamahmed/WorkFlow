using AppWorkFlow.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFlow.Core.Interface;

namespace WFlow.Web.UI.Pages
{
    public class RequestsModel : PageModel
    {
        private readonly IFlow _service;
        private readonly IUsers _gservice;
        public ICollection<FlowRequest> FlowRequests { get; set; }

        public RequestsModel(IFlow service,
            IUsers gservice)
        {
            _service = service;
            _gservice = gservice;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                FlowRequests = await _service.GetWFlowRequests();
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

                FlowRequest flowrequests = new FlowRequest();
                var flows = await _service.GetWFlows();
                flowrequests.EnumerableWorkFlows = flows;
                flowrequests.RequestDate = DateTime.UtcNow.AddHours(3);
                flowrequests.IsNewRequest = true;
                if (id == 0)
                {
                    return Partial("_AddEditRequest", flowrequests);
                }

                flowrequests = await _service.GetSingleFlowRequest(id);
                flowrequests.EnumerableWorkFlows = flows;
                return Partial("_AddEditRequest", flowrequests);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }

        }
        public async Task<IActionResult> OnPostSaveAsync(FlowRequest flowRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToPage();
                }

                int i = await _service.AddEditFlowRequest(flowRequest);
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