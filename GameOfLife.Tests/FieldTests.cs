using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [TestCase(0,0,3)]
        [TestCase(1,0,4)]
        [TestCase(2,0,5)]
        [TestCase(3,0,5)]
        [TestCase(4,0,3)]
        [TestCase(0,1,4)]
        public void CalculateNeighbours_Point_Ex(int indexX, int indexY, int expected)
        {
            var field = new Field(5, 5)
            {
                _array = new char[,]
                {
                    {' ', '*', '*', '*', '*'},
                    {'*', '*', '*', '*', '*'},
                    {'*', '*', '*', ' ', '*'},
                    {'*', '*', '*', '*', '*'},
                    {'*', '*', '*', '*', '*'}
                }
            };
            var result = field.CalculateNeighbours(indexX, indexY, field._array);
            Assert.AreEqual(expected, result);
        }
    }
}