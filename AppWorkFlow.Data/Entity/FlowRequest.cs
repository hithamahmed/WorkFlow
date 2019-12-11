using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppWorkFlow.Data.Entity
{
    public class FlowRequest : Entitybase
    {
        public string Name { get; set; }
        public int WorkFlowId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public int? CurrentFlowRequestActionId { get; set; }
       
        public WorkFlow WorkFlow { get; set; }
        public IEnumerable<WorkFlow> EnumerableWorkFlows { get; set; }
        public bool IsClosed { get; set; }
        public bool IsNewRequest { get; set; }

        public ICollection<FlowRequestAction> RequestActions { get; set; } 

       
    }
}
