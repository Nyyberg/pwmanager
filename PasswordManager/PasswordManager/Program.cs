namespace PasswordManager 
{
class Program
{
        static void Main(string[] args)
        {
            var service = new Services.Service();
            Console.WriteLine("Hello, Welcome to password manager");


            
            Console.Write("Do you have a master password? (y/n): ");

            var answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.WriteLine("Please type your master password: ");
                var response = Console.ReadLine();


            }
            else if (answer == "n")
            {
                Console.WriteLine("Please type a master password you would like :");
                var masterpassword = Console.ReadLine();
                service.addMasterpassword(masterpassword);

            }
            
       
    }
    }
}
