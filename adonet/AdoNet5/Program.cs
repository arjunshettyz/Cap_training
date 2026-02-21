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
            // DataAdapter with SELECT query
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Name, Price FROM Product", con);

            // CommandBuilder to auto-generate UPDATE command
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            // Create DataSet
            DataSet ds = new DataSet();

            // Fill DataSet
            adapter.Fill(ds, "Product");

            // Modify rows in DataSet
            DataTable table = ds.Tables["Product"];

            if (table.Rows.Count > 0)
            {
                table.Rows[0]["Name"] = "Updated Product Name";
                table.Rows[0]["Price"] = 999.99;
            }

            // Push updates back to database
            adapter.Update(ds, "Product");

            Console.WriteLine("Database Updated Successfully");
        }
    }
}