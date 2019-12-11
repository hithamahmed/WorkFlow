using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppWorkFlow.Data.Entity
{
    public class FlowRequestAction : Entitybase
    {
        [Required]
        public int FlowRequestId { get; set; }

        public DateTime ActionDate { get; set; }
        
        [ForeignKey("FlowRequestId")]
        public FlowRequest FlowRequest { get; set; }
        [MaxLength(10)]
        [Required]
        public string RequestStatus { get; set; }

        public int? RedirectToDepartmentId { get; set; }
        [ForeignKey("RedirectToDepartmentId")]
        public Department Department { get; set; }

    }
}
