using FluentAssertions;
using Xunit;

namespace ToyRobot.Tests
{
    public class Left_Should
    {
        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        public void Rotate_robot_left_90_degrees(string before, string after)
        {
            // Arrange
            var toyRobot = new ToyRobot();
            toyRobot.Place(1, 1, before);

            // Act
            toyRobot.Left();

            // Assert
            toyRobot.Facing.Should().Be(after);
        }
    }
}
