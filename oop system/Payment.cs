using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oop_system
{

    public abstract class Payment
    {
        public DateTime Payment_Date { get; set; }
        public double Amount { get; set; }

        public Payment(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            Amount = amount;
            Payment_Date = DateTime.Now;
        }

        public abstract void ProcessPayment();

        public override string ToString()
        {
            return $"Payment Date: {Payment_Date}, Amount: {Amount}";
        }
    }

    public class CashPayment : Payment
    {
        public CashPayment(double amount) : base(amount) { }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing cash payment of {Amount}");
        }
    }

    public class CheckPayment : Payment
    {
        public string Check_Number { get; set; }

        public CheckPayment(double amount, string checkNumber) : base(amount)
        {
            if (string.IsNullOrWhiteSpace(checkNumber))
                throw new ArgumentException("Check number cannot be empty.");

            Check_Number = checkNumber;
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing check payment of {Amount} with check number {Check_Number}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Check Number: {Check_Number}";
        }
    }

    public class CreditPayment : Payment
    {
        public string Card_Number { get; set; }

        public CreditPayment(double amount, string cardNumber) : base(amount)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length != 16)
                throw new ArgumentException("Invalid card number. Must be 16 digits.");

            Card_Number = cardNumber;
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing credit payment of {Amount} from card {Card_Number}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Card Number: {Card_Number}";
        }
    }

}
