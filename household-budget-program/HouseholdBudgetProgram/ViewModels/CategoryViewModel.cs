using Caliburn.Micro;
using HouseholdBudgetProgram.Models;
using HouseholdBudgetProgram.ViewModels.Base;

namespace HouseholdBudgetProgram.ViewModels
{
    class CategoryViewModel : BaseViewModel
    {
		private BudgetModel budget;

		public BudgetModel Budget
		{
			get => budget;
			set
			{
				budget = value;

				NotifyOfPropertyChange(() => Budget);
			}
		}

		private CategoryModel selectedCategory;

		public CategoryModel SelectedCategory
		{
			get => selectedCategory;
			set
			{
				selectedCategory = value;

				NotifyOfPropertyChange(() => SelectedCategory);
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

        public CategoryViewModel()
		{ 
			LoadBudget();
		}

        private void LoadBudget()
		{
			BudgetModel budget = new BudgetModel
			{
				Budget = 500,
				Name = "Borjan's Budget Plan",
				Currency = "eur"
			};

			BindableCollection<CategoryModel> categories = new BindableCollection<CategoryModel>
			{
				new CategoryModel(budget) { Name = "Tools" },
				new CategoryModel(budget) { Name = "Furniture" },
				new CategoryModel(budget) { Name = "Toys" }
			};

			BindableCollection<ProductModel> tools = new BindableCollection<ProductModel>
			{
				new ProductModel(categories[0]) { Name = "Hammer", Price = 10.0f },
				new ProductModel(categories[0]) { Name = "Screwdriver", Price = 20.0f }
			};

			BindableCollection<ProductModel> furniture = new BindableCollection<ProductModel>()
			{
				new ProductModel(categories[1]) { Name = "Sofa", Price = 50.0f }
			};

			BindableCollection<ProductModel> toys = new BindableCollection<ProductModel>()
			{
				new ProductModel(categories[2]) { Name = "Dragon", Price = 25.0f }
			};

			categories[0].Products = tools;
			categories[1].Products = furniture;
			categories[2].Products = toys;

			budget.Categories = categories;

			Budget = budget;
		}

		public void AddCategory()
		{

		}

		public void RemoveCategory()
		{
			Budget.Categories.Remove(SelectedCategory);
		}

		public void AddProduct()
		{

		}

		public void RemoveProduct()
		{
			SelectedCategory.Products.Remove(SelectedProduct);
		}
    }
}
