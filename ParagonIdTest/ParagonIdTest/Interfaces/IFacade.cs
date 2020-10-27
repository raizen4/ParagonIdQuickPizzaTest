using System.Collections.Generic;
using ParagonIdTest.Models;

namespace ParagonIdTest.Interfaces
{
    public interface IFacade
    {
        List<Topping> GetAvailableToppings();
    }
}
