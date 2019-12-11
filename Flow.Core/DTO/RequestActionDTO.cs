using AppWorkFlow.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WFlow.Core.DTO
{
    public class RequestActionDTO
    {
        public int Id { get; set; }
        public int FlowRequestId { get; set; }
        public string RequestStatus { get; set; }
        public int RedirectToDepartmentId { get; set; }
        public ICollection<Department> DepartmentEnumerable { get; set; }
    }
}
