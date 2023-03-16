﻿using static System.Console;

namespace PepperApp.UI
{
    public class AppInfo
    {
        public static void PrintAboutThisApp()
        {
            Clear();

            WriteLine(@$"PepperApp was created by Nick Hill as a capstone project for Code Kentucky's Software Development Course 2.
This application was developed to help manage information about hot peppers and their Scoville Heat Unit ratings.
PepperApp helps quickly recall, update and maintain this data.

### FEATURES
The following items from the Feature List are implemented:
-Create 3 or more unit tests for your application
-Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
- Implement a log that records errors, invalid inputs, or other important events and writes them to a text file
- Make your application an API
- Make your application a CRUD API
- Make your application asynchronous
- Query your database using a raw SQL query, not EF

nicholaspatrickhill@gmail.com
https://github.com/nicholaspatrickhill/PepperApp
https://www.linkedin.com/in/nicholaspatrickhill/");

            MainMenu.StartOver();
        }
    }
}
