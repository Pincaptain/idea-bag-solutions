using Caliburn.Micro;
using HouseholdBudgetProgram.Models;
using HouseholdBudgetProgram.ViewModels.Base;
using HouseholdBudgetProgram.Core.Serialization;
using Microsoft.Win32;
using System;
using System.Linq;

namespace HouseholdBudgetProgram.ViewModels
{
    class BudgetViewModel : BaseViewModel
    {
		private readonly IWindowManager windowManager = new WindowManager();

		public BudgetModel Budget { get; set; }

		private BindableCollection<CategoryViewModel> categories;

		public BindableCollection<CategoryViewModel> Categories
		{
			get => categories;
			set
			{
				categories = value;
				Budget.Categories = value
					.Select(category => category.Category)
					.ToList();

				NotifyOfPropertyChange(() => Categories);
				NotifyOfPropertyChange(() => Spendings);
				NotifyOfPropertyChange(() => Balance);
				NotifyOfPropertyChange(() => IsNegative);
				NotifyOfPropertyChange(() => NegativeAmount);
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
				NotifyOfPropertyChange(() => Spendings);
				NotifyOfPropertyChange(() => Balance);
				NotifyOfPropertyChange(() => IsNegative);
				NotifyOfPropertyChange(() => NegativeAmount);
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


		private double initialBudget;

		public double InitialBudget
		{
			get => initialBudget;
			set
			{
				initialBudget = value;
				Budget.Budget = value;

				NotifyOfPropertyChange(() => InitialBudget);
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
			get => InitialBudget - Spendings;
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
			Budget = new BudgetModel();
			Categories = new BindableCollection<CategoryViewModel>
			{
				new CategoryViewModel()
			};
			Products = new BindableCollection<ProductViewModel>();
			InitialBudget = 500;
		}

		public void NewBudget()
		{
			NewBudgetViewModel newBudget = new NewBudgetViewModel();

			windowManager.ShowDialog(newBudget);

			if (newBudget.IsSuccessful)
			{
				InitialBudget = newBudget.Budget;
				Categories = new BindableCollection<CategoryViewModel>();
				SelectedCategory = null;
				Products = new BindableCollection<ProductViewModel>();
				SelectedProduct = null;
			}
		}

		public void SaveBudget()
		{
			SaveFileDialog saveFile = new SaveFileDialog()
			{
				Filter = "HBP Files (*.hbp)|*.hbp"
			};

			bool isSuccessful = saveFile.ShowDialog() ?? false;

			if (isSuccessful)
			{
				BinarySerialization binarySerialization = new BinarySerialization();

				binarySerialization.Serialize(saveFile.FileName, Budget);
			}
		}

		public void OpenBudget()
		{
			OpenFileDialog openFile = new OpenFileDialog()
			{
				Filter = "HBP Files (*.hbp)|*.hbp"
			};

			bool isSuccessful = openFile.ShowDialog() ?? false;

			if (isSuccessful)
			{
				BinarySerialization binarySerialization = new BinarySerialization();
				BudgetModel budget = (BudgetModel) binarySerialization.Deserialize(openFile.FileName);

				Budget = budget;
				InitialBudget = budget.Budget;
				Categories = new BindableCollection<CategoryViewModel>(budget.Categories
					.Select(category => new CategoryViewModel(category.Name, new BindableCollection<ProductViewModel>(category.Products
					.Select(product => new ProductViewModel(product.Name, product.Price)))))
					.ToList());
			}
		}

		public void AddCategory()
		{
			AddCategoryViewModel addCategory = new AddCategoryViewModel();

			windowManager.ShowDialog(addCategory);

			if (addCategory.IsSuccessful)
			{
				BindableCollection<CategoryViewModel> categories = new BindableCollection<CategoryViewModel>(Categories)
				{
					new CategoryViewModel(addCategory.Name)
				};

				Categories = categories;
			}
		}

		public void RemoveCategory()
		{
			BindableCollection<CategoryViewModel> categories = new BindableCollection<CategoryViewModel>(Categories);

			categories.Remove(SelectedCategory);

			Categories = categories;
		}

		public void AddProduct()
		{
			AddProductViewModel addProduct = new AddProductViewModel();

			windowManager.ShowDialog(addProduct);

			if (addProduct.IsSuccessful)
			{
				CategoryViewModel selectedCategory = SelectedCategory;

				selectedCategory?.Products.Add(new ProductViewModel(addProduct.Name, addProduct.Price));

				SelectedCategory = selectedCategory;

				BindableCollection<CategoryViewModel> categories = new BindableCollection<CategoryViewModel>(Categories);

				categories
					.First(category => category.Equals(SelectedCategory))
					.Products = selectedCategory.Products;

				Categories = categories;
			}
		}

		public void RemoveProduct()
		{
			CategoryViewModel selectedCategory = SelectedCategory;

			selectedCategory?.Products.Remove(SelectedProduct);

			SelectedCategory = selectedCategory;

			BindableCollection<CategoryViewModel> categories = new BindableCollection<CategoryViewModel>(Categories);

			categories
				.First(category => category.Equals(SelectedCategory))
				.Products = selectedCategory.Products;

			Categories = categories;
		}
	}
}
