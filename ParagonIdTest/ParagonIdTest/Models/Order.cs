using System.Collections.Generic;

namespace ParagonIdTest.Models
{
    public class Order
    {
        public List<Pizza> Pizzas { get; set; }

        public string Id { get; set; }

        public int TimeToBake { get; set; }
    }
}