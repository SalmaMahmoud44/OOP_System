using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{

    public enum OrderStatus
    {
        New,
        Hold,
        Paid,
        Canceled
    }

    public class Order
    {
        public int ID { get; set; }
        public int OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public double TotalOrderAmount { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order()
        {
            OrderNumber = new Random().Next(1, 100000);
            OrderDate = DateTime.Now;
            Items = new List<OrderItem>();
            TotalOrderAmount = 0;
            Status = OrderStatus.New;
        }

        public void AddItem(OrderItem item)
        {
            if (item != null)
            {
                Items.Add(item);
                TotalOrderAmount += item.SalesPrice * item.Product.quantity;
            }
        }

        public void UpdateOrderStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
        public void EditOrder(DateTime newDate)
        {
            OrderDate = newDate;
        }

        public override string ToString()
        {
            return $"Order ID: {ID}, Order Number: {OrderNumber}, Date: {OrderDate}, Status: {Status}, Total: {TotalOrderAmount:C2}";
        }

        public void PrintItems()
        {
            Console.WriteLine("List of Items:");
            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
