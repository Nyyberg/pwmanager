using PasswordManager.Models;
using PasswordManager.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PasswordManager 
{
class Program
{
        static Service service = new Service();
        static string masterpassword = string.Empty;
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello, Welcome to password manager");

            while (Setup())
            {

            }

            MainEntry();
        }

        static bool Setup()
        {
            Console.WriteLine("Checking for masterpassword...");

            while (true)
            {
                bool found = service.checkForMasterpassword();

                if (found)
                {
                    Console.WriteLine("Please enter your masterpassword");
                    var enteredPassword = Console.ReadLine();

                    if (service.verifyPassword(enteredPassword))
                    {
                        Console.WriteLine("Access granted.");
                        masterpassword = enteredPassword;
                        return false; 
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");

                    }
                }
                else
                {
                    Console.WriteLine("Found no masterpassword, please make a master password");
                    Console.WriteLine("Please enter a masterpassword:");
                    var masterpassword = Console.ReadLine();
                    service.addMasterpassword(masterpassword);
                   
                }
            }
        }

        static void MainEntry()
        {
            while (true) 
            {
                Console.WriteLine("Welcome to PwManager!");
                Console.WriteLine("Press 1, if you would like to see your passwords");
                Console.WriteLine("Press 2, if you would like to add a new password");
                var response = Console.ReadLine();

                if (response == "1") 
                {
                    List<Logins> logins = service.getLogins(Convert.ToBase64String(service.HashChecker(masterpassword)));
                    foreach (Logins login in logins) 
                    { 
                        Console.WriteLine(login.Name);
                        Console.WriteLine(login.Username);
                        Console.WriteLine(login.Password);
                        
                    }

                }
                if (response == "2") 
                {
                    Console.WriteLine("please enter a name");
                    var name = Console.ReadLine();
                    Console.WriteLine("Please enter a Username");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please enter the password");
                    var password = Console.ReadLine();
                    Logins logins = new Logins();
                    logins.Name = name;
                    logins.Username = username;
                    logins.Password = password;
                    service.addLogins(logins, Convert.ToBase64String(service.HashChecker(masterpassword)));
                    MainEntry();
                }




            }
        }

      
    }
}
