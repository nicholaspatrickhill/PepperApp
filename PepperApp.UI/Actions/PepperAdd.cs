using PepperApp.Entities;
using PepperApp.Services;
using Serilog;
using System.Globalization;
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
            int shuMinValue;
            string properCasePepperName = "";

            while (true)
            {
                // Get pepper name
                WriteLine("Please enter the pepper name");
                string? pepperName = ReadLine();

                if (string.IsNullOrEmpty(pepperName))
                {
                    WriteLine("Invalid input. Pepper name cannot be empty.");
                    Log.Error("Invalid input. Pepper name was empty.");
                    MainMenu.StartOver();
                }
                else
                {
                    // Convert input string to title case
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    properCasePepperName = textInfo.ToTitleCase(pepperName.ToLower());

                    pepper.PepperName = properCasePepperName;
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
                        Log.Error($"Invalid input. Pepper minimum SHU rating was entered as {userShuMinInput}.");
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
                            await pepperService.AddPepperServiceAsync(properCasePepperName, shuMinValue, shuMaxValue);
                            WriteLine($"You added {pepper.PepperName} to the database");
                            MainMenu.StartOver();

                            //await AddUserPepper(pepperService, pepper, shuMinValue, properCasePepperName, shuMaxValue);
                            //ReadLine();
                            //break;
                        }
                        catch (ArgumentException ex)
                        {
                            WriteLine(ex.Message);
                            Log.Error($"{pepper.PepperName}: {ex.Message}");
                            MainMenu.StartOver();
                        }
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                        Log.Error($"Invalid input. Pepper maxium SHU rating was entered as {userShuMaxInput}.");
                    }
                }
            }
        }

        //private static async Task AddUserPepper(PepperService pepperService, Pepper pepper, int shuMinValue, string? properCasePepperName, int shuMaxValue)
        //{
        //    await pepperService.AddPepperServiceAsync(properCasePepperName, shuMinValue, shuMaxValue);
        //    WriteLine($"You added {pepper.PepperName} to the database");
        //    MainMenu.StartOver();
        //}
    }
}

