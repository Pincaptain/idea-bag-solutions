using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HouseholdBudgetProgram.Models;
using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class CategoryViewModel : BaseViewModel
    {
		#region Properties
		private BudgetModel budget;

		public BudgetModel Budget
		{
			get => budget;
			set
			{
				budget = value;
				Categories = Budget.Categories;

				NotifyOfPropertyChange(() => Budget);
			}
		}

		private BindableCollection<CategoryModel> categories;

		public BindableCollection<CategoryModel> Categories
		{
			get => categories;
			set
			{
				categories = value;

				NotifyOfPropertyChange(() => Categories);
			}
		}

		private CategoryModel selectedCategory;

		public CategoryModel SelectedCategory
		{
			get => selectedCategory;
			set
			{
				selectedCategory = value;
				Products = SelectedCategory?.Products;

				NotifyOfPropertyChange(() => SelectedCategory);
			}
		}

		private BindableCollection<ProductModel> products;

		public BindableCollection<ProductModel> Products
		{
			get => products;
			set
			{
				products = value;

				NotifyOfPropertyChange(() => Products);
			}
		}

		private ProductModel selectedProduct;

		public ProductModel SelectedProduct
		{
			get => selectedProduct;
			set
			{
				selectedProduct = value;

				NotifyOfPropertyChange(() => SelectedProduct);
			}
		}
        #endregion

        #region Constructor
        public CategoryViewModel()
		{
			LoadProducts();
			LoadCategories();
			LoadBudget();
		}
        #endregion

        #region Initializers
        private void LoadBudget()
		{
			BindableCollection<ProductModel> tools = new BindableCollection<ProductModel>
			{
				new ProductModel { Name = "Hammer", Price = 10.0f },
				new ProductModel { Name = "Screwdriver", Price = 20.0f }
			};

			BindableCollection<ProductModel> furniture = new BindableCollection<ProductModel>()
			{
				new ProductModel { Name = "Sofa", Price = 50.0f }
			};

			BindableCollection<ProductModel> toys = new BindableCollection<ProductModel>()
			{
				new ProductModel { Name = "Dragon", Price = 25.0f }
			};

			BindableCollection<CategoryModel> categories = new BindableCollection<CategoryModel>
			{
				new CategoryModel { Name = "Tools", Products = tools },
				new CategoryModel { Name = "Furniture", Products = furniture },
				new CategoryModel { Name = "Toys", Products = toys }
			};

			BudgetModel budget = BudgetModel.Instance;

			budget.Categories = categories;
			budget.Budget = 500;
			budget.Name = "Borjan's Budget Plan";

			Budget = budget;
		}

		private void LoadCategories()
		{
			BindableCollection<CategoryModel> categories = new BindableCollection<CategoryModel>();

			Categories = categories;
		}

		private void LoadProducts()
		{
			BindableCollection<ProductModel> products = new BindableCollection<ProductModel>();

			Products = products;
		}
        #endregion
    }
}
