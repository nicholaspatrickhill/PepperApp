using PepperApp.Entities;
using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperList
    {
        public static void ListAllPeppersInDatabase(PepperService pepperService)
        {
            {
                var peppers = pepperService.GetAllPeppersServiceAsync().Result;

                peppers.ForEach(p => PrintPepperToConsole(p));

                MainMenu.StartOver();
            }
        }

        // Console message that displays information about a pepper in the database
        private static void PrintPepperToConsole(Pepper pepper)
        {
            WriteLine($"The {pepper.PepperName} is a {pepper.PepperHeatClass} pepper with SHU rating of {pepper.PepperScovilleUnitMinimum} - {pepper.PepperScovilleUnitMaximum}");
        }

    }
}
