using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace Model;

public class Rental
{
    private int _rentalId;
    public int RentalId 
    { 
        get { return _rentalId; }
    }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    private DateTime _settledDate;
    public DateTime SettledDate 
    { 
        get { return _settledDate; } 
        set 
        { 
            _settledDate = value; 
        }
    }

    public int RentalConfig { get; set; }

    public decimal PriceAgreement { get; set; }

    public Tenant Tenant { get; set; }
    public ShelvingUnit ShelfUnit { get; set; }

    public Rental(int RentalId, DateTime StartDate, DateTime EndDate, DateTime SettledDate, int RentalConfig, decimal PriceAgreement, int TenantId, int ShelfUnitId) 
    {
        this._rentalId = RentalId;
        this.StartDate = StartDate;
        this.EndDate = EndDate;
        this.SettledDate = SettledDate;
        this.RentalConfig = RentalConfig;
        this.PriceAgreement = PriceAgreement;
    }

    public Rental(Tenant tenant, ShelvingUnit shelfUnit, DateTime startDate)
    {
        this.Tenant = tenant;
        this.ShelfUnit = shelfUnit;
        this.StartDate = startDate;
    }
}
