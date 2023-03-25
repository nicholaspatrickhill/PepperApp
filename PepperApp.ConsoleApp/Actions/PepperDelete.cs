using PepperApp.DataTransferObject;
using PepperApp.Services;
using Serilog;
using System.Diagnostics;
using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class PepperDelete
    {
        public static async Task RemoveAPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to remove?");

            var pepperName = ReadLine();

            if (string.IsNullOrEmpty(pepperName))
            {
                WriteLine("Invalid input. Pepper name cannot be empty.");
                Log.Error("Removal failed do to invalid input. Pepper name cannot be empty.");
                MainMenu.StartOver();
            }
            else
            {
                try
                {                                  
                    var existingPepper = await pepperService.GetPepperByNameServiceAsync(pepperName);

                    await pepperService.RemovePepperServiceAsync(existingPepper!);
                    WriteLine($"You removed {pepperName} from the database.");
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
