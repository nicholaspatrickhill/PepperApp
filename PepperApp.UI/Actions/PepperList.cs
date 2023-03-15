using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperList
    {
        public static void ListAllPeppersInDatabase(PepperService pepperService)
        {
            Clear();

            var peppers = pepperService.GetAllPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

            MainMenu.StartOver();
        }

        //public static void SavePepperListToFile(PepperService pepperService)
        //{
        //    Clear();

        //    var peppers = pepperService.GetAllPeppersServiceAsync().Result.ToString();

        //    File.WriteAllLines("PepperList.txt", peppers);

        //    WriteLine("Your list of peppers has been saved to a text file.");
        //}
    }
}
