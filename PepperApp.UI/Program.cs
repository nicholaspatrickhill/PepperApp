using PepperApp.Services;
using static System.Console;

namespace PepperApp.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Pepper!";
            LoggerService.StartLogger();
            MainMenu.Start();
        }
    }
}
