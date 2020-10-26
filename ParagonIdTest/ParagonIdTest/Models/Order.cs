using System;
using System.Collections.Generic;
using System.Text;

namespace ParagonIdTest.Models
{
    public class Order
    {
        public Pizza Pizza { get; set; }

        public string Id { get; set; }

        public int TimeToBake { get; set; }
    }
}