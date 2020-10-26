using System.Collections.Generic;
using ParagonIdTest.Models;

namespace ParagonIdTest.Interfaces
{
    interface IFacade
    {
        List<Topping> GetAvailableToppings();
    }
}
