using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ParagonIdTest.Models;

namespace ParagonIdTest
{
    public static class State
    {
        public static Pizza CurrentPizza { get; set; }

        public static List<Pizza> AllOrders { get; set; }

        public static int UserOverrideTimeToBake { get; set; }

        public static void ResetCurrentPizza()
        {
            CurrentPizza = new Pizza();
        }
    }
}