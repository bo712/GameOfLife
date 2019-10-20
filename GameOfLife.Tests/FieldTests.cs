using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [TestCase(0, 0, ExpectedResult = 3)]
        [TestCase(1, 0, ExpectedResult = 4)]
        [TestCase(2, 0, ExpectedResult = 3)]
        [TestCase(3, 0, ExpectedResult = 3)]
        [TestCase(4, 0, ExpectedResult = 0)]
        [TestCase(0, 5, ExpectedResult = 3)]
        [TestCase(1, 5, ExpectedResult = 5)]
        [TestCase(2, 5, ExpectedResult = 5)]
        [TestCase(3, 5, ExpectedResult = 5)]
        [TestCase(4, 5, ExpectedResult = 3)]
        [TestCase(0, 1, ExpectedResult = 4)]
        [TestCase(0, 2, ExpectedResult = 5)]
        [TestCase(0, 3, ExpectedResult = 5)]
        [TestCase(0, 4, ExpectedResult = 5)]
        [TestCase(4, 1, ExpectedResult = 3)]
        [TestCase(4, 2, ExpectedResult = 3)]
        [TestCase(4, 3, ExpectedResult = 5)]
        [TestCase(4, 4, ExpectedResult = 5)]
        [TestCase(1, 1, ExpectedResult = 7)]
        [TestCase(1, 2, ExpectedResult = 7)]
        [TestCase(1, 3, ExpectedResult = 7)]
        [TestCase(1, 4, ExpectedResult = 7)]
        public int CalculateNeighbours_Points_ReturnRightAnswer(int indexV, int indexH)
        {
            var field = new Field(5, 6)
            {
                _array = new char[,]
                {
                    {' ', '*', '*', '*', '*', '*'},
                    {'*', '*', '*', '*', '*', '*'},
                    {'*', '*', '*', ' ', '*', '*'},
                    {' ', ' ', '*', '*', '*', '*'},
                    {'*', ' ', '*', '*', '*', '*'}
                }
            };
            return field.CalculateNeighbours(indexV, indexH, field._array);
        }
    }
}