﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineApi.Models
{
    public class Cart
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
    }
}
