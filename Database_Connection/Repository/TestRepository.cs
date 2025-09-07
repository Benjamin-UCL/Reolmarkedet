using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model;

namespace Database_Connection;

public class TestRepository : IRepository<TestModel>
{

    private readonly string _connectionString;

    public TestRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(TestModel entity)
    {
        string query = "INSERT INTO TESTTABLE (Id, Name) VALUES (@Id, @Name)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TestModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public TestModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(TestModel entity)
    {
        throw new NotImplementedException();
    }

}
