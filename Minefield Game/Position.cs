
namespace Minefield_Game
{
    using System;

    public struct Position : IEquatable<Position>
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public bool Equals(Position other)
        {
            return this.Column == other.Column
                && this.Row == other.Row;
        }
    }
}
