using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tenant
    {
        private string _name;
        public string Name 
        { 
            get { return _name; }
        }

        private int _phoneNo;
        public int PhoneNo 
        { 
            get { return _phoneNo; }
        }

        private string _email;
        public string Email 
        { 
            get { return _email; }
        }

        private int _accountNo;
        public int AccountNo 
        { 
            get { return _accountNo; }
        }

        private double _accountBalance;
        public double AccountBalance 
        { 
            get { return _accountBalance; }
        }

        public void Anonymize()
        {
        }
    }
}
