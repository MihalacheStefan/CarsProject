using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public ICollection<string> Brands { get; set; }
    }
}
