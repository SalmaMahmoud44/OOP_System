using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class CustomerManager
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer()
        {
            Console.Write("Enter Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            
            if (customers.Any(c => c.ID == id))
            {
                Console.WriteLine($"Error: Customer with ID {id} already exists!");
                return;
            }

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Customer Type (Person/Employee): ");
            string type = Console.ReadLine().ToLower();

            if (type == "person")
            {
                customers.Add(new RegularCustomer(id, phone));
                Console.WriteLine("Regular customer added successfully.");
            }
            else if (type == "employee")
            {
                customers.Add(new EmployeeCustomer(id, phone));
                Console.WriteLine("Employee added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid type! Please enter 'Regular' or 'Employee'.");
            }
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter Customer ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer != null)
            {
                Console.Write("Enter New Phone Number: ");
                string newPhone = Console.ReadLine();
                customer.Phone = newPhone;
                Console.WriteLine("Customer updated successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void DeleteCustomer()
        {
            Console.Write("Enter Customer ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer != null)
            {
                customers.Remove(customer);
                Console.WriteLine("Customer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void PrintCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available yet.");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Details());
            }
        }
        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.ID == id);
        }
    }
}
