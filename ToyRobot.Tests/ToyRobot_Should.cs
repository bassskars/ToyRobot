using FluentAssertions;
using Xunit;

namespace ToyRobot.Tests
{
    public class ToyRobot_Should
    {
        [Fact]
        public void Discard_Commands_When_Not_Placed()
        {
            // Arrange
            var toyRobot = new ToyRobot();

            // Act
            toyRobot.Move();
            toyRobot.Left();
            toyRobot.Right();
            var result = toyRobot.Report();

            // Assert
            toyRobot.X.Should().BeNull();
            toyRobot.Y.Should().BeNull();
            toyRobot.Facing.Should().BeNull();
            result.Should().BeNull();
        }
    }
}
