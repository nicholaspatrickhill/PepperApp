using PepperApp.Logger;
using static System.Console;

namespace PepperApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Pepper!";
            PepperAppLogger.StartLogger();
            MainMenu.Start();
        }
    }
}
