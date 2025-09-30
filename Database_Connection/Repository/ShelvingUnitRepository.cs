using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model;

namespace Database_Connection.Repository
{
    public class ShelvingUnitRepository : IRepository<Model.ShelvingUnit>
    {

        private readonly string _connectionString;

        public ShelvingUnitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(ShelvingUnit entity)
        {
            string query = "INSERT INTO SHELF_UNIT OUTPUT INSERTED.ShelfUnitId DEFAULT VALUES";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int newId = (int)command.ExecuteScalar();
                return newId;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShelvingUnit> GetAll()
        {
            //throw new NotImplementedException();
            var shelvingUnits = new List<ShelvingUnit>();
            string query = "SELECT * FROM SHELF_UNIT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shelvingUnits.Add(new ShelvingUnit
                        (
                            (int)reader["ShelfUnitId"]
                        ));

                    }
                }
            }
            return shelvingUnits;
        }

        public ShelvingUnit GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ShelvingUnit entity)
        {
            throw new NotImplementedException();
        }
    }
}
