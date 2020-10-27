using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ParagonIdTest.Enums;

namespace ParagonIdTest.Models
{
    public class Pizza: INotifyPropertyChanged 
    {
        private int _timeToBake;
        private PizzaStatus _status;

        public string TypeOfCheese { get; set; }

        public List<Topping> Toppings { get; set; }

        public PizzaStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();

            }
        }
        public string CrustType { get; set; }

        public string Size { get; set; }

        public string Id { get; set; }
        public int TimeToBake
        {
            get=>_timeToBake;
            set
            {
                _timeToBake = value;
                OnPropertyChanged();

            }
        }

        public Pizza()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}