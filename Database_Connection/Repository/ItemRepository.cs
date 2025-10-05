using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft.Data.SqlClient;

namespace Database_Connection.Repository;

public class ItemRepository : IRepository<Item>
{
    private readonly string _connectionString;
    public ItemRepository(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }
    public int Add(Item entity)
    {
        //DB kræver BarcodeNo, derfor autogenerer
        if (string.IsNullOrWhiteSpace(entity.BarcodeNo))
        {
            var raw = Guid.NewGuid().ToString("N");
            entity.BarcodeNo = raw.Substring(0, 12); //ChatGPTs hjælp til BarcodeNo
        }
        if (entity.Name == null) entity.Name = ""; 

        string query = @"INSERT INTO ITEM (Name, Price, BarcodeNo, ShelfUnitId)
                        OUTPUT INSERTED.ItemId
                        VALUES (@Name, @Price, @BarcodeNo, @ShelfUnitId);";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@BarcodeNo", entity.BarcodeNo);
            command.Parameters.AddWithValue("@ShelfUnitId", entity.ShelvingUnitId);

            connection.Open();
            int newId = (int)command.ExecuteScalar();
            return newId;
        }
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