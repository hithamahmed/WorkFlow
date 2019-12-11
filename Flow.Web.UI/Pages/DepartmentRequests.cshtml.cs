using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWorkFlow.Core;
using AppWorkFlow.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WFlow.Core.DTO;
using WFlow.Core.Interface;

namespace WFlow.Web.UI.Pages
{
    public class DepartmentRequestsModel : PageModel
    {
        private readonly IUsers usersService;
        private readonly IFlowRequests requestsService;
        private readonly IFlow flowsService;
        public ICollection<User> Users { get; set; }
        public IEnumerable<Department> DepartmentEnumerable { get; set; }
        public DepartmentRequestsModel(IUsers _usersService,
            IFlowRequests _requestsService,
            IFlow _flowsService)
        {
            usersService = _usersService;
            requestsService = _requestsService;
            flowsService = _flowsService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Users = await usersService.GetUsers();
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }

        }

        public async Task<IActionResult> OnGetSubmitActionAsync(int id,int frid)
        {
            try
            {
                RequestActionDTO flowRequestAction = new RequestActionDTO();
                flowRequestAction.Id = id;
                flowRequestAction.FlowRequestId = frid;
                flowRequestAction.DepartmentEnumerable = await usersService.GetDepartmentsList();

                return Partial("_SetRequestAction", flowRequestAction);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToPage();
            }

        }
        public async Task<IActionResult> OnPostSaveAsync(RequestActionDTO flowRequestActionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();
                FlowRequestAction flowRequestAction = new FlowRequestAction();
                flowRequestAction.RequestStatus = flowRequestActionDto.RequestStatus;
                flowRequestAction.FlowRequestId = flowRequestActionDto.FlowRequestId;
                var actionstatus = (Enums.FlowAction)int.Parse(flowRequestActionDto.RequestStatus);
                if (actionstatus.ToString().Equals(Enums.FlowAction.Redirect.ToString()))
                    flowRequestAction.RedirectToDepartmentId = flowRequestActionDto.RedirectToDepartmentId;
                 
                flowRequestAction.ActionDate = DateTime.UtcNow.AddHours(3);


                int i = await requestsService.SetFlowRequestAction(flowRequestAction);
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