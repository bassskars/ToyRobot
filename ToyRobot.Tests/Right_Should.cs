using FluentAssertions;
using Xunit;

namespace ToyRobot.Tests
{
    public class Right_Should
    {
        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void Rotate_robot_right_90_degrees(string before, string after)
        {
            // Arrange
            var toyRobot = new ToyRobot();
            toyRobot.Place(1, 1, before);

            // Act
            toyRobot.Right();

            // Assert
            toyRobot.Facing.Should().Be(after);
        }
    }
}
