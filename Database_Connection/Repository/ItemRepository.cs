using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Database_Connection.Repository
{
    public class ItemRepository : IRepository<Item>
    {
        //Opretter en ny Item i databasen.
        //Senere: kør en INSERT INTO Items(...) VALUES(...) og sæt ItemId fra DB.
        public int Add(Item entity)
        {
            throw new NotImplementedException();
        }
        //Sletter en Item ud fra dens primærnøgle (ItemId).
        //Senere: DELETE FROM Items WHERE ItemId=@id
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        // Henter alle Items.
        //Senere: SELECT * FROM Items ORDER BY ItemId
        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }
        // Slår én Item op på id.
        //Senere: SELECT * FROM Items WHERE ItemId=@id
        public Item GetById(int id)
        {
            throw new NotImplementedException();
        }
        // Opdaterer en eksisterende Item.
        //Senere: UPDATE Items SET Name=@..., Price=@..., ... WHERE ItemId=@id
        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
        // Senere: Hjælpemetode til scanning:
        // public Item GetByBarcode(string barcode) { ... }
    }
}



