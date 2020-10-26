using System.Collections.Generic;
using ParagonIdTest.Enums;

namespace ParagonIdTest.Models
{
    public class Pizza
    {
        public Pizza(string name, string id, PizzaSize size, PizzaCrust crustType, List<Topping> toppings)
        {
            Id = id;
            CrustType = crustType;
            Size = size;
            Toppings = toppings;
            Name = name;
        }
        public string Name { get; set; }
        public List<Topping> Toppings { get; set; }

        public PizzaCrust CrustType { get; set; }

        public PizzaSize Size { get; set; }

        public string Id { get; set; }
    }
}