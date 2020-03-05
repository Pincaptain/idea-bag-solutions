using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HouseholdBudgetProgram.Models.ComponentModels;

namespace HouseholdBudgetProgram.Models
{
    class CategoryModel : Observable
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

		private BindableCollection<ProductModel> products;

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
			get => $"{Name}: {ProductsPrice} {BudgetModel.Instance.Currency}";
		}

		public CategoryModel()
		{
			LoadProducts();
		}

		private void LoadProducts()
		{
			BindableCollection<ProductModel> products = new BindableCollection<ProductModel>();

			Products = products;
		}
	}
}
