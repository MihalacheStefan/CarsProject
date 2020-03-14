using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        [Required] [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CarUser> CarsUsers { get; set; }
             
    }
}