using PepperApp.Services;
using static System.Console;

namespace PepperApp.ConsoleApp
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

            string filePath;
            if (OperatingSystem.IsWindows())
            {
                var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var pepperAppFolder = Path.Combine(appDataFolder, "PepperApp");

                if (!Directory.Exists(pepperAppFolder))
                {
                    Directory.CreateDirectory(pepperAppFolder);
                }

                filePath = Path.Combine(pepperAppFolder, "PepperAppList.txt");
            }
            else if (OperatingSystem.IsMacOS())
            {
                var homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var pepperAppFolder = Path.Combine(homeFolder, "Library", "Application Support", "PepperApp");

                if (!Directory.Exists(pepperAppFolder))
                {
                    Directory.CreateDirectory(pepperAppFolder);
                }

                filePath = Path.Combine(pepperAppFolder, "PepperAppList.txt");
            }
            else
            {
                throw new NotSupportedException("The current operating system is not supported.");
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var pepper in peppers)
                {
                    writer.WriteLine(PepperDetails.PepperDetailsString(pepper));
                }
            }

            Clear();
            WriteLine($"The list of peppers has been saved to a text file at {filePath}.");
            MainMenu.StartOver();
        }
    }
}
