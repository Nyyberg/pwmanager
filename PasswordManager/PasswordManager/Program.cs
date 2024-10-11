using PasswordManager.Services;
using System.Security.Cryptography.X509Certificates;

namespace PasswordManager 
{
class Program
{
        static Service service = new Service();
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
            while (true)
            {
                Console.WriteLine("Do you have a masterpassword? y/n");
                var answer = Console.ReadLine();

                if (answer == "y")
                {
                    Console.WriteLine("Please enter your masterpassword");
                    var enteredPassword = Console.ReadLine();

                    if (service.verifyPassword(enteredPassword))
                    {
                        Console.WriteLine("Access granted.");
                        return false; 
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");

                    }
                }
                if (answer == "n")
                {
                    Console.WriteLine("Please enter a masterpassword");
                    var masterpassword = Console.ReadLine();
                    service.addMasterpassword(masterpassword);
                   
                }
            }
        }

        static void MainEntry()
        {
            Console.WriteLine("you made it this far!");
        }

      
    }
}
