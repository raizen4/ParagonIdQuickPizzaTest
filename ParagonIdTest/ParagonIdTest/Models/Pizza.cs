using System.Collections.Generic;

namespace ParagonIdTest.Models
{
    public class Pizza
    {
        public Pizza(string id, string size, string crustType, List<Topping> toppings,
            string typeOfCheese, int timeToBake)
        {
            Id = id;
            CrustType = crustType;
            Size = size;
            TypeOfCheese = typeOfCheese;
            Toppings = toppings;
            TimeToBake = timeToBake;
        }

        public Pizza()
        {
        }

        public string TypeOfCheese { get; set; }
        
        public List<Topping> Toppings { get; set; }

        public string CrustType { get; set; }

        public string Size { get; set; }

        public string Id { get; set; }
        public int TimeToBake { get; set; }
    }
}