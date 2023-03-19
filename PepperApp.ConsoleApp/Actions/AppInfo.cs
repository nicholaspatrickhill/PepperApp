using static System.Console;

namespace PepperApp.ConsoleApp
{
    public class AppInfo
    {
        public static void PrintAboutThisApp()
        {
            Clear();

            WriteLine(@$"**PepperApp** was created in 2023 by Nick Hill as a capstone project for Code Kentucky's Software Development Course 2.
The application helps users manage information about hot peppers and their Scoville Heat Unit ratings, making it easy to recall, update and maintain this data.

### FEATURES
The following items from the Feature List are implemented:
- Create 3 or more unit tests for your application
- Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
- Implement a log that records errors, invalid inputs, or other important events and writes them to a text file
- Make your application an API
- Make your application a CRUD API
- Make your application asynchronous
- Query your database using a raw SQL query, not EF

### ARCHITECTURE
PepperApp uses Entity Framework to manage connections to a sqlite database.
The database is seeded at creation by a dictionary containing several, protected (read-me) entries.
The Services/Repository pattern and the Data Transfer Object (DTO) are employed to seperate concerns.
These abstractions limit exposure to the database, which makes the code more secure and easier to maintain.
The services handle logic and validation while the repository addresses data storage and retrieval.
The DTO decouples the data model from the other layers of the project, making it easier to test.

The use of these patterns also allows for two, independent applications: a CRUD API and a Console Application.

nicholaspatrickhill@gmail.com
https://github.com/nicholaspatrickhill/PepperApp
https://www.linkedin.com/in/nicholaspatrickhill/");

            MainMenu.StartOver();
        }
    }
}
