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

            peppers.ForEach(p => WriteLine(PepperDetails.PepperDetailsString(p)));

            MainMenu.StartOver();
        }

        public static async Task SaveAllPeppersToTextFile(PepperService pepperService)
        {
            var peppers = await pepperService.GetAllPeppersServiceAsync();

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var parentDirectory = new DirectoryInfo(baseDirectory);

            while (parentDirectory != null && parentDirectory.Name != "PepperApp")
            {
                parentDirectory = Directory.GetParent(parentDirectory.FullName);
            }

            var filePath = Path.Combine(parentDirectory?.FullName!, "PepperAppList.txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                peppers.ForEach((p) => writer.WriteLine(PepperDetails.PepperDetailsString((p))));
            }

            Clear();
            WriteLine("The list of peppers has been saved to a text file.");
            MainMenu.StartOver();
        }
    }
}
