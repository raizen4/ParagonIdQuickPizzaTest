using System;
using System.Collections.Generic;
using System.Text;
using ParagonIdTest.Models;

namespace ParagonIdTest.Facade
{
    class Facade: IFacade
    {
        //Fake service call method to simulate an api call from the view-models
        public List<Topping> GetAvailableToppings()
        {
           var constantToppings=new List<Topping>
           {

           };
        }
    }
}
