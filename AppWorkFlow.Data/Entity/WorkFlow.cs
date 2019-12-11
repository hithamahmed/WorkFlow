using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWorkFlow.Data.Entity
{
    
    public class WorkFlow: Entitybase
    {
        //define flow like request vacations, payslip, leave

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string Details { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } //the in charge of the flow
        //public ICollection<RequestAction> Actions { get; set; }

        public IEnumerable<Department> DepartmentIEnumerable { get; set; }

    }
}