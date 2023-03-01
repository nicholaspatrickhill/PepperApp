using static System.Console;
using PepperApp.Entities;
using PepperApp.Logic;


namespace PepperApp.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pepperLogic = new PepperLogic();
            var pepper = new Pepper();

            WriteLine("Press 1 to add a Pepper");
            WriteLine("Press 2 to view the Database");
            WriteLine("Press 3 to remove a Pepper");

            string? userInput = ReadLine();
            _ = AddUserPepperName(pepperLogic, pepper, userInput);
            ListAllPeppersInDatabase(pepperLogic, userInput);
            _ = RemoveUserPepper(pepperLogic, userInput);
        }

        private static async Task AddUserPepperName(PepperLogic pepperLogic, Pepper pepper, string? userInput)
        {
            while (userInput == "1")
            {
                WriteLine("Please add your pepper");

                string? pepperName = ReadLine();

                if (string.IsNullOrEmpty(pepperName))
                {
                    WriteLine("Invalid input. Please try again");
                }
                else
                {
                    // check if the pepper name already exists in the database
                    var existingPepper = await pepperLogic.GetPepperByNameAsync(pepperName);
                    if (existingPepper?.PepperName != null)
                    {
                        WriteLine("A pepper with that name already exists in the database. Please enter a unique name.");
                    }
                    else
                    {
                        pepper.PepperName = pepperName;
                        await AddUserPepperScovilleMinimum(pepperLogic, pepper);
                        break;
                    }
                }
            }
        }

        private static async Task AddUserPepperScovilleMinimum(PepperLogic pepperLogic, Pepper pepper)
        {
            WriteLine("Please enter its minimum Scoville Heat Unit rating");

            string? userShuMinInput = ReadLine();

            if (int.TryParse(userShuMinInput, out int ShuMinValue))
            {
                pepper.PepperScovilleUnitMin = ShuMinValue;

                await AddUserPepperScovilleMaximum(pepperLogic, pepper);
            }
            else
            {
                WriteLine("Invalid input. Please enter a number.");
                await AddUserPepperScovilleMinimum(pepperLogic, pepper);
            }
        }

        private static async Task AddUserPepperScovilleMaximum(PepperLogic pepperLogic, Pepper pepper)
        {
            WriteLine("Please enter its maximum Scoville Heat Unit rating");

            string? userShuMaxInput = ReadLine();

            if (int.TryParse(userShuMaxInput, out int ShuMaxValue))
            {
                pepper.PepperScovilleUnitMax = ShuMaxValue;

                WriteLine($"You added {pepper.PepperName} to the database");
                await pepperLogic.AddPepperAsync(pepper);

                ReadLine();
            }
            else
            {
                WriteLine("Invalid input. Please enter a number.");
                await AddUserPepperScovilleMaximum(pepperLogic, pepper);
            }
        }

        private static void ListAllPeppersInDatabase(PepperLogic pepperLogic, string? userInput)
        {
            if (userInput == "2")
            {
                var peppers = pepperLogic.GetAllPeppersAsync().Result;

                peppers.ForEach(p => PrintPepperToConsole(p));

                ReadLine();
            }
        }

        private static void PrintPepperToConsole(Pepper pepper)
        {
            WriteLine($"The {pepper.PepperName} is a {pepper.PepperHeatClass} pepper with SHU rating of {pepper.PepperScovilleUnitMin} - {pepper.PepperScovilleUnitMax}");
        }

        private static async Task RemoveUserPepper(PepperLogic pepperLogic, string? userInput)
        {
            while (userInput == "3")
            {
                WriteLine("Which pepper would you like to remove?");

                var pepperToRemove = new Pepper();

                pepperToRemove.PepperName = ReadLine();

                try
                {
                    await pepperLogic.RemovePepperAsync(pepperToRemove);
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
    }
}
