using PepperApp.Entities;
using PepperApp.Services;
using Serilog;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperUpdate
    {
        // Takes user input to update a pepper in the database
        public static async Task UpdateAPepper(PepperService pepperService)
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
                    Log.Error($"{pepperToUpdate.PepperName} was not in the database.");
                    MainMenu.StartOver();
                }
                if (existingPepper!.IsReadOnly)
                {
                    WriteLine($"That pepper is read-only and cannot be updated.");
                    Log.Error($"Update to read-only pepper was attempted: {existingPepper.PepperName}.");
                    MainMenu.StartOver();
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
                        Log.Error($"Invalid input. Pepper minimum SHU rating was entered as {userShuMinInput}.");
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
                        Log.Error($"Invalid input. Pepper maximum SHU rating was entered as {userShuMaxInput}.");
                    }
                }

                await pepperService.UpdatePepperServiceAsync(existingPepper);
                WriteLine($"You updated the pepper '{existingPepper.PepperName}' in the database.");
                MainMenu.StartOver();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                MainMenu.StartOver();
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
                MainMenu.StartOver();
            }
        }
    }
}
