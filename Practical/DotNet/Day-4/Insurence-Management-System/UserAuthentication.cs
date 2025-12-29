sealed class UserAuthentication
{
    private static string defaultEmail = "aryan@gmail.com";
    private static string defaultPassword = "Aryan@123";


    public static bool AuthenticateUser(string email, string password)
    {
        if(email == defaultEmail && password == defaultPassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}