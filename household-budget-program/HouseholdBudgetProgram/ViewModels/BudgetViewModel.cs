using Caliburn.Micro;
using HouseholdBudgetProgram.ViewModels.Base;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace HouseholdBudgetProgram.ViewModels
{
    class BudgetViewModel : BaseViewModel
    {
		private int counter;

		public int Counter
		{
			get { return counter; }
			set { counter = value; NotifyOfPropertyChange(() => Counter); }
		}


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

		private CategoryViewModel selectedCategory;

		public CategoryViewModel SelectedCategory
		{
			get => selectedCategory;
			set
			{
				selectedCategory = value;

				Products = SelectedCategory?.Products;
				if (Products != null)
				{
					Products.CollectionChanged += OnProductsChanged;
				}

				NotifyOfPropertyChange(() => SelectedCategory);
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

		private ProductViewModel selectedProduct;

		public ProductViewModel SelectedProduct
		{
			get => selectedProduct;
			set
			{
				selectedProduct = value;

				NotifyOfPropertyChange(() => SelectedProduct);
			}
		}


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

			Products = new BindableCollection<ProductViewModel>();
			Products.CollectionChanged += OnProductsChanged;

			Budget = 500;
		}

		private void OnCategoriesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyOfPropertyChange(() => Spendings);
			NotifyOfPropertyChange(() => Balance);
			NotifyOfPropertyChange(() => IsNegative);
			NotifyOfPropertyChange(() => NegativeAmount);
		}

		private void OnProductsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyOfPropertyChange(() => Spendings);
			NotifyOfPropertyChange(() => Balance);
			NotifyOfPropertyChange(() => IsNegative);
			NotifyOfPropertyChange(() => NegativeAmount);
		}

		public void RemoveProduct()
		{
			Products?.Remove(SelectedProduct);
		}

		public void RemoveCategory()
		{
			Categories?.Remove(SelectedCategory);
		}
	}
}
