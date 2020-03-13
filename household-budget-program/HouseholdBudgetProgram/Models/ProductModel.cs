using System;

namespace HouseholdBudgetProgram.Models
{
    [Serializable]
    class ProductModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public ProductModel()
        {
            Name = string.Empty;
            Price = 0;
        }

        public ProductModel(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
