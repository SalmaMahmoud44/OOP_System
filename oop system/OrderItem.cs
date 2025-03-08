using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class OrderItem
    {
        public double salesPrice { get; set; }
        public Product Product { get; set; }


        public OrderItem(double _sales_price, Product _product)
        {
            salesPrice = _sales_price;
            Product = _product;
        }

        public void Update(double new_quantity)
        {
            Product.quantity = new_quantity;
            Console.WriteLine("Item is updated");
        }

        public string Details()
        {
            return $"Sales Price = {salesPrice}, Quantity: {Product.quantity}";
        }

    }
}
