using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class AddCategoryViewModel : BaseViewModel
    {
        private string  name;

        public string Name
        {
            get => name;
            set
            {
                name = value;

                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool IsSuccessful { get; set; }

        public bool CanAdd(string name) => !string.IsNullOrWhiteSpace(name);

        public void Add(string name)
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
