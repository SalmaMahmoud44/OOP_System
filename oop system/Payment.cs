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
        public abstract void ProcessPayment();
    }

}
