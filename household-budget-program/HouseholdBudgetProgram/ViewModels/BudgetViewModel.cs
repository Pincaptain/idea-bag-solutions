using Caliburn.Micro;
using HouseholdBudgetProgram.ViewModels.Base;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace HouseholdBudgetProgram.ViewModels
{
    class BudgetViewModel : BaseViewModel
    {
		private BindableCollection<CategoryViewModel> categories;

		public BindableCollection<CategoryViewModel> Categories
		{
			get => categories;
			set
			{
				categories = value;

				NotifyOfPropertyChange(() => Categories);
			}
		}

		private double budget;

		public double Budget
		{
			get => budget;
			set
			{
				if (value != budget)
				{
					budget = value;

					NotifyOfPropertyChange(() => Budget);
				}
			}
		}

		public double Spendings
		{
			get => Categories
				.Select(category => category.ProductsPrice)
				.Sum();
		}

		public double Balance
		{
			get => Budget - Spendings;
		}

		public bool IsNegative
		{
			get => Balance < 0;
		}

		public double NegativeAmount
		{
			get => IsNegative ? Math.Abs(Balance) : 0;
		}

		public BudgetViewModel()
		{
			Categories = new BindableCollection<CategoryViewModel>
			{
				new CategoryViewModel()
			};
			Categories.CollectionChanged += OnCategoriesChanged;

			Budget = 500;
		}

		private void OnCategoriesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyOfPropertyChange(() => Spendings);
			NotifyOfPropertyChange(() => Balance);
			NotifyOfPropertyChange(() => IsNegative);
			NotifyOfPropertyChange(() => NegativeAmount);
		}
	}
}
