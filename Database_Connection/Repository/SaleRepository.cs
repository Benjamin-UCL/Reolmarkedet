using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model;

namespace Database_Connection.Repository;

public class SaleRepository : IRepository<Model.Sale>
{
    private readonly string _connectionString;

    public SaleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(Sale entity)
    {
        string query = "INSERT INTO SALE (SalesDate, Price, ItemId) VALUES (@Date, @Price, @ItemId)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Date", DateTime.Today);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@ItemId", entity.ItemId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
        //string query = "DELETE FROM SALE WHERE Id = @Id";
    }

    public IEnumerable<Sale> GetAll()
    {
        throw new NotImplementedException();
        //string query = "SELECT Id, Date, TotalAmount FROM SALE";
    }

    public Sale GetById(int id)
    {
        throw new NotImplementedException();
        //string query = "SELECT Id, Date, TotalAmount FROM SALE WHERE Id = @Id";
    }

    public void Update(Sale entity)
    {
        throw new NotImplementedException();
        //string query = "UPDATE SALE SET Date = @Date, TotalAmount = @TotalAmount WHERE Id = @Id";
    }
}
