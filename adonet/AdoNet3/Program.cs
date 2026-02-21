using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=.;Initial Catalog=YourDatabase;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("GetEmployeeCount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Output parameter
            SqlParameter outputParam = new SqlParameter();
            outputParam.ParameterName = "@TotalCount";
            outputParam.SqlDbType = SqlDbType.Int;
            outputParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(outputParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            int count = (int)cmd.Parameters["@TotalCount"].Value;

            Console.WriteLine("Employee Count: " + count);
        }
    }
}