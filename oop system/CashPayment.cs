using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class CashPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing cash payment of {Amount}");
        }
    }
    
}
