using AppWorkFlow.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WFlow.Core.Interface
{
    public interface IFlowRequests
    {
        Task<ICollection<FlowRequest>> GetNewRequestsByDepartmentHead(int userid);
        Task<int> SetFlowRequestAction(FlowRequestAction flowRequestAction);
        Task<ICollection<FlowRequestAction>> GetRequestsByDepartmentHead(int userid);
    }
}
