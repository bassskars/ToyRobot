using FluentAssertions;
using Xunit;

namespace ToyRobot.Tests
{
    public class Move_Should
    {
        [Theory]
        [InlineData(2, 2, Direction.North, 2, 3)]
        [InlineData(2, 2, Direction.East, 3, 2)]
        [InlineData(2, 2, Direction.South, 2, 1)]
        [InlineData(2, 2, Direction.West, 1, 2)]
        [InlineData(4, 4, Direction.North, 4, 4)]
        [InlineData(4, 4, Direction.East, 4, 4)]
        [InlineData(0, 0, Direction.South, 0, 0)]
        [InlineData(0, 0, Direction.West, 0, 0)]
        public void Move_correctly(int initialX, int initialY, string initialDirection, int expectedX, int expectedY)
        {
            // Arrange
            var toyRobot = new ToyRobot();
            toyRobot.Place(initialX, initialY, initialDirection);

            // Act
            toyRobot.Move();

            // Assert
            toyRobot.X.Should().Be(expectedX);
            toyRobot.Y.Should().Be(expectedY);
        }
    }
}
