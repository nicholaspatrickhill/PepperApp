using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Pepper!";

            var pepperRepository = new PepperRepository();
            var pepperService = new PepperService(pepperRepository);
            var pepper = new Pepper();

            WriteLine("Press 1 to add a Pepper");
            WriteLine("Press 2 to view the Database");
            WriteLine("Press 3 to remove a Pepper");

            string? userInput = ReadLine();

            _ = PepperOperations.AddUserPepperName(pepperService, userInput!);
            PepperOperations.ListAllPeppersInDatabase(pepperService, userInput);
            _ = PepperOperations.RemoveUserPepper(pepperService, userInput);
        }
    }
}
