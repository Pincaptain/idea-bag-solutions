using HouseholdBudgetProgram.Models.ComponentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public string Description
		{
			get => $"{Name}: {Price} {BudgetModel.Instance.Currency}";
		}
	}
}
