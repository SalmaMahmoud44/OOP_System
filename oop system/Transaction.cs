using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class Transaction
    {
        public Order Order { get; set; }
        public Payment Payment { get; set; }

        public Transaction(Order order, Payment payment)
        {
            Order = order;
            Payment = payment;

            foreach (var item in Order.Items)
            {
                item.Product.quantity -= item.Quantity; 
            }
        }

        public static Transaction operator +(Transaction transaction, (Order order, Payment payment) newTransaction)
        {
            return new Transaction(newTransaction.order, newTransaction.payment);
        }

        public override string ToString()
        {
            return $"Order {Order.OrderNumber}, Payment: {Payment.Amount}";
        }
    }

    public class TransactionsCollection
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public static TransactionsCollection operator +(TransactionsCollection collection, Transaction transaction)
        {
            collection.AddTransaction(transaction);
            return collection;
        }

        public override string ToString()
        {
            string result = "Transactions:\n";
            foreach (var transaction in transactions)
            {
                result += transaction.ToString() + "\n";
            }
            return result;
        }
    }


}
