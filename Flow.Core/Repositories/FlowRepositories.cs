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
    public class FlowRepositories : IFlow
    {
        private readonly FlowContext _db;
        public FlowRepositories(FlowContext db)
        {
            _db = db;
        }
        public async Task<int> AddEditFlow(WorkFlow t)
        {
            try
            {
                if (t.Id == 0)
                {
                    _db.WorkFlows.Add(t);
                }
                else
                {
                    _db.Update(t);
                }

                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WorkFlow> GetSingleFlow(int tId)
        {
            try
            {
                var user = await _db.WorkFlows.FindAsync(tId);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<WorkFlow>> GetWFlows()
        {
            try
            {
                return await _db.WorkFlows.Include(x => x.Department)//.Include(x=>x.Actions)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<FlowRequest>> GetWFlowRequests()
        {
            try
            {
                return await _db.FlowRequests
                    .Include(x => x.RequestActions)
                    .Include(x => x.WorkFlow)
                    .ThenInclude(x => x.Department)
                    .ThenInclude(x => x.UserHead)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> AddEditFlowRequest(FlowRequest t)
        {
            try
            {


                if (t.Id == 0)
                {
                    _db.FlowRequests.Add(t);
                }
                else
                {
                    _db.Update(t);
                }
                int FR = await _db.SaveChangesAsync();
                if (FR > 0)
                {
                    var flowrequest = _db.FlowRequests
                        .Include(x => x.WorkFlow)
                        .ThenInclude(x => x.Department).Where(x => x.Id == t.Id).SingleOrDefault();
                    FlowRequestAction flowRequestAction = new FlowRequestAction
                    {
                        ActionDate = DateTime.UtcNow.AddHours(3),
                        RequestStatus = "New",
                        FlowRequestId = flowrequest.Id,
                        RedirectToDepartmentId = flowrequest.WorkFlow.Department.Id
                    };

                    _db.FlowRequestActions.Add(flowRequestAction);
                    await _db.SaveChangesAsync();

                    flowrequest.CurrentFlowRequestActionId = flowRequestAction.Id;
                }
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FlowRequest> GetSingleFlowRequest(int id)
        {
            try
            {
                var flowreq = await _db.FlowRequests
                    .FindAsync(id);
                return flowreq;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
