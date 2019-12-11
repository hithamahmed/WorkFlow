using AppWorkFlow.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WFlow.Core.Interface
{
    public interface IFlow
    {
        Task<ICollection<WorkFlow>> GetWFlows();
        Task<WorkFlow> GetSingleFlow(int id);
        Task<int> AddEditFlow(WorkFlow workFlow);



        Task<ICollection<FlowRequest>> GetWFlowRequests();
        Task<FlowRequest> GetSingleFlowRequest(int id);
        Task<int> AddEditFlowRequest(FlowRequest flowRequest);
    }
}
