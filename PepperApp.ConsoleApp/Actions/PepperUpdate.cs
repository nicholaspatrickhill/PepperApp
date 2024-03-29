﻿using PepperApp.DataTransferObject;
using PepperApp.Services;
using Serilog;
using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class PepperUpdate
    {
        public static async Task UpdateAPepper(PepperService pepperService)
        {
            Clear();

            WriteLine("Which pepper would you like to update?");

            var pepperToUpdate = new PepperDto();

            string? pepperNameInput = ReadLine();

            if (string.IsNullOrEmpty(pepperNameInput))
            {
                WriteLine("Invalid input. Pepper name cannot be empty.");
                Log.Error("Update failed due to invalid input. Pepper name cannot be empty.");
                MainMenu.StartOver();
            }


            pepperToUpdate.PepperName = pepperNameInput!.ToLower();

            try
            {
                var existingPepper = await pepperService.GetPepperByNameServiceAsync(pepperToUpdate.PepperName!);

                if (existingPepper == null)
                {
                    WriteLine($"No pepper with the specified name was found in the database.");
                    Log.Error($"Update failed. No pepper with the specified name exists in the database.");
                    MainMenu.StartOver();
                }
                if (existingPepper!.IsReadOnly)
                {
                    WriteLine($"That pepper is read-only and cannot be updated.");
                    Log.Error($"Update failed. That pepper is read-only and cannot be updated: {existingPepper.PepperName}");
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
                        Log.Error("Update error: Invalid input. Minimum Scoville Heat Unit rating was not a number");
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
                        Log.Error("Update error: Invalid input. Maximum Scoville Heat Unit rating was not a number");
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
