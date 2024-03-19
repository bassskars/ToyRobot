using System;
using System.Collections.Generic;

namespace ToyRobot
{
    public static class Direction
    {
        public const string North = "NORTH";
        public const string East = "EAST";
        public const string South = "SOUTH";
        public const string West = "WEST";

        private static readonly HashSet<string> ValidDirections
            = new HashSet<string> { North, East, South, West };

        public static bool IsValid(this string direction)
            => ValidDirections.Contains(direction);

        public static string RotateLeft(this string direction)
            => Rotate(direction, -1);

        public static string RotateRight(this string direction)
            => Rotate(direction, 1);

        private static string Rotate(string direction, int offset)
        {
            if (!ValidDirections.Contains(direction))
                throw new ArgumentException("Invalid direction.");

            var directionsArray = new[] { North, East, South, West };
            var currentIndex = Array.IndexOf(directionsArray, direction);
            var newIndex = (currentIndex + offset + directionsArray.Length) % directionsArray.Length;

            return directionsArray[newIndex];
        }
    }
}
