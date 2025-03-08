namespace oop_system
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.Title = "Salma";
            Console.ForegroundColor = ConsoleColor.Red;

            Stock stock = new Stock();
            Customer customer = new Customer();
            List<Transaction> transactions = new List<Transaction>();

            while (true)
            {
                Console.WriteLine("1. Data Entry");
                Console.WriteLine("2. Sales Process");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose an option: ");


                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();


                if (choice == 4)
                {
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1. Add New/Update/Delete Customer");
                        Console.WriteLine("2. Add New/Update/Delete Product in Stock");
                        Console.Write("\nChoose an option: ");


                        int Sub_Choice = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();

                        if (Sub_Choice == 1)
                        {
                            ManageCustomer(customer);
                        }
                        else if (Sub_Choice == 2)
                        {
                            ManageStock(stock);
                        }
                        break;
                    case 2:
                        Console.WriteLine("1. Add Transaction");
                        Console.WriteLine("2. Update Order");
                        Console.WriteLine("3. Pay Order");
                        Console.Write("\nChoose an option: ");

                        int Sales_Choice = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();

                        if (Sales_Choice == 1)
                        {
                            Console.WriteLine("Transaction is added");
                        }

                        else if (Sales_Choice == 2)
                        {
                            Console.WriteLine("Order is updated");
                        }

                        else if (Sales_Choice == 3)
                        {
                            Console.WriteLine("Order payed");
                        }
                        break;

                    case 3:
                        Console.WriteLine("1. Print Customers");
                        Console.WriteLine("2. Print Transactions");
                        Console.Write("\nChoose an option: ");
                        int Choice = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();

                        if (Choice == 1)
                        {
                            customer.PrintCustomers();
                        }
                        else
                        {
                            PrintTransactions(transactions);
                        }

                        break;

                    default:
                        {
                            Console.WriteLine("Invalid Option");
                            break;
                        }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ManageStock(Stock stock)
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Delete Product");
            Console.Write("\nChoose an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter ID : ");
                    int ID01 = Convert.ToInt32(Console.ReadLine());

                    stock.AddProduct(ID01);
                    Console.WriteLine("\nProduct is added successfully");
                    break;

                case 2:
                    Console.Write("Enter ID : ");
                    int ID02 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter price : ");
                    double price = Convert.ToInt32(Console.ReadLine());

                    stock.UpdateProduct(ID02, price);
                    Console.WriteLine("\nProduct's price is updated successfully");

                    break;


                case 3:
                    Console.Write("Enter ID : ");
                    int ID03 = Convert.ToInt32(Console.ReadLine());

                    stock.DeleteProduct(ID03);
                    Console.WriteLine("\nProduct is deleted from the system");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;


            }

        }

        public static void ManageCustomer(Customer customer)
        {
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Edit Customer");
            Console.WriteLine("3. Delete Customer");
            Console.Write("\nChoose an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (choice)
            {
                case 1:

                    Console.Write("Enter ID : ");
                    int ID01 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter phone : ");
                    string? phone01 = Console.ReadLine();

                    if (phone01 != null)
                    {
                        customer.AddCustomer(ID01, phone01);
                    }


                    Console.WriteLine("\nCustomer is added successfully");
                    break;

                case 2:
                    Console.Write("Enter ID : ");
                    int ID02 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter phone : ");
                    string? phone02 = Console.ReadLine();

                    customer.UpdateCustomer(ID02, phone02);
                    Console.WriteLine("\nCustomer's phone is updated successfully");

                    break;


                case 3:
                    Console.Write("Enter ID : ");
                    int ID03 = Convert.ToInt32(Console.ReadLine());

                    customer.DeleteCustomer(ID03);
                    Console.WriteLine("\nCustomer is deleted from the system");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;

            }
        }

        public static void PrintTransactions(List<Transaction> transactions)
        {
            if (transactions.Count > 0)
            {
                Console.WriteLine("List of all transactions : ");
                foreach (Transaction transaction in transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("\nNo transactions available yet");
            }
        }

        public static void PrintCustomer(List<Customer> customers)
        {
            if (customers.Count > 0)
            {
                Console.WriteLine("List of all transactions : ");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
            else
            {
                Console.WriteLine("No transactions available yet");
            }
        }

    }
}
