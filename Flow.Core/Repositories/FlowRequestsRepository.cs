using AppWorkFlow.Core;
using AppWorkFlow.Data;
using AppWorkFlow.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFlow.Core.Interface;
namespace WFlow.Core.Repositories
{
    public class FlowRequestsRepository : IFlowRequests
    {
        private readonly FlowContext _db;
        public FlowRequestsRepository(FlowContext db)
        {
            _db = db;
        }
        public async Task<ICollection<FlowRequest>> GetNewRequestsByDepartmentHead(int userid)
        {
            try
            {
                return await _db.FlowRequests
                        .Include(x => x.WorkFlow)
                    .ThenInclude(x => x.Department)
                    .ThenInclude(x => x.UserHead)
                    .Where(x => x.WorkFlow.Department.UserHead.Id == userid)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ICollection<FlowRequestAction>> GetRequestsByDepartmentHead(int userid)
        {
            try
            {
                return await _db.FlowRequestActions
                    //.Include(x=>x.Department)
                    .Include(x => x.FlowRequest)
                    .ThenInclude(x => x.WorkFlow)
                    .ThenInclude(x => x.Department)
                    .ThenInclude(x => x.UserHead)
                    .Where(x =>
                    !x.FlowRequest.IsClosed
                    && x.Department.UserHead.Id == userid
                    && x.FlowRequest.CurrentFlowRequestActionId == x.Id)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> SetFlowRequestAction(FlowRequestAction flowRequestAction)
        {
            try
            {
                var statusname = (Enums.FlowAction)int.Parse(flowRequestAction.RequestStatus);
                flowRequestAction.RequestStatus = statusname.ToString();
                await _db.FlowRequestActions.AddAsync(flowRequestAction);
                await _db.SaveChangesAsync();

                var flowrequest = _db.FlowRequests.Find(flowRequestAction.FlowRequestId);
                flowrequest.IsNewRequest = false;
                flowrequest.CurrentFlowRequestActionId = flowRequestAction.Id;

                if (!flowRequestAction.RequestStatus.Equals(Enums.FlowAction.Redirect.ToString()))
                {
                    flowrequest.IsClosed = true;
                }

                return await _db.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
