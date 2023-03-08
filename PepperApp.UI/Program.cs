using static System.Console;
using PepperApp.Entities;
using PepperApp.Repositories;

namespace PepperApp.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Pepper!";

            var pepperRepository = new PepperRepository();
            var pepper = new Pepper();

            WriteLine("Press 1 to add a Pepper");
            WriteLine("Press 2 to view the Database");
            WriteLine("Press 3 to remove a Pepper");

            string? userInput = ReadLine();
            _ = PepperOperations.AddUserPepperName(pepperRepository, pepper, userInput);
            PepperOperations.ListAllPeppersInDatabase(pepperRepository, userInput);
            _ = PepperOperations.RemoveUserPepper(pepperRepository, userInput);
        } 
    }
}
