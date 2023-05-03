using Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace OOPProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string filesDirectory = "C:\\Users\\Sonnenaufgang\\source\\repos\\NULP_OOP_PROJECT\\Files";
            const string loggerPath = "C:\\Users\\Sonnenaufgang\\source\\repos\\NULP_OOP_PROJECT\\Logs";
            const string dataPath = filesDirectory + "\\data.txt";
            const string firstOutputPath = filesDirectory + "\\FILE1.TXT";
            const string secondOutputPath = filesDirectory + "\\FILE2.TXT";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: SystemConsoleTheme.Grayscale)
                .WriteTo.File(loggerPath + "/log-.log", rollingInterval: RollingInterval.Day, 
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            try
            {
                Log.Information("Program started");

                var countLines = File.ReadAllLines(dataPath);
                var animals = new Animal[countLines.Length];

                TasksMethods.ReadFromFile(animals, dataPath);
                SerializationMethods.JsonSerialize(filesDirectory + "\\animals.json", animals);
                SerializationMethods.JsonDeserialize(filesDirectory + "\\animals.json", animals);

                TasksMethods.FirstTaskMethod(animals, firstOutputPath);
                TasksMethods.SecondTaskMethod(animals, secondOutputPath);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.ToString());
            }
            finally
            {
                Log.Information("Program completed");
                Log.CloseAndFlush();
            }
        }
    }
}