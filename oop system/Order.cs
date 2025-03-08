using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{

    public class Order
    {
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }

        public double total_order_amount { get; set; }



        public Order(double _total_order_amount)
        {
            OrderNumber = new Random().Next(1, 100000);
            OrderDate = DateTime.Now;
            Items = new List<OrderItem>();
            total_order_amount = _total_order_amount;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }


        public string Details()
        {
            return $"ID = {ID}, Order Number: {OrderNumber}, Date Time: {OrderDate}";
        }

        public void printItems()
        {
            Console.WriteLine("List of all items : ");
            foreach (var items in Items)
            {
                Console.WriteLine(items);
            }
        }
    }
}
