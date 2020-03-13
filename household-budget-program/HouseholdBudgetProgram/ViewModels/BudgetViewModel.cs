using Caliburn.Micro;
using HouseholdBudgetProgram.ViewModels.Base;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace HouseholdBudgetProgram.ViewModels
{
    class BudgetViewModel : BaseViewModel
    {
		private readonly IWindowManager windowManager = new WindowManager();

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
				NotifyOfPropertyChange(() => Spendings);
				NotifyOfPropertyChange(() => Balance);
				NotifyOfPropertyChange(() => IsNegative);
				NotifyOfPropertyChange(() => NegativeAmount);
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

		public void NewBudget()
		{
			NewBudgetViewModel newBudget = new NewBudgetViewModel();

			windowManager.ShowDialog(newBudget);

			if (newBudget.IsSuccessful)
			{
				Budget = newBudget.Budget;
			}
		}

		public void AddCategory()
		{
			AddCategoryViewModel addCategory = new AddCategoryViewModel();

			windowManager.ShowDialog(addCategory);

			if (addCategory.IsSuccessful)
			{
				Categories.Add(new CategoryViewModel(addCategory.Name));
			}
		}

		public void RemoveCategory()
		{
			Categories?.Remove(SelectedCategory);
		}

		public void AddProduct()
		{
			AddProductViewModel addProduct = new AddProductViewModel();

			windowManager.ShowDialog(addProduct);

			if (addProduct.IsSuccessful)
			{
				SelectedCategory.Products.Add(new ProductViewModel(addProduct.Name, addProduct.Price));
			}
		}

		public void RemoveProduct()
		{
			Products?.Remove(SelectedProduct);
		}
	}
}
