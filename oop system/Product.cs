using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class Product
    {

        public int ID { get; set; }

        public string number { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }


        public Product(int _ID, string _number, string _name, double _price, double _quantity)
        {
            ID = _ID;
            number = _number;
            name = _name;
            price = _price;
            quantity = _quantity;
        }

        public string Details()
        {
            return $"ID: {ID}, Name: {name}, Number = {number}, Price: {price}, Quantity = {quantity}";
        }

        public void Update(int new_price)
        {
            price = new_price;
            Console.WriteLine("Product is updated");
        }
    }
}

