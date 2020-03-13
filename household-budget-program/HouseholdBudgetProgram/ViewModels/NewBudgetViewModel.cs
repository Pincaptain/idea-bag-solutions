using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class NewBudgetViewModel : BaseViewModel
    {
		private double budget;

		public double Budget
		{
			get => budget;
			set
			{
				budget = value;

				NotifyOfPropertyChange(() => Budget);
			}
		}

		public bool IsSuccessful { get; set; }

		public bool CanConfirm(double budget)
		{
			return budget > 0;
		}

		public void Confirm(double budget)
		{
			IsSuccessful = true;

			TryClose();
		}

		public void Cancel()
		{
			IsSuccessful = false;

			TryClose();
		}

		public NewBudgetViewModel()
		{
			Budget = 0;
			IsSuccessful = false;
		}
	}
}
