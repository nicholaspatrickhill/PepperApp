using PepperApp.Entities;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperMessage
    {
        // Console message that displays information about a pepper in the database
        public static void PrintPepperToConsole(Pepper pepper)
        {
            WriteLine($"The {pepper.PepperName} is a {pepper.PepperHeatClass} pepper with SHU rating of {pepper.PepperScovilleUnitMinimum} - {pepper.PepperScovilleUnitMaximum}");
        }
    }
}
