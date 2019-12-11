using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppWorkFlow.Data.Entity
{
    public class RequestAction : Entitybase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsEndPoint { get; set; } //accepted, rejected, otherwise like redirect
         
        public int WorkFlowId { get; set; }
        public WorkFlow WorkFlow { get; set; }

        public int? RedirectToDepartmentId { get; set; }

        [ForeignKey("RedirectToDepartmentId")]
        public Department RedirectToDepartment { get; set; }
    }
}
