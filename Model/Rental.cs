using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class Rental
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    private DateTime SettledDate { get; set; }  

    public int RentalConfig { get; set; }

    public decimal PriceAgreement { get; set; }
}
