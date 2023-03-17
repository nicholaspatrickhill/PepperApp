using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperByHeatClassList
    {
        private static readonly PepperService _pepperService = new PepperService();

        public static void DisplayHeatClassMenu()
        {
            string prompt = "Use the UP and DOWN arrow keys to select an option and then press enter. \n";
            string[] options =
            {
                "Mild",
                "Medium",
                "Medium-Hot",
                "Hot",
                "Super-Hot",
                "Return to main menu",
            };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    _ = Mild(_pepperService);
                    break;
                case 1:
                    _ = Medium(_pepperService);
                    break;
                case 2:
                    _ = MediumHot(_pepperService);
                    break;
                case 3:
                    _ = Hot(_pepperService);
                    break;
                case 4:
                    _ = SuperHot(_pepperService);
                    break;
                case 5:
                    ReturnToMainMenu();
                    break;
            }
        }

        public static async Task Mild(PepperService pepperService)
        {
            Clear();

            var peppers = await pepperService.GetMildPeppersServiceAsync();

            peppers.ForEach(p => WriteLine(PepperDetails.PepperDetailsString(p)));

            StartOver();
        }

        private static async Task Medium(PepperService pepperService)
        {
            Clear();

            var peppers = await pepperService.GetMediumPeppersServiceAsync();

            peppers.ForEach(p => WriteLine(PepperDetails.PepperDetailsString(p)));

            StartOver();
        }

        private static async Task MediumHot(PepperService pepperService)
        {
            Clear();

            var peppers = await pepperService.GetMediumHotPeppersServiceAsync();

            peppers.ForEach(p => WriteLine(PepperDetails.PepperDetailsString(p)));

            StartOver();
        }

        private static async Task Hot(PepperService pepperService)
        {
            Clear();

            var peppers = await pepperService.GetHotPeppersServiceAsync();

            peppers.ForEach(p => WriteLine(PepperDetails.PepperDetailsString(p)));

            StartOver();
        }

        private static async Task SuperHot(PepperService pepperService)
        {
            Clear();

            var peppers = await pepperService.GetSuperHotPeppersServiceAsync();

            peppers.ForEach(p => WriteLine(PepperDetails.PepperDetailsString(p)));

            StartOver();
        }

        private static void ReturnToMainMenu()
        {
            MainMenu.Start();
        }

        // Recycles to the Heat Class menu when user is finished
        private static void StartOver()
        {
            WriteLine("\nPress enter to return to the menu.");
            ReadLine();
            DisplayHeatClassMenu();
        }
    }
}
