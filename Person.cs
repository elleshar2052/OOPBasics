using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        
        public int Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public List<Product> SeeBag()
        {
            return Products;
        }
    }
}
