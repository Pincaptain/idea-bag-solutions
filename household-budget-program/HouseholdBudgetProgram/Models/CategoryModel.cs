using System;
using System.Collections.Generic;

namespace HouseholdBudgetProgram.Models
{
    [Serializable]
    class CategoryModel
    {
        public string Name { get; set; }

        public List<ProductModel> Products { get; set; }

        public CategoryModel()
        {
            Name = string.Empty;
            Products = new List<ProductModel>();
        }

        public CategoryModel(string name)
        {
            Name = name;
        }

        public CategoryModel(string name, List<ProductModel> products)
        {
            Name = name;
            Products = products;
        }
    }
}
