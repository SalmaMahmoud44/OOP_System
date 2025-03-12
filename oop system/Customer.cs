using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace oop_system
{
    public abstract class Customer
    {
        public int ID { get; set; }
        public string Phone { get; set; }

        public Customer(int _ID, string _phone)
        {
            ID = _ID;
            Phone = _phone;
        }
        public abstract string Details();
    }
    public class RegularCustomer : Customer
    {
        public RegularCustomer(int id, string phone) : base(id, phone) { }

        public override string Details()
        {
            return $"Customer - ID: {ID}, Phone: {Phone}";
        }
    }
    public class EmployeeCustomer : Customer
    {
        public EmployeeCustomer(int id, string phone) : base(id, phone) { }

        public override string Details()
        {
            return $"Employee - ID: {ID}, Phone: {Phone}";
        }
    }


}

