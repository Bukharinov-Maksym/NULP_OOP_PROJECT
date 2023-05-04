using Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace OOPProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            var filesDirectory = Directory.GetCurrentDirectory() + "\\Files";
            var loggerPath = Directory.GetCurrentDirectory() + "\\Logs";
            var dataPath = filesDirectory + "\\data.txt";
            var firstOutputPath = filesDirectory + "\\FILE1.TXT";
            var secondOutputPath = filesDirectory + "\\FILE2.TXT";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: SystemConsoleTheme.Grayscale)
                .WriteTo.File(loggerPath + "/log-.log", rollingInterval: RollingInterval.Day, 
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            try
            {
                Log.Information("Program started");

                TasksMethods.FilesDirectoryEnsureCreated(filesDirectory);
                TasksMethods.DataFileEnsureCreated(dataPath);
                var animals = new Animal[File.ReadLines(dataPath).Count()];

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
            Console.Read();
        }
    }
}