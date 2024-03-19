using System;
using System.IO;
using System.Linq;

namespace ToyRobot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputFiles = args.Where(File.Exists);

            foreach (var path in inputFiles)
            {
                Console.WriteLine($"Executing commands from: {path}\n");

                ExecuteCommandsFrom(path);

                Console.WriteLine("\n-----------------------\n");
            }

            Console.ReadLine();
        }

        private static void ExecuteCommandsFrom(string path)
        {
            var toyRobot = new ToyRobot();
            var commander = new Commander(toyRobot);

            foreach (var command in File.ReadLines(path))
            {
                Console.WriteLine($"Executing command: {command}");
                commander.Execute(command);
            }
        }
    }
}
