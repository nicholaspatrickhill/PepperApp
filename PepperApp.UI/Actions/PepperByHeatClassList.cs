using PepperApp.Repositories;
using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperByHeatClassList
    {
        private static readonly PepperRepository _pepperRepository = new PepperRepository();
        private static readonly PepperService _pepperService = new PepperService(_pepperRepository);

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
                    Mild(_pepperService);
                    break;
                case 1:
                    Medium(_pepperService);
                    break;
                case 2:
                    MediumHot(_pepperService);
                    break;
                case 3:
                    Hot(_pepperService);
                    break;
                case 4:
                    SuperHot(_pepperService);
                    break;
                case 5:
                    ReturnToMainMenu();
                    break;
            }
        }

        public static void Mild(PepperService pepperService)
        {
            Clear();

            var peppers = pepperService.GetMildPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

            StartOver();
        }

        private static void Medium(PepperService pepperService)
        {
            Clear();

            var peppers = pepperService.GetMediumPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

            StartOver();
        }

        private static void MediumHot(PepperService pepperService)
        {
            Clear();

            var peppers = pepperService.GetMediumHotPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

            StartOver();
        }

        private static void Hot(PepperService pepperService)
        {
            Clear();

            var peppers = pepperService.GetHotPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

            StartOver();
        }

        private static void SuperHot(PepperService pepperService)
        {
            Clear();

            var peppers = pepperService.GetSuperHotPeppersServiceAsync().Result;

            peppers.ForEach(p => PepperMessage.PrintPepperToConsole(p));

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
