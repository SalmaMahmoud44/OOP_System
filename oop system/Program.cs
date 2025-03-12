namespace oop_system
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stock stock = new Stock();
            CustomerManager customerManager = new CustomerManager();
            List<Transaction> transactions = new List<Transaction>();

            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Data Entry");
                Console.WriteLine("   1. Add New/Update/Delete Customer");
                Console.WriteLine("   2. Add New/Update/Delete Product in Stock");
                Console.WriteLine("2. Sales Process");
                Console.WriteLine("   1. Add Transaction");
                Console.WriteLine("   2. Update Order");
                Console.WriteLine("   3. Pay Order");
                Console.WriteLine("3. Print");
                Console.WriteLine("   1. Customers");
                Console.WriteLine("   2. Stock Data");
                Console.WriteLine("   3. Transactions");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "4") break;

                switch (choice)
                {
                    case "1.1":
                        ManageCustomers(customerManager);
                        break;
                    case "1.2":
                        ManageStock(stock);
                        break;
                    case "2.1":
                        ProcessTransaction(customerManager, stock, transactions);
                        break;
                    case "2.2":
                        UpdateOrder(transactions);
                        break;
                    case "2.3":
                        PayOrder(transactions);
                        break;
                    case "3.1":
                        customerManager.PrintCustomers();
                        break;
                    case "3.2":
                        Stock.PrintStock(stock);                
                        break;
                    case "3.3":
                        PrintTransactions(transactions);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.Clear();

            }
        }
        static void ManageCustomers(CustomerManager customerManager)
        {
            while (true)
            {
                Console.WriteLine("\n--- Manage Customers ---");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Print Customers");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        customerManager.AddCustomer();
                        break;
                    case "2":
                        customerManager.UpdateCustomer();
                        break;
                    case "3":
                        customerManager.DeleteCustomer();
                        break;
                    case "4":
                        customerManager.PrintCustomers();
                        break;
                    case "5":
                        return; 
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void ManageStock(Stock stock)
        {
            while (true)
            {
                Console.WriteLine("\n--- Stock Management ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Search Product");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Product Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Enter Product Quantity: ");
                        double quantity = double.Parse(Console.ReadLine());

                        stock.AddProduct(new Product(id, name, price, quantity)); 
                        break;

                    case "2":
                        Console.Write("Enter Product ID to update: ");
                        int updateID = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Price: ");
                        double newPrice = double.Parse(Console.ReadLine());

                        stock.UpdateProduct(updateID, newPrice);
                        break;

                    case "3":
                        Console.Write("Enter Product ID to Delete: ");
                        int deleteID = int.Parse(Console.ReadLine());

                        stock.DeleteProduct(deleteID);
                        break;

                    case "4":
                        Console.Write("Enter Product ID to Search: ");
                        int searchID = int.Parse(Console.ReadLine());

                        double foundPrice = stock.SearchProduct(searchID);
                        if (foundPrice > 0)
                            Console.WriteLine($"Product Found! Price: {foundPrice}");
                        else
                            Console.WriteLine("Product not found.");
                        break;

                    case "5":
                        Console.WriteLine("\n--- All Products ---");
                        foreach (var product in stock.GetProducts()) 
                        {
                            Console.WriteLine($"ID: {product.ID}, Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}");
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        static void ProcessTransaction(CustomerManager customerManager, Stock stock, List<Transaction> transactions)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            var customer = customerManager.GetCustomerById(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Order order = new Order();
            while (true)
            {
                Console.Write("Enter Product ID (or type 'exit' to finish): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit") break;

                if (!int.TryParse(input, out int productId))
                {
                    Console.WriteLine("Invalid input! Please enter a valid Product ID or 'exit' to finish.");
                    continue;
                }

                var product = stock.GetProductById(productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found!");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity;
                if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity! Please enter a positive number.");
                    continue;
                }

                if (quantity > product.quantity)
                {
                    Console.WriteLine("Not enough stock available!");
                    continue;
                }
            
            order.AddItem(new OrderItem(product.price, product, quantity));
            }

            transactions.Add(new Transaction(order, null));
            Console.WriteLine("Transaction added successfully.");
        }

        static void UpdateOrder(List<Transaction> transactions)
        {
            Console.Write("Enter Order ID to update: ");
            int orderId = int.Parse(Console.ReadLine());

            var transaction = transactions.Find(t => t.Order.ID == orderId);
            if (transaction == null)
            {
                Console.WriteLine("Order not found!");
                return;
            }

            Console.Write("Enter new status (new, hold, paid, canceled): ");
            string status = Console.ReadLine();
            transaction.Order.UpdateOrderStatus(Enum.Parse<OrderStatus>(status, true));
            Console.WriteLine("Order status updated.");
        }
        static void PayOrder(List<Transaction> transactions)
        {
            Console.Write("Enter Order ID to pay: ");
            int orderId = int.Parse(Console.ReadLine());

            var transaction = transactions.Find(t => t.Order.ID == orderId);
            if (transaction == null)
            {
                Console.WriteLine("Order not found!");
                return;
            }

            Console.Write("Enter Payment Type (Cash, Check, Credit): ");
            string paymentType = Console.ReadLine().ToLower();

            Payment payment = null;
            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());

            if (paymentType == "cash")
                payment = new CashPayment(amount);
            else if (paymentType == "check")
            {
                Console.Write("Enter Check Number: ");
                string checkNumber = Console.ReadLine();
                payment = new CheckPayment(amount, checkNumber);
            }
            else if (paymentType == "credit")
            {
                Console.Write("Enter Card Number: ");
                string cardNumber = Console.ReadLine();
                payment = new CreditPayment(amount, cardNumber);
            }
            else
            {
                Console.WriteLine("Invalid payment type!");
                return;
            }

            transaction.Payment = payment;
            transaction.Payment.ProcessPayment();
            Console.WriteLine("Payment processed successfully.");
        }

        static void PrintTransactions(List<Transaction> transactions)
        {
            Console.WriteLine("\n--- Transactions ---");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

    }
}
