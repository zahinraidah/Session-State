using System;
using System.Collections.Generic;

namespace CartManagement.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Dictionary<string, int> items { get; set; }
    }
}
