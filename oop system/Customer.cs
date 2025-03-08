using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class Customer
    {
        public List<Customer> customers = new List<Customer>();
        public int ID { get; set; }
        public string Phone { get; set; }

        public Customer() { }
        public Customer(int _ID, string _phone)
        {
            ID = _ID;
            Phone = _phone;
        }

        public void AddCustomer(int id, string _phone)
        {
            ID = id;
            Phone = _phone;
        }

        public void UpdateCustomer(int ID, string new_phone)
        {
            var customer = customers.FirstOrDefault(p => p.ID == ID);
            if (customer != null)
            {
                customer.Phone = new_phone;
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(p => p.ID == id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }

        public void PrintCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available yet");
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public int SearchCustomers(int ID)
        {
            var customer = customers.FirstOrDefault(c => c.ID == ID);
            return customer != null ? customer.ID : 0;
        }




        public string Details()
        {
            return $"ID: {ID}, Phone: {Phone}";
        }
    }
}

