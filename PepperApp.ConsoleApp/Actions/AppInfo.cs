using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class AppInfo
    {
        public static void PrintAboutThisApp()
        {
            Clear();

            WriteLine(@$"PepperApp was created in 2023 by Nick Hill as a capstone project for Code Kentucky's Software Development Course 2.
PepperApp was built using Visual Studio and .NET 7.0.

PepperApp helps users manage information about hot peppers and their Scoville Heat Unit ratings.
The Scoville scale is a tool for measuring the spiciness or pungency of hot peppers.
The scale measures the amount of capsaicin in a pepper and assigns it a number rating in Scoville Heat Units (SHUs).
Hot pepper enthusiasts and hot sauce artisans may find PepperApp useful for storing and updating information about their favorite peppers or for discovering new varities to try in their recipes.

The following items from the Feature List are implemented:
- Create 3 or more unit tests for your application.
- Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program.
- Implement a log that records errors, invalid inputs, or other important events and writes them to a text file.
- Make your application an API.
- Make your application a CRUD API.
- Make your application asynchronous.
- Query your database using a raw SQL query, not EF.

https://github.com/nicholaspatrickhill/PepperApp
https://www.linkedin.com/in/nicholaspatrickhill/");

            MainMenu.StartOver();
        }
    }
}
