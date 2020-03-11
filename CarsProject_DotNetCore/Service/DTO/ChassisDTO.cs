using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class ChassisDTO
    {
        public string Description { get; set; }
        public string CodeNumber { get; set; } 
        public IEnumerable<CarDTO> Cars { get; set; }
    }
}
