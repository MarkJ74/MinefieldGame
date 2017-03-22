
namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minefield_Game;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_StartsWithZeroMoves()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 1, 2, 3, 4);

            Assert.AreEqual(0, game.NumberOfMoves);
        }

        [TestMethod]
        public void Game_Move_IncrementsNumberOfMoves()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);
            game.Move(1, 0);

            Assert.AreEqual(1, game.NumberOfMoves);
        }

        [TestMethod]
        public void Game_StartsWithPlayerAtColumnOne()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);

            Assert.AreEqual(1, game.playerPosition.Column);
        }

        [TestMethod]
        public void Game_StartsWithPlayerAtRowOne()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);

            Assert.AreEqual(1, game.playerPosition.Row);
        }

        [TestMethod]
        public void Game_Move_MovesPlayerColumn()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);

            game.Move(1, 0);

            Assert.AreEqual(2, game.playerPosition.Column);
        }

        [TestMethod]
        public void Game_Move_MovesPlayerRow()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);

            game.Move(0, 1);

            Assert.AreEqual(2, game.playerPosition.Row);
        }

        [TestMethod]
        public void Game_Move_WontMovePlayerColumnLessThanOne()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);

            game.Move(-1, 0);

            Assert.AreEqual(1, game.playerPosition.Column);
        }

        [TestMethod]
        public void Game_Move_WontMovePlayerColumnGreaterThanLastColumn()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 1, 1, 3, 0);

            game.Move(1, 0);

            Assert.AreEqual(1, game.playerPosition.Column);
        }

        [TestMethod]
        public void Game_Move_WontMovePlayerRowLessThanOne()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 4, 4, 3, 0);

            game.Move(0, -1);

            Assert.AreEqual(1, game.playerPosition.Column);
        }

        [TestMethod]
        public void Game_Move_WontMovePlayerRowGreaterThanLastRow()
        {
            var output = new ConsoleOutput();
            var input = new ConsoleInput(output);
            var game = new Game(input, output, 1, 1, 3, 0);

            game.Move(0, 1);

            Assert.AreEqual(1, game.playerPosition.Column);
        }
    }
}
