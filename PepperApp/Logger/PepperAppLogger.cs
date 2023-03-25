using Serilog;

namespace PepperApp.Logger
{
    public class PepperAppLogger
    {
        public static void StartLogger()
        {
            string logPath;
            if (OperatingSystem.IsWindows())
            {
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                logPath = Path.Combine(appDataPath, "PepperApp", "PepperAppLog.txt");
            }
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())          
            {
                var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                logPath = Path.Combine(libraryPath, "Application Support", "PepperApp", "PepperAppLog.txt");
            }
            else
            {
                throw new PlatformNotSupportedException("The current operating system is not supported.");
            }

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File(logPath,
                rollingInterval: RollingInterval.Month,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

             .CreateLogger();
        }
    }
}