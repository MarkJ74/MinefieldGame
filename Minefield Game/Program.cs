
namespace Minefield_Game
{
    using SimpleInjector;
    using System;

    internal class Program
    {
        private static readonly int numberOfColumns = 8;
        private static readonly int numberOfRows = 8;
        private static readonly int numberOfLives = 3;
        private static readonly int numberOfMines = 8;

        private static void Main(string[] args)
        {
            try
            {
                var container = GetContainer();

                var game = container.GetInstance<Game>();
                game.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Container GetContainer()
        {
            var container = new Container();

            container.Register<IInput, ConsoleInput>();
            container.Register<IOutput, ConsoleOutput>();
            container.Register<Game>(() => new Game(
                container.GetInstance<IInput>(),
                container.GetInstance<IOutput>(),
                numberOfColumns,
                numberOfRows,
                numberOfLives,
                numberOfMines));

            container.Verify();

            return container;
        }
    }
}
