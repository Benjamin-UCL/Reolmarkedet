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

    private bool IsSettled { get; set; }
    private DateTime SettledDate { get; set; }  

    public bool RentalConfig { get; set; }

    public double PriceAgreement { get; set; }
}
