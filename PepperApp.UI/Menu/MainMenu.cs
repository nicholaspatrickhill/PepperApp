using PepperApp.Repositories;
using PepperApp.Services;
using Serilog;
using static System.Console;

namespace PepperApp.UI
{
    public class MainMenu
    {
        private static readonly PepperRepository _pepperRepository = new PepperRepository();
        private static readonly PepperService _pepperService = new PepperService(_pepperRepository);

        public static void Start()
        {
            var mainMenu = new MainMenu();
            RunMainMenu();
        }

        private static void RunMainMenu()
        {
            string prompt = "Use the UP and DOWN arrow keys to select an option and then press enter. \n";
            string[] options =
            {
                "View peppers sorted by name",
                "View peppers sorted by heat class",
                "Add a pepper",
                "Update a pepper",
                "Remove a pepper",
                "Exit",
            };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ViewAllPeppers(_pepperService);
                    break;
                case 1:
                    ViewPeppersSortedByHeatClass(_pepperService);
                    break;
                case 2:
                    AddAPepper(_pepperService);
                    break;
                case 3:
                    UpdateAPepper(_pepperService);
                    break;
                case 4:
                    RemoveAPepper(_pepperService);
                    break;
                case 5:
                    Exit();
                    break;
            }
        }

        private static void ViewAllPeppers(PepperService pepperService)
        {
            PepperByNameList.ListAllPeppersInDatabase(pepperService);
        }

        private static void ViewPeppersSortedByHeatClass(PepperService pepperService)
        {
            PepperByHeatClassList.RunHeatClassMenu();
        }

        private static void AddAPepper(PepperService pepperService)
        {
            _ = PepperAdd.AddNewPepper(pepperService);
        }

        private static void UpdateAPepper(PepperService pepperService)
        {
            _ = PepperUpdate.UpdateAPepper(pepperService);
        }

        private static void RemoveAPepper(PepperService pepperService)
        {
            _ = PepperDelete.RemoveAPepper(pepperService);
        }       

        private static void Exit()
        {
            string prompt = "\nAre you sure you wish to exit the program?";
            string[] options = { "\nYes", "No" };

            Menu exitMenu = new Menu(prompt, options);
            int selectedIndex = exitMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    WriteLine("\nStay cool...");
                    Log.CloseAndFlush();
                    Environment.Exit(0);
                    break;
                case 1:
                    Start();
                    break;
            }
        }

        // Recycles to the main menu when user is finished
        public static void StartOver()
        {
            WriteLine("\nPress enter to return to the main menu.");
            ReadLine();
            MainMenu.Start();
        }
    } 
}
