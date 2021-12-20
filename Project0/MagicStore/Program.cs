using System.Data.SqlClient;

/*namespace MagicStore {
    public class Program {
        string connectionString = ;
        using SqlConnection connection = new (connectionString);
        connection.Open();

        string commandText = "SELECT * FROM Customer;";
        using SqlCommand command = new (string commandText, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (ReaderWriterLock.Read()) {
            Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + reader.GetInt32(3)); 
        }
   }
}
*/

namespace MagicStore {
    public class Program {

        public static void Main() {
            /*
            string connectionString = "Server=tcp:211115-sql-meganp.database.windows.net,1433;Initial Catalog=Project0DB;Persist Security Info=False;User ID=DBADMIN;Password=Fib=01123581321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using SqlConnection connection = new(connectionString);
            connection.Open();

            string commandText = "SELECT * FROM Customer;";
            using SqlCommand command = new(commandText, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetInt32(3));
            }   */


        }
    }
}

    


