using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model;

namespace Database_Connection.Repository;

public class RentalRepository : IRepository<Model.Rental>
{
    private readonly string _connectionString;

    public RentalRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public int Add(Rental entity)
    {
        string query = "INSERT INTO RENTAL (StartDate, EndDate, SettledDate, RentalConfig, PriceAgreement, TenantId, ShelfUnitId) " +
                       "VALUES (@StartDate, @EndDate, @SettledDate, @RentalConfig, @PriceAgreement, @TenantId, @ShelfUnitId)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StartDate", entity.StartDate);
            command.Parameters.AddWithValue("@EndDate", entity.EndDate);
            command.Parameters.AddWithValue("@SettledDate",
                entity.SettledDate.HasValue ? entity.SettledDate.Value : (object)DBNull.Value); //For at SettledDate kan være tom
            command.Parameters.AddWithValue("@RentalConfig", entity.RentalConfig);
            command.Parameters.AddWithValue("@PriceAgreement", entity.PriceAgreement);
            command.Parameters.AddWithValue("@TenantId", entity.TenantId);
            command.Parameters.AddWithValue("@ShelfUnitId", entity.ShelfUnitId);

            connection.Open();
            return command.ExecuteNonQuery();

        }

    }       
      

    public void Delete(int id)
    {
        string query = "DELETE FROM RENTAL WHERE RentalId = @Id";

        using (SqlConnection connection = new SqlConnection(_connectionString))

        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();

            /*
            Evt:
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0; // true hvis den fandt en række, der blev slettet*/
        }
    }

    public IEnumerable<Rental> GetAll()
    {
        string query = "SELECT RentalId, StartDate, EndDate, SettledDate, RentalConfig, PriceAgreement, TenantId, ShelfUnitId FROM RENTAL";

        var rentals = new List<Rental>();

        using (SqlConnection connection = new SqlConnection(_connectionString))

        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var rental = new Rental
                    {
                        RentalId = reader.GetInt32(0),               // RentalId
                        StartDate = reader.GetDateTime(1),           // StartDate
                        EndDate = reader.GetDateTime(2),             // EndDate
                        SettledDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3), // SettledDate kan være null
                        RentalConfig = reader.GetString(4),          // RentalConfig
                        PriceAgreement = reader.GetDecimal(5),       // PriceAgreement
                        TenantId = reader.GetInt32(6),               // TenantId
                        ShelfUnitId = reader.GetInt32(7)             // ShelfUnitId
                    };
                        rentals.Add(rental);

                }
           
            }
       
        }
        return rentals;

    }

    public Rental GetById(int id)
    {
        string query = "SELECT RentalId, StartDate, EndDate, SettledDate, RentalConfig, PriceAgreement, TenantId, ShelfUnitId " +
                       "FROM RENTAL WHERE RentalId = @Id";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();

            using(SqlDataReader reader = command.ExecuteReader())
        {
                if (reader.Read()) // hvis der findes en række
                {
                    return new Rental
                    {
                        RentalId = reader.GetInt32(0),
                        StartDate = reader.GetDateTime(1),
                        EndDate = reader.GetDateTime(2),
                        SettledDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                        RentalConfig = reader.GetInt32(4),
                        PriceAgreement = reader.GetDecimal(5),
                        TenantId = reader.GetInt32(6),
                        ShelfUnitId = reader.GetInt32(7)
                    };
                }
            }
        }

        return null; // hvis ingen række blev fundet

    }

    public void Update(Rental entity)
    {
        string query = @"UPDATE RENTAL
                     SET StartDate = @StartDate,
                         EndDate = @EndDate,
                         SettledDate = @SettledDate,
                         RentalConfig = @RentalConfig,
                         PriceAgreement = @PriceAgreement,
                         TenantId = @TenantId,
                         ShelfUnitId = @ShelfUnitId
                     WHERE RentalId = @RentalId";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // Tilføj parametre
            command.Parameters.AddWithValue("@StartDate", entity.StartDate);
            command.Parameters.AddWithValue("@EndDate", entity.EndDate);
            command.Parameters.AddWithValue("@SettledDate", entity.SettledDate.HasValue ? (object)entity.SettledDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@RentalConfig", entity.RentalConfig);
            command.Parameters.AddWithValue("@PriceAgreement", entity.PriceAgreement);
            command.Parameters.AddWithValue("@TenantId", entity.TenantId);
            command.Parameters.AddWithValue("@ShelfUnitId", entity.ShelfUnitId);
            command.Parameters.AddWithValue("@RentalId", entity.RentalId);

            connection.Open();
            command.ExecuteNonQuery(); // udfører opdateringen
        }
    }
}
