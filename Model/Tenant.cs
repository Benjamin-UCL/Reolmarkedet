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
    public string Name { get => _name; set { _name = value; } }

    private string _phoneNo;
    public string PhoneNo { get => _phoneNo; set { _phoneNo = value; } }

    private string _email;
    public string Email { get => _email; set { _email = value;  } }

    private int _accountNo;
    public int AccountNo { get => _accountNo; set { _accountNo = value; } }

    private decimal _accountBalance;
    public decimal AccountBalance { get => _accountBalance; set { _accountBalance = value; } }

    public Tenant() { } // Parameterless constructor
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
