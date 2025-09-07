using Model;

namespace DB_Seeder;

public class Program
{
    static void Main(string[] args)
    {
        
        // connect to db

        
        
        // check tables,


        // drop tables,
        string sqlStatment = "DROP TABLE ***********;";

        // run scemas,
        string sqlSchema = "CREATE TABLE TESTTABLE(" +
            "PKey int IDENTIFY(1,1) PRIMERY KEY" +
            "Id int NOT NULL," +
            "Name NVarChar(50) NOT NULL" +
            ");";

        // seed data
        string sqlSeed = "INSERT INTO ***********;";


        TestModel a = new TestModel("Func Hit");
        Console.WriteLine(a.Name);
    }
}
