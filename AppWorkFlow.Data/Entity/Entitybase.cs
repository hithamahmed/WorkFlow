using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWorkFlow.Data.Entity
{
    public class Entitybase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Editable(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime CreatedAt { get; set; }

        [Editable(false)]
        public string CreatedBy { get; set; }

        [Editable(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime? ModifiedAt { get; set; }

        [Editable(false)]
        public string ModifiedBy { get; set; }

        [Editable(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime? DeletedAt { get; set; }

        [Editable(false)]
        public string DeletedBy { get; set; }
    }
}
