using System;
using System.IO;
using System.Linq;

namespace DavidSara.Rameckator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputPath = AppContext.BaseDirectory + "in";
                if (!Directory.Exists(inputPath))
                {
                    Directory.CreateDirectory(inputPath);
                }

                var outputPath = AppContext.BaseDirectory + "out";
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }
                else
                {
                    var di = new DirectoryInfo(outputPath);
                    di.GetFiles().ToList().ForEach(a => a.Delete());
                }

                var files = Directory.GetFiles(inputPath, "*.jpg");

                foreach (var file in files)
                {
                    var result = ImageProcessor.Resize(file, outputPath);
                    if (result == string.Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"File {file} processed.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"File {file} error: {result}");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"DONE.");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
