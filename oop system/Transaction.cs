using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Transaction
    {

        public Order Order { get; set; }
        public Payment Payment { get; set; }

        public Transaction(Order order, Payment payment)
        {
            Order = order;
            Payment = payment;
        }

        public string Details()
        {
            return $"Order {Order.OrderNumber}, Payment: {Payment.Amount}";
        }
    }

}
