using System;
using System.Collections.Generic;
using System.Text;
using ParagonIdTest.Models;

namespace ParagonIdTest
{
    interface IFacade
    {
        List<Topping> GetAvailableToppings();
    }
}
