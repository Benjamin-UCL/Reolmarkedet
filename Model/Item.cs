using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item
    {
        public int ItemId { get; set; } // PK 
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public string BarcodeNo { get; set; } = "";
        public bool IsSold { get; set; } = false;
        public int ShelvingUnitId { get; set; } // FK -> ShelvingUnit

        public Item() { }

        public Item(string name, double price, string barcodeNo, int shelvingUnitId)
        {
            Name = name;
            Price = price;
            BarcodeNo = barcodeNo;
            ShelvingUnitId = shelvingUnitId;
        }
    }
}