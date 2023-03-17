using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperList
    {
        public static async Task ListAllPeppersInDatabase(PepperService pepperService)
        {
            Clear();

            var peppers = await pepperService.GetAllPeppersServiceAsync();

            peppers.ForEach(p => PepperMessage.PrintPepperDetails(p));

            MainMenu.StartOver();
        }

        //public static void SaveAllPeppersToTextFile(PepperService pepperService, Pepper pepper)
        //{
        //    var peppers = pepperService.GetAllPeppersServiceAsync().Result;

        //    var pepperList = new List<string>();

        //    peppers.ForEach(p =>
        //    {
        //        string v = $"The {pepper.PepperName} is a {pepper.PepperHeatClass} pepper with SHU rating of {pepper.PepperScovilleUnitMinimum} - {pepper.PepperScovilleUnitMaximum}";
        //        pepperList.Add(v);
        //    });

        //    File.WriteAllLines(@"C:\temp\PepperList.txt", pepperList);

        //    Clear();
        //    WriteLine("The list of peppers has been saved to a text file.");
        //    MainMenu.StartOver();
        //}
    }
}
