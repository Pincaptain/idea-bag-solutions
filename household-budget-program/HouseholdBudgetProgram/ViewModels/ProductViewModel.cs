using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class ProductViewModel : BaseViewModel
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (value != Name)
                {
                    name = value;

                    NotifyOfPropertyChange(() => Name);
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }

        private double price;

        public double Price
        {
            get => price;
            set
            {
                if (value != Price)
                {
                    price = value;

                    NotifyOfPropertyChange(() => Price);
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }

        public string Description
        {
            get
            {
                return $"{Name} {Price} eur";
            }
        }

        public ProductViewModel() { }

        public ProductViewModel(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
