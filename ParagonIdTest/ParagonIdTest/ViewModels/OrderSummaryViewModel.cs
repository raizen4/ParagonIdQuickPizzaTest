using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ParagonIdTest.Enums;
using ParagonIdTest.Models;
using ParagonIdTest.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace ParagonIdTest.ViewModels
{
    public class OrderSummaryViewModel : ViewModelBase
    {
        public DelegateCommand OrderCommand { get; set; }

        public DelegateCommand GoToToppingsCommand { get; set; }
        public string OrderId { get; set; }

        private IPageDialogService _dialogService;

        public List<Topping> Toppings { get; set; }

        public string CrustType { get; set; }

        public string Size { get; set; }

        public string TimeToBake { get; set; }

        public string CheeseType { get; set; }

        public OrderSummaryViewModel(IPageDialogService dialogService, INavigationService navigationService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            OrderId = State.CurrentPizza.Id;
            Toppings = State.CurrentPizza.Toppings;
            TimeToBake = Helpers.FormatTimeToBake(State.CurrentPizza.TimeToBake);
            CrustType = State.CurrentPizza.CrustType;
            Size = State.CurrentPizza.Size;
            CheeseType = State.CurrentPizza.TypeOfCheese;
           
            OrderCommand = new DelegateCommand(CompleteOrder);
            GoToToppingsCommand =
                new DelegateCommand(async () => await NavigationService.NavigateAsync(nameof(PizzaToppings)));
        }

    

        private void CompleteOrder()
        {
            State.CurrentPizza.Status = PizzaStatus.InProgress;
            if (State.AllOrders == null)
            {
                State.AllOrders=new List<Pizza>();
                State.AllOrders.Add(State.CurrentPizza);
            }
            else if (State.AllOrders.FirstOrDefault(pizza => pizza.Id.Equals(State.CurrentPizza.Id)) == null)
            {
                State.AllOrders.Add(State.CurrentPizza);
            }

            StartNewTimer(State.CurrentPizza);
            State.ResetCurrentPizza();
            NavigationService.NavigateAsync(nameof(MainPage));
        }

        private void StartNewTimer(Pizza pizzaForThisTimer)
        {
            var timer = new PizzaTimer
            {
                Interval = 1000,
                Data = pizzaForThisTimer
            };

            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PizzaTimer timer = (PizzaTimer)sender;
            var pizza = timer.Data;
            pizza.TimeToBake--;
            if (pizza.TimeToBake == 0)
            {
                State.AllOrders.First(foundPizza => foundPizza.Id.Equals(pizza.Id)).Status =
                    PizzaStatus.Completed;
                State.AllOrders =State.AllOrders.Where(pizzaOrder => !pizzaOrder.Id.Equals(pizza.Id)).ToList();
                timer.Stop();
                Device.BeginInvokeOnMainThread (async() =>
                {
                    await _dialogService.DisplayAlertAsync("Warm and ready",
                        $"Your order {pizza.Id} has been backed and is coming to you right now", "OK");
                });
                
             
            }

        }
    }
}