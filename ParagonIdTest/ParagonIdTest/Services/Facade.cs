using System.Collections.Generic;
using ParagonIdTest.Interfaces;
using ParagonIdTest.Models;

namespace ParagonIdTest.Services
{
    class Facade: IFacade
    {
        //Fake service call method to simulate an api call from the view-models
        public List<Topping> GetAvailableToppings()
        {
           var constantToppings=new List<Topping>
           {
               new Topping
               {
                   Id = Helpers.RandomString(),
                   Name = "Ham"
               },
               new Topping
               {
                   Id =Helpers.RandomString(),
                   Name = "Onions"
               },
               new Topping
               {
                   Id = Helpers.RandomString(),
                   Name = "Sweetcorn"
               },
               new Topping
               {
                   Id = Helpers.RandomString(),
                   Name = "Chicken Breast Strips"
               },
               new Topping
               {
                   Id =Helpers.RandomString(),
                   Name = "Mushrooms"
               },
               new Topping
               {
                   Id = Helpers.RandomString(),
                   Name = "Smoked Bacon"
               },
               new Topping
               {
                   Id = Helpers.RandomString(),
                   Name = "Red And Green Peppers"
               },
               new Topping
               {
                   Id = Helpers.RandomString(),
                   Name = "Tuna"
               }
           };
           return constantToppings;
        }
    }
}
