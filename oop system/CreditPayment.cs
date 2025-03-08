using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class CreditPayment : Payment
    {
        public string Card_Number { get; set; } = string.Empty;
        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing credit payment of {Amount} from card {Card_Number}");
        }

    }
}
