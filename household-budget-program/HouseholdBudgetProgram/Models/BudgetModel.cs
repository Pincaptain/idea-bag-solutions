using Caliburn.Micro;
using HouseholdBudgetProgram.Models.ComponentModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HouseholdBudgetProgram.Models
{
    class BudgetModel : Observable
	{
        private string name;

		public string Name
		{
			get => name;
			set
			{
				if (value != name)
				{
					name = value;

					OnPropertyChanged(nameof(Name));
				}
			}
		}

		private string currency = "eur";

		public string Currency
		{
			get => currency;
			set
			{
				if (value != currency)
				{
					currency = value;

					OnPropertyChanged(nameof(Currency));
				}
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

					OnPropertyChanged(nameof(Budget));
				}
			}
		}

		private ObservableCollection<CategoryModel> categories = new ObservableCollection<CategoryModel>();

		public ObservableCollection<CategoryModel> Categories
		{
			get => categories;
			set
			{
				categories = value;

				OnPropertyChanged(nameof(Categories));
				OnPropertyChanged(nameof(CurrentBudget));
			}
		}

		public double CurrentBudget
		{
			get
			{
				return Budget - Categories
					.Select(category => category.ProductsPrice)
					.Sum();
			}
		}

		public bool IsNegative
		{
			get => CurrentBudget < 0;
		}

		public double NegativeAmount
		{
			get => IsNegative ? Math.Abs(CurrentBudget) : 0;
		}
    }
}
