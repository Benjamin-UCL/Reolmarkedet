using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model;

namespace Database_Connection.Repository
{

    public class TenantRepository : IRepository<Model.Tenant>
    {
        private readonly string _connectionString;

        public TenantRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Add(Tenant entity)
        {
            string query = "INSERT INTO TENANT (Name, PhoneNo, Email, AccountNumber) OUTPUT INSERTED.TenantId VALUES (@Name, @PhoneNo, @Email, @AccountNumber)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@PhoneNo", entity.PhoneNo);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@AccountNumber", entity.AccountNo);
                connection.Open();
                int newId = (int)command.ExecuteScalar();
                return newId;
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM TENANT WHERE TenantId = @TenantId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TenantId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Tenant> GetAll()
        {
            //throw new NotImplementedException();
            var tenants = new List<Tenant>();
            string query = "SELECT * FROM TENANT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tenants.Add(new Tenant
                        (
                            (string)reader["Name"],
                            (string)reader["PhoneNo"],
                            (string)reader["Email"],
                            (int)reader["AccountNumber"]
                        ));

                    }
                }
            }
            return tenants;
        }

        public Tenant GetById(int id)
        {
            string query = "SELECT TenantId, Name, PhoneNo, Email, AccountNumber FROM TENANT WHERE TenantId = @TenantId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TenantId", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tenant
                        {
                            Name = reader["Name"] as string,
                            PhoneNo = reader["PhoneNo"] as string,
                            Email = reader["Email"] as string,
                            AccountNo = (int)reader["AccountNumber"]
                        };
                    }
                }
            }

            return null;
        }

        public void Update(Tenant entity)
        {
            string query = @"UPDATE TENANT 
                         SET Name = @Name, PhoneNo = @PhoneNo, Email = @Email, AccountNumber = @AccountNumber 
                         WHERE TenantId = @TenantId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@PhoneNo", entity.PhoneNo);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@AccountNumber", entity.AccountNo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
