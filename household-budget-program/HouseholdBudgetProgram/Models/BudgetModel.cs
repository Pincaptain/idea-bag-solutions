using System;
using System.Collections.Generic;

namespace HouseholdBudgetProgram.Models
{
    [Serializable]
    class BudgetModel
    {
        public double Budget { get; set; }

        public List<CategoryModel> Categories { get; set; }

        public BudgetModel()
        {
            Budget = 0;
            Categories = new List<CategoryModel>();
        }

        public BudgetModel(double budget)
        {
            Budget = budget;
        }

        public BudgetModel(double budget, List<CategoryModel> categories)
        {
            Budget = budget;
            Categories = categories;
        }
    }
}
