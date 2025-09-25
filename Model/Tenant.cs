using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class Tenant
{
    private int _tenantId;
    public int TenantId 
    { 
        get { return _tenantId; }
    }

    private string _name;
    public string Name 
    { 
        get { return _name; }
    }

    private string _phoneNo;
    public string PhoneNo 
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

    private decimal _accountBalance;
    public decimal AccountBalance 
    { 
        get { return _accountBalance; }
    }

    public Tenant(/*int tenantId,*/ string name, string phoneNo, string email, int accountNumber)
    {
        //this._tenantId = tenantId;
        this._name = name;
        this._phoneNo = phoneNo;
        this._email = email;
        this._accountNo = accountNumber;
        this._accountBalance = 0.0M;
    }

    public void Anonymize()
    {
    }
}
