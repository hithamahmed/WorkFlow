using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppWorkFlow.Data.Entity
{
    public class User : Entitybase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        //public ICollection<WorkFlow> WorkFlows { get; set; }

        //public ICollection<FlowRequest> FlowRequests { get; set; }
    }
}
