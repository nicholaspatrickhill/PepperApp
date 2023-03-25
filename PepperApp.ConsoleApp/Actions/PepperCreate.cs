using PepperApp.DataTransferObject;
using PepperApp.Services;
using Serilog;
using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class PepperCreate
    {
        public static async Task CreateNewPepper(PepperService pepperService)
        {
            Clear();

            var pepper = new PepperDto();
            int shuMinValue;

            while (true)
            {
                // Get pepper name
                WriteLine("Please enter the pepper name");
                string? pepperName = ReadLine();

                if (string.IsNullOrEmpty(pepperName))
                {
                    WriteLine("Invalid input. Pepper name cannot be empty.");
                    Log.Error("Creation failed do to invalid input. Pepper name cannot be empty.");
                    MainMenu.StartOver();
                }
                else
                {
                    pepper.PepperName = pepperName;
                }

                // Get minimum SHU rating
                while (true)
                {
                    WriteLine("Please enter its minimum Scoville Heat Unit rating");
                    string? userShuMinInput = ReadLine();

                    if (int.TryParse(userShuMinInput, out shuMinValue))
                    {
                        pepper.PepperScovilleUnitMinimum = shuMinValue;
                        break;
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                        Log.Error("Creation error: Invalid input. Minimum Scoville Heat Unit rating was not a number");
                    }
                }

                // Get maxium SHU rating
                while (true)
                {
                    WriteLine("Please enter its maximum Scoville Heat Unit rating");
                    string? userShuMaxInput = ReadLine();

                    if (int.TryParse(userShuMaxInput, out int shuMaxValue))
                    {
                        pepper.PepperScovilleUnitMaximum = shuMaxValue;

                        try
                        {
                            await pepperService.CreatePepperServiceAsync(pepper);
                            WriteLine($"You added {pepper.PepperName} to the database");
                            MainMenu.StartOver();
                        }
                        catch (ArgumentException ex)
                        {
                            WriteLine(ex.Message);
                            MainMenu.StartOver();
                        }
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                        Log.Error("Creation error: Invalid input. Maximum Scoville Heat Unit rating was not a number");
                    }
                }
            }
        }
    }
}

