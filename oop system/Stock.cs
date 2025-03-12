using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class Stock
    {
        List<Product> products = new List<Product>();
        public int Count => products.Count;

        public int ID { get; set; }


        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully");
        }

        public void UpdateProduct(int ID, double new_price)
        {
            var product = products.FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                product.price = new_price;
                Console.WriteLine("Product is updated successfully");
            }
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                products.Remove(product);
            }

            Console.WriteLine("Product is deleted");
        }

        public double SearchProduct(int ID)
        {
            var product = products.FirstOrDefault(p => p.ID == ID);
            return product != null ? product.price : 0;
        }
        public static void PrintStock(Stock stock)
        {
            Console.WriteLine("Stock Inventory:");
            foreach (var product in stock.products)
            {
                Console.WriteLine(product);
            }
        }
        public List<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.ID == id);
        }


    }
}
