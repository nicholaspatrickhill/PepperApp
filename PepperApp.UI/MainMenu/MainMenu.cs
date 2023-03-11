using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                "Remove a pepper",
                "Exit"
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
                    RemoveAPepper(_pepperService);
                    break;
                case 3:
                    Exit();
                    break;
            }
        }

        private static void ViewAllPeppers(PepperService pepperService)
        {
            PepperOperations.ListAllPeppersInDatabase(pepperService);
        }

        private static void AddAPepper(PepperService pepperService)
        {
            _ = PepperOperations.AddUserPepperName(pepperService);
        }

        private static void RemoveAPepper(PepperService pepperService)
        {
            _ = PepperOperations.RemoveUserPepper(pepperService);
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
