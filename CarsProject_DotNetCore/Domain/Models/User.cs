using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        public User()
        {
            CarsUsers = new HashSet<CarUser>();
        }
        [Required] [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CarUser> CarsUsers { get; set; }
             
    }
}