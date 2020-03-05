using Caliburn.Micro;
using HouseholdBudgetProgram.Models.ComponentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBudgetProgram.Models
{
    sealed class BudgetModel : Observable
    {
		private static readonly Lazy<BudgetModel> lazy = new Lazy<BudgetModel>(() => new BudgetModel());

		public static BudgetModel Instance
		{
			get => lazy.Value;
		}

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

		private BindableCollection<CategoryModel> categories;

		public BindableCollection<CategoryModel> Categories
		{
			get => categories;
			set
			{
				categories = value;

				OnPropertyChanged(nameof(Categories));
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

		private BudgetModel()
		{
			LoadCategories();
		}

		private void LoadCategories()
		{
			BindableCollection<CategoryModel> categories = new BindableCollection<CategoryModel>();

			Categories = categories;
		}
	}
}
