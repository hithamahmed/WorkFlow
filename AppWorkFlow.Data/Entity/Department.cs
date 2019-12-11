using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppWorkFlow.Data.Entity
{
    public class Department : Entitybase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        
        [MaxLength(100)]
        public string Description { get; set; }

        public int UserHeadId { get; set; }

        [ForeignKey("UserHeadId")]
        public User UserHead { get; set; }


        public IEnumerable<User> UsersEnumerable { get; set; }
    }
}
