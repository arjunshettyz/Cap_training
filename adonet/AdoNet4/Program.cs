using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=.;Initial Catalog=YourDatabase;Integrated Security=True";

        int senderId = 1;
        int receiverId = 2;
        decimal amount = 500;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Query 1: Deduct amount from Sender
                SqlCommand cmd1 = new SqlCommand(
                    "UPDATE Account SET Balance = Balance - @Amount WHERE Id = @SenderId",
                    con, transaction);

                cmd1.Parameters.AddWithValue("@Amount", amount);
                cmd1.Parameters.AddWithValue("@SenderId", senderId);

                cmd1.ExecuteNonQuery();

                // Query 2: Add amount to Receiver
                SqlCommand cmd2 = new SqlCommand(
                    "UPDATE Account SET Balance = Balance + @Amount WHERE Id = @ReceiverId",
                    con, transaction);

                cmd2.Parameters.AddWithValue("@Amount", amount);
                cmd2.Parameters.AddWithValue("@ReceiverId", receiverId);

                cmd2.ExecuteNonQuery();

                // Commit transaction if both succeed
                transaction.Commit();

                Console.WriteLine("Transaction Successful");
            }
            catch (Exception)
            {
                // Rollback if any query fails
                transaction.Rollback();

                Console.WriteLine("Transaction Failed. Rolled back.");
            }
            finally
            {
                con.Close();
            }
        }
    }
}