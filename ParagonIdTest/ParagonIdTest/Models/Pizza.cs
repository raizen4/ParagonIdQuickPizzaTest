using System;
using System.Collections.Generic;
using System.Text;

namespace ParagonIdTest.Models
{
    public class Pizza
    {

        public string Name { get; set; }
        public List<Topping> Toppings { get; set; }

        public string Id { get; set; }


    }
}
