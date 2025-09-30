using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class ShelvingUnit
{
    private int _shelvingUnitId;
    public int ShelvingUnitID 
    { 
        get { return _shelvingUnitId; }
    }
    public ShelvingUnit() { } // Parameterless constructor
    
    public ShelvingUnit(int shelvingUnitId)
    {
        _shelvingUnitId = shelvingUnitId;
    }

    private void SalesPerformance() 
    {
    }
}
