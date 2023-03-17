using PepperApp.DataTransferObject;
using PepperApp.Services;
using Serilog;
using System.Globalization;
using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class PepperDelete
    {
        // Take user input to remove a pepper from the database
        public static async Task RemoveAPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to remove?");
            string? pepperName = ReadLine();

            if (string.IsNullOrEmpty(pepperName))
            {
                WriteLine("Invalid input. Pepper name cannot be empty.");
                Log.Error("Removal failed do to invalid input. Pepper name cannot be empty.");
                MainMenu.StartOver();
            }
            else
            {
                // Convert input string to title case
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string properCasePepperName = textInfo.ToTitleCase(pepperName.ToLower());

                var pepperToRemove = new PepperDto
                {
                    PepperName = properCasePepperName
                };

                try
                {
                    await pepperService.RemovePepperServiceAsync(pepperToRemove);
                    WriteLine($"You removed {pepperToRemove.PepperName} from the database.");
                    MainMenu.StartOver();
                }
                catch (ArgumentException ex)
                {
                    WriteLine(ex.Message);
                    MainMenu.StartOver();
                }
                catch (InvalidOperationException ex)
                {
                    WriteLine(ex.Message);
                    MainMenu.StartOver();
                }
            }
        }
    }
}
