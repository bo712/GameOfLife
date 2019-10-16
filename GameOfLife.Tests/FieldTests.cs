using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void CalculateNeighbours_Point_Ex()
        {
            Field field = new Field(4, 4)
            {
                array = new char[,]{  { ' ', '*', '*', '*'},
                                        { '*', '*', '*', '*'},
                                        { '*', '*', '*', '*'},
                                        { '*', '*', '*', '*'} }
            };
            int result = field.CalculateNeighbours(1,2, field.array);
            Assert.AreEqual(7, 7);
        }
    }
}
