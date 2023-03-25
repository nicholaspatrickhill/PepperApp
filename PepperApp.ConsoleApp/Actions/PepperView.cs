using PepperApp.DataTransferObject;
using PepperApp.Services;
using Serilog;
using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class PepperView
    {
        public static async Task ViewAPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to view?");

            string? pepperName = ReadLine();

            if (string.IsNullOrEmpty(pepperName))
            {
                WriteLine("Invalid input. Pepper name cannot be empty.");
                Log.Error("View failed due to invalid input. Pepper name cannot be empty.");
                MainMenu.StartOver();
            }
            else
            {
                var pepperToView = new PepperDto
                {
                    PepperName = pepperName
                };

                try
                {
                    var result = await pepperService.GetPepperByNameServiceAsync(pepperToView.PepperName);
                    if (result != null)
                    {
                        pepperToView = result;
                        WriteLine(PepperDetails.PepperDetailsString(pepperToView));
                        MainMenu.StartOver();
                    }
                }
                catch (ArgumentException ex)
                {
                    WriteLine(ex.Message);
                    MainMenu.StartOver();
                }
            }
        }
    }
}
