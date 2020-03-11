using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Car
    {
        [Required] [Key]
        public Guid CarId { get; set; }

        public virtual Chassis Chassis { get; set; }

        public string Brand { get; set; }
 
        public virtual Engine Engine { get; set; }

        public virtual ICollection<CarUser> CarsUsers { get; set; }

    }
}