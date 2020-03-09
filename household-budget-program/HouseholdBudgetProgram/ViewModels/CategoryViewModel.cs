using Caliburn.Micro;
using HouseholdBudgetProgram.ViewModels.Base;
using System.Collections.Specialized;
using System.Linq;

namespace HouseholdBudgetProgram.ViewModels
{
    class CategoryViewModel : BaseViewModel
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

		private BindableCollection<ProductViewModel> products;

		public BindableCollection<ProductViewModel> Products
		{
			get => products;
			set
			{
				products = value;

				NotifyOfPropertyChange(() => Products);
			}
		}

		public double ProductsPrice
		{
			get => Products
				.Select(product => product.Price)
				.Sum();
		}

		public CategoryViewModel()
		{
			Name = "Tools";

			Products = new BindableCollection<ProductViewModel>
			{
				new ProductViewModel("Hammer", 5500),
				new ProductViewModel("Screwdriver", 15),
				new ProductViewModel("Bolt", 1)
			};
			Products.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => NotifyOfPropertyChange(() => ProductsPrice);
		}

		public CategoryViewModel(string name)
		{
			Name = name;

			Products = new BindableCollection<ProductViewModel>();
			Products.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => NotifyOfPropertyChange(() => ProductsPrice);
		}
	}
}
