using HouseholdBudgetProgram.Models.ComponentModels;

namespace HouseholdBudgetProgram.Models
{
    class ProductModel : Observable
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

		private double price;

		public double Price
		{
			get => price;
			set
			{
				if (value != price)
				{
					price = value;

					OnPropertyChanged(nameof(Price));
				}
			}
		}

		public CategoryModel Category { get; }

		public string Description
		{
			get => $"{Name}: {Price} {Category.Budget.Currency}";
		}

        public ProductModel(CategoryModel category)
		{
			Category = category;
		}
    }
}
