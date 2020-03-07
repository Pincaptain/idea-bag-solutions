using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using HouseholdBudgetProgram.Models.ComponentModels;

namespace HouseholdBudgetProgram.Models
{
    class CategoryModel : Observable
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

        public BudgetModel Budget { get; }

        private ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();

		public ObservableCollection<ProductModel> Products
		{
			get => products;
			set
			{
				products = value;

				OnPropertyChanged(nameof(Products));
			}
		}

		public double ProductsPrice
		{
			get => Products
				.Select(product => product.Price)
				.Sum();
		}

		public string Description
		{
			get => $"{Name}: {ProductsPrice} {Budget.Currency}";
		}

        public CategoryModel(BudgetModel budget)
		{
			Budget = budget;
		}
    }
}
