namespace ToyRobot
{
    public class ToyRobot
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public int? X { get; private set; }
        public int? Y { get; private set; }
        public string Facing { get; private set; }


        public ToyRobot(int maxX = 5, int maxY = 5)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public void Place(int x, int y, string direction)
        {
            if (IsValid(x, y, direction))
                (X, Y, Facing) = (x, y, direction);
        }

        public void Move()
        {
            if (Facing == Direction.North && IsValid(X, Y + 1, Facing)) Y += 1;
            else if (Facing == Direction.East && IsValid(X + 1, Y, Facing)) X += 1;
            else if (Facing == Direction.South && IsValid(X, Y - 1, Facing)) Y -= 1;
            else if (Facing == Direction.West && IsValid(X - 1, Y, Facing)) X -= 1;
        }

        public void Left() => Facing = Facing.IsValid() ? Facing.RotateLeft() : null;

        public void Right() => Facing = Facing.IsValid() ? Facing.RotateRight() : null;

        public string Report() => IsValid(X, Y, Facing) ? $"{X},{Y},{Facing}" : null;

        private bool IsValid(int? x, int? y, string direction)
            => x >= 0 && x < _maxX && y >= 0 && y < _maxY && direction.IsValid();
    }
}
