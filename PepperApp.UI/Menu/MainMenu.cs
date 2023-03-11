using PepperApp.Repositories;
using PepperApp.Services;
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
                "View all peppers",
                "Add a pepper",
                "Update a pepper",
                "Remove a pepper",
                "Exit",        
            };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    Clear();
                    ViewAllPeppers(_pepperService);
                    break;
                case 1:
                    AddAPepper(_pepperService);
                    break;
                case 2:
                    UpdateAPepper(_pepperService);
                    break;
                case 3:
                    RemoveAPepper(_pepperService);
                    break;
                case 4: 
                    Exit();
                    break;
            }
        }

      
        private static void ViewAllPeppers(PepperService pepperService)
        {
            PepperUIOperations.ListAllPeppersInDatabase(pepperService);
        }

        private static void AddAPepper(PepperService pepperService)
        {
            _ = PepperUIOperations.AddUserPepperName(pepperService);
        }

        private static void UpdateAPepper(PepperService pepperService)
        {
            _ = PepperUIOperations.UpdateUserPepper(pepperService);
        }


        private static void RemoveAPepper(PepperService pepperService)
        {
            _ = PepperUIOperations.RemoveUserPepper(pepperService);
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
                    Environment.Exit(0);
                    break;
                case 1:
                    Start();
                    break;
            }
        }
    }
}
