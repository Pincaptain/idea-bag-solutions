using Caliburn.Micro;
using HouseholdBudgetProgram.Models;
using HouseholdBudgetProgram.ViewModels.Base;
using System.Collections.Specialized;
using System.Linq;

namespace HouseholdBudgetProgram.ViewModels
{
    class CategoryViewModel : BaseViewModel
    {
		public CategoryModel Category { get; set; }

		private string name;

		public string Name
		{
			get => name;
			set
			{
				name = value;
				Category.Name = value;

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
				Category.Products = value
					.Select(product => product.Product)
					.ToList();

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
			Category = new CategoryModel();
			Name = "Tools";

			Products = new BindableCollection<ProductViewModel>
			{
				new ProductViewModel("Hammer", 5500),
				new ProductViewModel("Screwdriver", 15),
				new ProductViewModel("Bolt", 1)
			};
			Products.CollectionChanged += OnProductsChanged;
		}

		public CategoryViewModel(string name)
		{
			Category = new CategoryModel(name);
			Name = name;

			Products = new BindableCollection<ProductViewModel>();
			Products.CollectionChanged += OnProductsChanged;
		}

		public CategoryViewModel(string name, BindableCollection<ProductViewModel> products)
		{
			Category = new CategoryModel(name);
			Name = name;

			Products = products;
			Products.CollectionChanged += OnProductsChanged;
		}

		private void OnProductsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyOfPropertyChange(() => ProductsPrice);
		}
	}
}
