using HouseholdBudgetProgram.Models;
using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class ProductViewModel : BaseViewModel
    {
		public ProductModel Product { get; set; }

		private string name;

		public string Name
		{
			get => name;
			set
			{
				name = value;
				Product.Name = value;

				NotifyOfPropertyChange(() => Name);
				NotifyOfPropertyChange(() => Description);
			}
		}

		private double price;

		public double Price
		{
			get => price;
			set
			{
				price = value;
				Product.Price = value;

				NotifyOfPropertyChange(() => Price);
				NotifyOfPropertyChange(() => Description);
			}
		}

		public string Description
		{
			get
			{
				return $"{Name} {Price} eur";
			}
		}

		public ProductViewModel()
		{
			Product = new ProductModel();
			Name = string.Empty;
			Price = 0;
		}

        public ProductViewModel(string name, double price)
        {
			Product = new ProductModel(name, price);
			Name = name;
			Price = price;
        }
    }
}
