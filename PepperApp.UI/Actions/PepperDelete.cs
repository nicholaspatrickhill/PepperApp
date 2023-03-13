using PepperApp.Entities;
using PepperApp.Services;
using Serilog;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperDelete
    {
        // Take user input to remove a pepper from the database
        public static async Task RemoveAPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to remove?");

            var pepperToRemove = new Pepper();

            pepperToRemove.PepperName = ReadLine();

            try
            {
                await pepperService.RemovePepperServiceAsync(pepperToRemove);
                WriteLine($"You removed {pepperToRemove.PepperName} from the database.");
                MainMenu.StartOver();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                Log.Error($"{ex.Message}");
                MainMenu.StartOver();
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
                Log.Error($"Deletion of read-only pepper was attempted: {pepperToRemove.PepperName}.");
                MainMenu.StartOver();
            }
        }
    }
}
