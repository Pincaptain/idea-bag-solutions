using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class AddProductViewModel : BaseViewModel
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;

                NotifyOfPropertyChange(() => Name);
            }
        }

        private double price;

        public double Price
        {
            get => price;
            set
            {
                price = value;

                NotifyOfPropertyChange(() => Price);
            }
        }

        public bool IsSuccessful { get; set; }

        public bool CanAdd(string name, double price)
        {
            bool isNameValid = !string.IsNullOrWhiteSpace(name);
            bool isPriceValid = price > 0;

            return isNameValid && isPriceValid;
        }

        public void Add(string name, double price)
        {
            IsSuccessful = true;

            TryClose();
        }

        public void Cancel()
        {
            IsSuccessful = false;

            TryClose();
        }
    }
}
