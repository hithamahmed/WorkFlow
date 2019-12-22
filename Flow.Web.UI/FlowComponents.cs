using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WFlow.Core.Interface;

namespace WFlow.Web.UI
{
    [ViewComponent(Name = "NewRequests")]
    public class FlowComponents : ViewComponent
    {
        private readonly IFlowRequests _repost;

        public FlowComponents(IFlowRequests repost)
        {

            _repost = repost;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userid)
        {

            var _List = await _repost.GetRequestsByDepartmentHead(userid);
            return View(_List);
        }
    }

}
