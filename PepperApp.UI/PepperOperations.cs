using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;
using static System.Console;
using FluentValidation.Results;
using PepperApp.Services;
using FluentValidation;

namespace PepperApp.UI
{
    public class PepperOperations
    {
        public static async Task AddUserPepperName(PepperService pepperService, string userInput)
        {
            if (userInput == "1")
            {
                var pepper = new Pepper();

                while (true)
                {
                    WriteLine("Please enter the pepper name");
                    string? pepperName = ReadLine();

                    if (string.IsNullOrEmpty(pepperName))
                    {
                        WriteLine("Invalid input. Please try again");
                    }
                    else
                    {
                        pepper.PepperName = pepperName;
                        await AddUserPepperScovilleMinimum(pepperService, pepper, pepperName);
                        break;
                    }
                }
            }
        }

        public static async Task AddUserPepperScovilleMinimum(PepperService pepperService, Pepper pepper, string pepperName)
        {
            while (true)
            {
                WriteLine("Please enter its minimum Scoville Heat Unit rating");
                string? userShuMinInput = ReadLine();

                if (int.TryParse(userShuMinInput, out int shuMinValue))
                {
                    pepper.PepperScovilleUnitMin = shuMinValue;
                    await AddUserPepperScovilleMaximum(pepperService, pepper, shuMinValue, pepperName);
                    break;
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static async Task AddUserPepperScovilleMaximum(PepperService pepperService, Pepper pepper, int shuMinValue, string pepperName)
        {
            while (true)
            {
                WriteLine("Please enter its maximum Scoville Heat Unit rating");
                string? userShuMaxInput = ReadLine();

                if (int.TryParse(userShuMaxInput, out int shuMaxValue))
                {
                    pepper.PepperScovilleUnitMax = shuMaxValue;

                    try
                    {
                        await AddUserPepper(pepperService, pepper, shuMinValue, pepperName, shuMaxValue);
                        ReadLine();
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        
                        WriteLine(ex.Message);
                        
                        WriteLine("Please try again.");
                    } 
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static async Task AddUserPepper(PepperService pepperService, Pepper pepper, int shuMinValue, string pepperName, int shuMaxValue)
        {
            await pepperService.AddPepperServiceAsync(pepperName, shuMinValue, shuMaxValue);
            WriteLine($"You added {pepper.PepperName} to the database");
        }



        //public static async Task AddUserPepperName(PepperRepository pepperRepository, Pepper pepper, string? userInput)
        //{
        //    while (userInput == "1")
        //    {
        //        WriteLine("Please add your pepper");

        //        string? pepperName = ReadLine();

        //        if (string.IsNullOrEmpty(pepperName))
        //        {
        //            WriteLine("Invalid input. Please try again");
        //        }
        //        else
        //        {
        //            // check if the pepper name already exists in the database
        //            var existingPepper = await pepperRepository.GetPepperByNameAsync(pepperName);
        //            if (existingPepper?.PepperName != null)
        //            {
        //                WriteLine("A pepper with that name already exists in the database. Please enter a unique name.");
        //            }
        //            else
        //            {
        //                pepper.PepperName = pepperName;
        //                await AddUserPepperScovilleMinimum(pepperRepository, pepper);
        //                break;
        //            }
        //        }
        //    }
        //}


        // Adds new pepper Scoville minimum rating
        //public static async Task AddUserPepperScovilleMinimum(PepperRepository pepperRepository, Pepper pepper)
        ////{
        ////    WriteLine("Please enter its minimum Scoville Heat Unit rating");

        ////    string? userShuMinInput = ReadLine();

        ////    if (int.TryParse(userShuMinInput, out int ShuMinValue))
        ////    {
        ////        pepper.PepperScovilleUnitMin = ShuMinValue;

        ////        await AddUserPepperScovilleMaximum(pepperRepository, pepper);
        ////    }
        ////    else
        ////    {
        ////        WriteLine("Invalid input. Please enter a number.");
        ////        await AddUserPepperScovilleMinimum(pepperRepository, pepper);
        ////    }
        ////}

        // Adds new pepper Scoville maximum rating and sends it to the database if valid

        //public static async Task AddUserPepperScovilleMaximum(PepperRepository pepperRepository, Pepper pepper)
        //{
        //    WriteLine("Please enter its maximum Scoville Heat Unit rating");

        //    string? userShuMaxInput = ReadLine();

        //    if (int.TryParse(userShuMaxInput, out int shuMaxValue))
        //    {
        //        var validator = new PepperValidator();
        //        pepper.PepperScovilleUnitMax = shuMaxValue;

        //        ValidationResult results = validator.Validate(pepper);

        //        if (!results.IsValid)
        //        {
        //            foreach (var failure in results.Errors)
        //            {
        //                WriteLine($"Pepper failed validation. Error was {failure.ErrorMessage}");
        //                await AddUserPepperScovilleMaximum(pepperRepository, pepper);
        //            }
        //        }
        //        else
        //        {
        //            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMax);
        //            WriteLine($"You added {pepper.PepperName} to the database");
        //            await pepperRepository.AddPepperAsync(pepper);
        //        }

        //        ReadLine();
        //    }
        //    else
        //    {
        //        WriteLine("Invalid input. Please enter a number.");
        //        await AddUserPepperScovilleMaximum(pepperRepository, pepper);
        //    }
        //}

        // Lists all peppers in the database sorted by name

        public static void ListAllPeppersInDatabase(PepperService pepperService, string? userInput)
        {
            if (userInput == "2")
            {
                var peppers = pepperService.GetAllPeppersServiceAsync().Result;

                peppers.ForEach(p => PrintPepperToConsole(p));

                ReadLine();
            }
        }

        //public static void ListAllPeppersInDatabase(PepperRepository pepperRepository, string? userInput)
        //{
        //    if (userInput == "2")
        //    {
        //        var peppers = pepperRepository.GetAllPeppersAsync().Result;

        //        peppers.ForEach(p => PrintPepperToConsole(p));

        //        ReadLine();
        //    }
        //}

        // Console message displaying information about a pepper
        public static void PrintPepperToConsole(Pepper pepper)
        {
            WriteLine($"The {pepper.PepperName} is a {pepper.PepperHeatClass} pepper with SHU rating of {pepper.PepperScovilleUnitMin} - {pepper.PepperScovilleUnitMax}");
        }

        // Removes a pepper from the database

        public static async Task RemoveUserPepper(PepperService pepperService, string? userInput)
        {
            while (userInput == "3")
            {
                WriteLine("Which pepper would you like to remove?");

                var pepperToRemove = new Pepper();

                pepperToRemove.PepperName = ReadLine();

                try
                {
                    await pepperService.RemovePepperServiceAsync(pepperToRemove);
                    WriteLine($"You removed {pepperToRemove.PepperName} from the database.");
                    ReadLine();
                    break;
                }
                catch (ArgumentException ex)
                {
                    WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        //public static async Task RemoveUserPepper(PepperRepository pepperRepository, string? userInput)
        //{
        //    while (userInput == "3")
        //    {
        //        WriteLine("Which pepper would you like to remove?");

        //        var pepperToRemove = new Pepper();

        //        pepperToRemove.PepperName = ReadLine();

        //        try
        //        {
        //            await pepperRepository.RemovePepperAsync(pepperToRemove);
        //            WriteLine($"You removed {pepperToRemove.PepperName} from the database.");
        //            ReadLine();
        //            break;
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            WriteLine(ex.Message);
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            WriteLine(ex.Message);
        //        }
        //    }
        //}
    }
}

