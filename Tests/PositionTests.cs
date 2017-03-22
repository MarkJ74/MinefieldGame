
namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minefield_Game;

    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void Position_Equals_IfColumnsAreDifferentThenReturnsFalse()
        {
            var positionA = new Position { Column = 1, Row = 2 };
            var positionB = new Position { Column = 3, Row = 2 };

            Assert.IsFalse(positionA.Equals(positionB));
        }

        [TestMethod]
        public void Position_Equals_IfRowsAreDifferentThenReturnsFalse()
        {
            var positionA = new Position { Column = 1, Row = 2 };
            var positionB = new Position { Column = 1, Row = 3 };

            Assert.IsFalse(positionA.Equals(positionB));
        }

        [TestMethod]
        public void Position_Equals_IfColumnsAndRowsAreSameThenReturnsTrue()
        {
            var positionA = new Position { Column = 1, Row = 2 };
            var positionB = new Position { Column = 1, Row = 2 };

            Assert.IsTrue(positionA.Equals(positionB));
        }
    }
}
