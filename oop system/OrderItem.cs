using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class OrderItem
    {
        public double SalesPrice { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; } 

        public OrderItem(double salesPrice, Product product, int quantity)
        {
            if (salesPrice < 0)
                throw new ArgumentException("Sales price cannot be negative!");

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity < 0 || quantity > product.quantity)
                throw new ArgumentException("Invalid quantity!");

            SalesPrice = salesPrice;
            Product = product;
            Quantity = quantity;
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
            {
                Console.WriteLine("Error: Quantity cannot be negative!");
                return;
            }

            if (newQuantity <= Product.quantity)
            {
                Quantity = newQuantity;
                Console.WriteLine("Item quantity updated successfully.");
            }
            else
            {
                Console.WriteLine("Error: Not enough stock available!");
            }
        }

        public static OrderItem operator ++(OrderItem item)
        {
            if (item.Quantity < item.Product.quantity)
            {
                item.Quantity++;
            }
            else
            {
                Console.WriteLine("Error: Not enough stock available!");
            }
            return item;
        }

        public static OrderItem operator --(OrderItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                Console.WriteLine("Error: Quantity cannot be less than 1!");
            }
            return item;
        }

        public static OrderItem operator +(OrderItem item, int amount)
        {
            if (item.Quantity + amount <= item.Product.quantity)
            {
                item.Quantity += amount;
            }
            else
            {
                Console.WriteLine("Error: Not enough stock available!");
            }
            return item;
        }

        public static OrderItem operator -(OrderItem item, int amount)
        {
            if (item.Quantity - amount >= 1)
            {
                item.Quantity -= amount;
            }
            else
            {
                Console.WriteLine("Error: Quantity cannot be less than 1!");
            }
            return item;
        }

        public override string ToString()
        {
            return $"Product: {Product.name}, Sales Price: {SalesPrice:C2}, Quantity: {Quantity}";
        }
    }

}
