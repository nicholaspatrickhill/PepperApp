using PepperApp.Entities;
using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperByNameList
    {
        public static void ListAllPeppersInDatabase(PepperService pepperService)
        {
            Clear(); 

            var peppers = pepperService.GetAllPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

            MainMenu.StartOver();
        }
    }
}
