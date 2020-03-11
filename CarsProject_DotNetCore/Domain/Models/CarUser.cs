using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class CarUser
    {
        [Key]
        public Guid CarUserId { get; set; }

        [Required]
        [ForeignKey("Car")]
        public Guid CarId { get; set; }

        public virtual Car Car { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
