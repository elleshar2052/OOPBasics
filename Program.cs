using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(new[] {'=', ';'}, StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(new[] {'=', ';'}, StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            for (int i = 0; i < peopleInput.Length; i += 2)
            {
                string name = peopleInput[i];
                int money = int.Parse(peopleInput[i + 1]);
                try
                {
                    people.Add(new Person(name, money));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            for (int i = 0; i < productsInput.Length; i += 2)
            {
                string name = productsInput[i];
                int cost = int.Parse(productsInput[i + 1]);
                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "END")
                {
                    break;
                }

                string name = command[0];
                string productName = command[1];
                Person person = people.Where(n => n.Name == name).First();
                Product product = products.Where(n => n.Name == productName).First();
                if (person.Money < product.Cost)
                {
                    Console.WriteLine($"{name} can't afford {productName}");
                }
                else
                {
                    person.Money -= product.Cost;
                    person.AddProduct(product);
                    Console.WriteLine($"{name} bought {productName}");
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Count <= 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.SeeBag().Select(k => k.Name))}");
                    
                }
            }
        }
    }
}

