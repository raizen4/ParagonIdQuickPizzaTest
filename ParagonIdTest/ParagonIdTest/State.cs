using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ParagonIdTest.Models;

namespace ParagonIdTest
{
    public static class State
    {
        public static Pizza CurrentPizza { get; set; }

        public static ObservableCollection<Pizza> AllOrders { get; set; }

        public static ResetState()
        {
            CurrentPizza =new Pizza();
        }
    }
}
