using System;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class Commander
    {
        private static readonly Regex PlaceCommandRegex = new Regex(@"PLACE (\d+),(\d+),(\w+)", RegexOptions.Compiled);

        private readonly ToyRobot _toyRobot;

        public Commander(ToyRobot toyRobot)
        {
            _toyRobot = toyRobot ?? throw new ArgumentNullException(nameof(toyRobot));
        }

        public void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            switch (command)
            {
                case "MOVE":
                    _toyRobot.Move();
                    break;
                case "LEFT":
                    _toyRobot.Left();
                    break;
                case "RIGHT":
                    _toyRobot.Right();
                    break;
                case "REPORT":
                    Console.WriteLine(_toyRobot.Report());
                    break;
                default:
                    ProcessPlaceCommand(command);
                    break;
            }
        }

        private void ProcessPlaceCommand(string command)
        {
            var match = PlaceCommandRegex.Match(command);
            if (match.Success)
            {
                if (int.TryParse(match.Groups[1].Value, out var x) &&
                    int.TryParse(match.Groups[2].Value, out var y))
                {
                    var direction = match.Groups[3].Value;
                    _toyRobot.Place(x, y, direction);
                }
            }
            else
            {
                Console.WriteLine($"Invalid command: {command}");
            }
        }
    }
}
