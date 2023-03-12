using PepperApp.Entities;
using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperAdd
    {
        // Takes user input to add the new pepper to the database
        public static async Task AddNewPepper(PepperService pepperService)
        {
            Clear();

            var pepper = new Pepper();
            int shuMinValue = 0;

            while (true)
            {
                WriteLine("Please enter the pepper name");
                string? pepperName = ReadLine();

                if (string.IsNullOrEmpty(pepperName))
                {
                    WriteLine("Invalid input.");
                    MainMenu.StartOver();
                }
                else
                {
                    pepper.PepperName = pepperName;
                }

                // Get pepper minimum SHU rating
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
                            await AddUserPepper(pepperService, pepper, shuMinValue, pepperName, shuMaxValue);
                            ReadLine();
                            break;
                        }
                        catch (ArgumentException ex)
                        {
                            WriteLine(ex.Message);
                            MainMenu.StartOver();

                            //await AddUserPepperName(pepperService);
                        }
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }
        }

        private static async Task AddUserPepper(PepperService pepperService, Pepper pepper, int shuMinValue, string? pepperName, int shuMaxValue)
        {
            await pepperService.AddPepperServiceAsync(pepperName, shuMinValue, shuMaxValue);
            WriteLine($"You added {pepper.PepperName} to the database");
            MainMenu.StartOver();
        }
    }
}

