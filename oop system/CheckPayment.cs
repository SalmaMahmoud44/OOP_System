using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public class CheckPayment : Payment
    {
        public string Check_Number { get; set; } = string.Empty;
        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing check payment of {Amount} with check {Check_Number}");
        }

    }
}
