using PepperApp.DataTransferObject;
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

            //peppers.ForEach(p => PepperMessage.PrintPepperDetails(p));
            peppers.ForEach(p => WriteLine(PepperMessage.PrintPepperDetails(p)));

            MainMenu.StartOver();
        }

        public static async Task SaveAllPeppersToTextFile(PepperService pepperService, string filePath)
        {
            var peppers = await pepperService.GetAllPeppersServiceAsync();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                peppers.ForEach((p) => writer.WriteLine(PepperMessage.PrintPepperDetails((p))));
            }           

            Clear();
            WriteLine("The list of peppers has been saved to a text file.");
            MainMenu.StartOver();
        }
    }
}
