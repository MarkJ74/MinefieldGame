
namespace Minefield_Game
{
    using System;

    public class Game
    {
        private readonly IInput input;
        private readonly IOutput output;

        private readonly int numberOfColumns;
        private readonly int numberOfRows;
        private readonly int numberOfMines;
        private int numberOfLives;

        public int NumberOfMoves { get; private set; }

        public Position playerPosition = new Position { Column = 1, Row = 1 };
        private readonly Position[] mines;

        public Game(IInput input, IOutput output, int numberOfColumns, int numberOfRows, int numberOfLives, int numberOfMines)
        {
            this.input = input;
            this.output = output;
            this.numberOfColumns = numberOfColumns;
            this.numberOfRows = numberOfRows;
            this.numberOfLives = numberOfLives;
            this.numberOfMines = numberOfMines;

            this.mines = new Position[numberOfMines];
            this.GenerateMines(numberOfMines);
        }

        private void GenerateMines(int numberOfMines)
        {
            var random = new Random();

            for (int i = 0; i < numberOfMines; i++)
            {
                var minePosition = new Position
                {
                    Column = random.Next(1, this.numberOfColumns),
                    Row = random.Next(1, this.numberOfRows)
                };

                this.mines[i] = minePosition;
            }
        }

        public void Play()
        {
            this.ShowInstructions();

            var done = false;
            while (!done)
            {
                var command = this.input.GetCommand();

                switch (command)
                {
                    case Command.Up:
                        done = this.Move(0, -1);
                        break;

                    case Command.Down:
                        done = this.Move(0, 1);
                        break;

                    case Command.Left:
                        done = this.Move(-1, 0);
                        break;

                    case Command.Right:
                        done = this.Move(1, 0);
                        break;

                    case Command.Exit:
                        done = true;
                        break;
                }
            }
        }

        private void ShowInstructions()
        {
            this.output.WriteLine("Minefield Game");
            this.output.WriteLine("==============");
            this.output.WriteLine($"You are at position A1 on a {this.numberOfColumns}x{this.numberOfRows} grid, you have {this.numberOfLives} lives and must reach row {GetLetterFromNumber(this.numberOfRows)} without hitting {this.numberOfMines} mines.");
            this.output.WriteLine("Type U, D, L or R to move up, down, left or right, or type X to exit.");
        }

        // returns true if the game is over
        public bool Move(int columns, int rows)
        {
            var newColumn = this.playerPosition.Column + columns;
            var newRow = this.playerPosition.Row + rows;

            if (newColumn < 1 || newColumn > this.numberOfColumns || newRow < 1)
            {
                this.output.WriteLine("You can't move past the end of the board.");
                return false;
            }

            this.playerPosition.Column = newColumn;
            this.playerPosition.Row = newRow;
            this.NumberOfMoves++;

            if (this.HasHitMine())
            {
                this.output.WriteLine("OUCH! You hit a mine.");

                this.numberOfLives--;

                if (this.numberOfLives == 0)
                {
                    this.output.WriteLine("You are now dead.");
                    return true;
                }

                this.output.WriteLine($"You have {this.numberOfLives} {(this.numberOfLives == 1 ? "life" : "lives")} remaining.");
            }

            this.output.WriteLine($"You are at position {GetLetterFromNumber(this.playerPosition.Row)}{this.playerPosition.Column} after {this.NumberOfMoves} {(this.NumberOfMoves == 1 ? "move" : "moves")}.");

            if (this.playerPosition.Row == this.numberOfRows)
            {
                this.output.WriteLine("Congratulations, you have made it to the end!");
                return true;
            }

            return false;
        }

        private bool HasHitMine()
        {
            return Array.Exists<Position>(this.mines, x => x.Equals(this.playerPosition));
        }

        private static char GetLetterFromNumber(int number)
        {
            return (char)('A' + number - 1);
        }
    }
}
