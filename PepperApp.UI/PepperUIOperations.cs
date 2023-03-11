using PepperApp.Entities;
using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperUIOperations
    {
        // Takes user input to add the new pepper's name
        public static async Task AddUserPepperName(PepperService pepperService)
        {
            Clear();

            var pepper = new Pepper();

            while (true)
            {
                WriteLine("Please enter the pepper name");
                string? pepperName = ReadLine();

                if (string.IsNullOrEmpty(pepperName))
                {
                    WriteLine("Invalid input. Please try again.");
                }
                else
                {
                    pepper.PepperName = pepperName;
                    await AddUserPepperScovilleMinimum(pepperService, pepper, pepperName);
                    break;
                }
            }
        }

        // Takes user input to add the new pepper's SHU minimum rating
        public static async Task AddUserPepperScovilleMinimum(PepperService pepperService, Pepper pepper, string pepperName)
        {
            while (true)
            {
                WriteLine("Please enter its minimum Scoville Heat Unit rating");
                string? userShuMinInput = ReadLine();

                if (int.TryParse(userShuMinInput, out int shuMinValue))
                {
                    pepper.PepperScovilleUnitMinimum = shuMinValue;
                    await AddUserPepperScovilleMaximum(pepperService, pepper, shuMinValue, pepperName);
                    break;
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        // Takes user input to add the new pepper's SHU maximum rating
        public static async Task AddUserPepperScovilleMaximum(PepperService pepperService, Pepper pepper, int shuMinValue, string pepperName)
        {
            while (true)
            {
                WriteLine("Please enter its maximum Scoville Heat Unit rating");
                string? userShuMaxInput = ReadLine();

                if (int.TryParse(userShuMaxInput, out int shuMaxValue))
                {
                    pepper.PepperScovilleUnitMaximum = shuMaxValue;

                    try
                    {
                        await AddUserPepper(pepperService, pepper, shuMinValue, pepperName, shuMaxValue);
                        ReadLine();
                        break;
                    }
                    catch (ArgumentException ex)
                    {

                        WriteLine(ex.Message);

                        StartOver();

                        await AddUserPepperName(pepperService);
                    }
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        // Makes a call to add the new pepper to the database if it has passed all validation
        private static async Task AddUserPepper(PepperService pepperService, Pepper pepper, int shuMinValue, string pepperName, int shuMaxValue)
        {
            await pepperService.AddPepperServiceAsync(pepperName, shuMinValue, shuMaxValue);
            WriteLine($"You added {pepper.PepperName} to the database");
            StartOver();
        }

        // Lists all peppers in the database sorted by name 
        public static void ListAllPeppersInDatabase(PepperService pepperService)
        {
            {
                var peppers = pepperService.GetAllPeppersServiceAsync().Result;

                peppers.ForEach(p => PrintPepperToConsole(p));

                StartOver();
            }
        }    

        // Console message that displays information about a pepper
        public static void PrintPepperToConsole(Pepper pepper)
        {
            WriteLine($"The {pepper.PepperName} is a {pepper.PepperHeatClass} pepper with SHU rating of {pepper.PepperScovilleUnitMinimum} - {pepper.PepperScovilleUnitMaximum}");
        }

        // Removes a pepper from the database
        public static async Task RemoveUserPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to remove?");

            var pepperToRemove = new Pepper();

            pepperToRemove.PepperName = ReadLine();

            try
            {
                await pepperService.RemovePepperServiceAsync(pepperToRemove);
                WriteLine($"You removed {pepperToRemove.PepperName} from the database.");
                StartOver();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                StartOver();
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
                StartOver();
            }     
        }

        public static async Task UpdateUserPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to update?");

            var pepperToUpdate = new Pepper();

            pepperToUpdate.PepperName = ReadLine();

            try
            {
                var existingPepper = await pepperService.GetPepperByNameAsync(pepperToUpdate.PepperName!);

                if (existingPepper == null)
                {
                    WriteLine($"The pepper '{pepperToUpdate.PepperName}' does not exist in the database.");
                    StartOver();
                    return;
                }

                WriteLine($"Updating pepper '{pepperToUpdate.PepperName}':");

                // Get new name
                WriteLine($"Current name: {existingPepper.PepperName}");
                WriteLine("Enter new name (or leave blank to keep current name):");
                string? newName = ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    existingPepper.PepperName = newName;
                }

                // Get new minimum SHU rating
                WriteLine($"Current minimum SHU rating: {existingPepper.PepperScovilleUnitMinimum}");
                while (true)
                {
                    WriteLine("Enter new minimum SHU rating (or leave blank to keep current rating):");
                    string? userShuMinInput = ReadLine();

                    if (string.IsNullOrEmpty(userShuMinInput))
                    {
                        break;
                    }
                    else if (int.TryParse(userShuMinInput, out int shuMinValue))
                    {
                        existingPepper.PepperScovilleUnitMinimum = shuMinValue;
                        break;
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                    }
                }

                // Get new maximum SHU rating
                WriteLine($"Current maximum SHU rating: {existingPepper.PepperScovilleUnitMaximum}");
                while (true)
                {
                    WriteLine("Enter new maximum SHU rating (or leave blank to keep current rating):");
                    string? userShuMaxInput = ReadLine();

                    if (string.IsNullOrEmpty(userShuMaxInput))
                    {
                        break;
                    }
                    else if (int.TryParse(userShuMaxInput, out int shuMaxValue))
                    {
                        existingPepper.PepperScovilleUnitMaximum = shuMaxValue;
                        break;
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                    }
                }

                await pepperService.UpdatePepperServiceAsync(existingPepper);
                WriteLine($"You updated the pepper '{existingPepper.PepperName}' in the database.");
                StartOver();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                StartOver();
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
                StartOver();
            }
        }

        // Recycles to the main menu when user is finished
        private static void StartOver()
        {
            WriteLine("\nPress enter to return to the main menu.");
            ReadLine();
            MainMenu.Start();
        }
    }
}

