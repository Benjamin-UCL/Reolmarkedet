using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Database_Connection;

public class DbBuilder
{
    private readonly string _connectionString;

    public DbBuilder(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void RunSchema()
    {
        // Henter sql filen til en string
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schema", "Schema.sql");
        string query = File.ReadAllText(path);


        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
