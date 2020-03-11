﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class EngineDTO
    {
        public string Description { get; set; }
        public int CylindersNumber { get; set; }
        public IEnumerable<CarDTO> Cars { get; set; }
    }
}
