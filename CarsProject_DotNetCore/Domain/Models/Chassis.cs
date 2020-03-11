using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class Chassis
    {
        [Required] [Key]
        public Guid ChassisId { get; set; }

        public string Description { get; set; }

        public string CodeNumber { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
