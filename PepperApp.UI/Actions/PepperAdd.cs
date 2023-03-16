﻿using PepperApp.DataTransferObject;
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

            var pepper = new PepperDto();
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
                            await pepperService.AddPepperServiceAsync(pepper);
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
                    }
                }
            }
        }
    }
}

