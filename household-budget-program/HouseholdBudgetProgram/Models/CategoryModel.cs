using System.Linq;
using Caliburn.Micro;
using HouseholdBudgetProgram.Models.ComponentModels;

namespace HouseholdBudgetProgram.Models
{
    class CategoryModel : Observable
    {
        #region Properties
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

        private BindableCollection<ProductModel> products = new BindableCollection<ProductModel>();

		public BindableCollection<ProductModel> Products
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
        #endregion

        #region Constructor
        public CategoryModel(BudgetModel budget)
		{
			Budget = budget;
		}
        #endregion
    }
}
