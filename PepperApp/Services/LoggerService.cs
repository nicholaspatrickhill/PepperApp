using Serilog;

namespace PepperApp.Services
{
    public class LoggerService
    {
        public static void StartLogger()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var parentDirectory = new DirectoryInfo(baseDirectory);

            while (parentDirectory != null && parentDirectory.Name != "PepperApp")
            {
                parentDirectory = Directory.GetParent(parentDirectory.FullName);
            }

            var logPath = Path.Combine(parentDirectory?.FullName!, "PepperAppLog.txt");

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File(logPath,
                rollingInterval: RollingInterval.Month,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

             .CreateLogger();
        }
    }
}
