using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void CalculateNeighbours_Point_Ex()
        {
            var field = new Field(4, 4)
            {
                Array = new char[,]
                {
                    {' ', '*', '*', '*'},
                    {'*', '*', '*', '*'},
                    {'*', '*', '*', '*'},
                    {'*', '*', '*', '*'}
                }
            };
            var result = field.CalculateNeighbours(1, 2, field.Array);
            Assert.AreEqual(7, 7);
        }
    }
}