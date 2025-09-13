using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Database_Connection.Repository;

public class SaleRepository : IRepository<Model.Sale>
{
    public void Add(Sale entity)
    {
        throw new NotImplementedException();
        //string query = "INSERT INTO SALE (Id, Date, TotalAmount) VALUES (@Id, @Date, @TotalAmount)";
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
