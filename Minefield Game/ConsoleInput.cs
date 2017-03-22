
namespace Minefield_Game
{
    using System;

    public class ConsoleInput : IInput
    {
        private readonly IOutput output;

        public ConsoleInput(IOutput output)
        {
            this.output = output;
        }

        public Command GetCommand()
        {
            for (;;)
            {
                this.output.Write("> ");

                var str = Console.ReadLine();

                if (str.Length == 1)
                {
                    var c = str.ToUpper()[0];

                    switch (c)
                    {
                        case 'U':
                            return Command.Up;

                        case 'D':
                            return Command.Down;

                        case 'L':
                            return Command.Left;

                        case 'R':
                            return Command.Right;

                        case 'X':
                            return Command.Exit;
                    }
                }

                this.output.WriteLine("Input error, type U, D, L, R or X.");
            }
        }
    }
}
