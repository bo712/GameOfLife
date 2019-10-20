using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [TestCase(0, 0, ExpectedResult = 3)]
        [TestCase(1, 0, ExpectedResult = 4)]
        [TestCase(2, 0, ExpectedResult = 5)]
        [TestCase(3, 0, ExpectedResult = 5)]
        [TestCase(4, 0, ExpectedResult = 3)]
        [TestCase(0, 1, ExpectedResult = 4)]
        public int CalculateNeighbours_Point_Ex(int indexV, int indexH)
        {
            var field = new Field(5, 6)
            {
                _array = new char[,]
                {
                    {' ', '*', '*', '*', '*', '*'},
                    {'*', '*', '*', '*', '*', '*'},
                    {'*', '*', '*', ' ', '*', '*'},
                    {'*', ' ', '*', '*', '*', '*'},
                    {'*', '*', '*', '*', '*', '*'}
                }
            };
            return field.CalculateNeighbours(indexV, indexH, field._array);
        }
    }
}