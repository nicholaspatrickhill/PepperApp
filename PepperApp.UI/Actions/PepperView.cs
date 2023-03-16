using PepperApp.DataTransferObject;
using PepperApp.Services;
using Serilog;
using System.Globalization;
using static System.Console;

namespace PepperApp.UI
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
                MainMenu.StartOver();
            }
            else
            {
                // Convert input string to title case
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string properCasePepperName = textInfo.ToTitleCase(pepperName.ToLower());

                var pepperToView = new PepperDto
                {
                    PepperName = properCasePepperName
                };

                try
                {
                    var result = await pepperService.GetPepperByNameServiceAsync(pepperToView.PepperName);
                    if (result != null)
                    {
                        pepperToView = result;
                        PepperMessage.PrintPepperDetails(pepperToView);
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
