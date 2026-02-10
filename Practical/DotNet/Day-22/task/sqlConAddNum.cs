using System;
using System.Data;
using Microsoft.Data.SqlClient;


class Program
{
    static void Main()
    {
         string connectionString = "Data Source=DESKTOP-D5E0CSE\\SQLEXPRESS;Initial Catalog=college;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";

         
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(
                "SELECT dbo.fn_SquareNumber(@num)", con);

            cmd.Parameters.AddWithValue("@num", 5);

            int result = (int)cmd.ExecuteScalar();

            Console.WriteLine("Result = " + result);
        }
    }
}
