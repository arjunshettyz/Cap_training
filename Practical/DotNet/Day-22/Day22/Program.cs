using System;
using System.Data;
using Microsoft.Data.SqlClient;


class Program
{
    static void Main()
    {
         string connectionString = "Data Source=DESKTOP-D5E0CSE\\SQLEXPRESS;Initial Catalog=college;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";

         
        // 1️⃣ Create DataSet
        DataSet ds = new DataSet();
        

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection successful!");

                // 2️⃣ Create SqlCommand (Stored Procedure)
                using (SqlCommand command = new SqlCommand("sp_GetStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // 3️⃣ Create DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // 4️⃣ Fill DataSet
                     adapter.Fill(ds, "college_master");
                  
                }
            }

            // 5️⃣ Read Data from DataSet
            foreach (DataRow row in ds.Tables["college_master"].Rows)
            {
                Console.WriteLine(
                    row[0] + " " +
                    row[1] + " " +
                    row[2]);
            } 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);


        } 
    Console.WriteLine(ds.Tables.Count);
    }

}
