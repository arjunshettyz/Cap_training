using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=.;Initial Catalog=YourDatabase;Integrated Security=True";

        List<Product> products = new List<Product>();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Price FROM Product";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"])
                };

                products.Add(p);
            }

            reader.Close();
            con.Close();
        }

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id} {product.Name} {product.Price}");
        }
    }
}