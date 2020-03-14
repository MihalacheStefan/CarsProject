using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
