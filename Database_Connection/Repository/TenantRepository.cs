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
                //command.ExecuteNonQuery();
                int newId = (int)command.ExecuteScalar();
                return newId;

            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
                        //{
                        //    tenantid = (int)reader["tenantid"],
                        //    name = (string)reader["name"],
                        //    phoneno = (int)reader["phoneno"],
                        //    email = (string)reader["email"]
                        //});
                        (
                            (int)reader["TenantId"],
                            (string)reader["Name"],
                            (int)reader["PhoneNo"],
                            (string)reader["Email"],
                            (int)reader["AccountNumber"]
                        ));
                        // TODO: Possibly make a separate table for accounts: <<table>>TenantAccount?
                        //{
                        //    _nextAccountNo = (int)reader["AccountNo"],
                        //    AccountBalance = (double)reader["AccountBalance"]
                        //});

                    }
                }
            }
            return tenants;
        }

        public Tenant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tenant entity)
        {
            throw new NotImplementedException();
        }
    }
}
