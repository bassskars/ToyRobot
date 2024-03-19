using FakeItEasy;
using Xunit;

namespace ToyRobot.Tests
{
    public class Commander_Should
    {
        private readonly ToyRobot _toyRobot;
        private readonly Commander _commander;

        public Commander_Should()
        {
            _toyRobot = A.Fake<ToyRobot>();
            _commander = new Commander(_toyRobot);
        }

        [Theory]
        [InlineData("PLACE 0,0,NORTH", 0, 0, Direction.North)]
        [InlineData("PLACE 1,2,EAST", 1, 2, Direction.East)]
        [InlineData("PLACE 3,4,SOUTH", 3, 4, Direction.South)]
        [InlineData("PLACE 4,0,WEST", 4, 0, Direction.West)]
        public void Execute_Place_command(string command, int x, int y, Direction direction)
        {
            _commander.Execute(command);

            A.CallTo(() => _toyRobot.Place(x, y, direction)).MustHaveHappened();
        }

        [Fact]
        public void Execute_Move_command()
        {
            _toyRobot.Place(2, 2, Direction.North);

            _commander.Execute("MOVE");

            A.CallTo(() => _toyRobot.Move()).MustHaveHappened();
        }

        [Fact]
        public void Execute_Left_command()
        {
            _toyRobot.Place(2, 2, Direction.North);

            _commander.Execute("LEFT");

            A.CallTo(() => _toyRobot.Left()).MustHaveHappened();
        }

        [Fact]
        public void Execute_Right_command()
        {
            _toyRobot.Place(2, 2, Direction.North);

            _commander.Execute("RIGHT");

            A.CallTo(() => _toyRobot.Right()).MustHaveHappened();
        }

        // Additional test cases can be added here for other commands

        // Error handling and security improvements can be incorporated as needed
    }
}
