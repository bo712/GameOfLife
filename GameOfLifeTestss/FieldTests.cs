using NUnit.Framework;

//namespace Tests
//{
//    [TestFixture]
//    public class FieldTests
//    {
//        [Test]
//        public void Test1()
//        {
//            Assert.Pass();
//        }
//    }
//}

namespace GameOfLife.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void CalculateNeighbours_Point1_1_Return7()
        {
            Field field = new Field(4, 4)
            {
                array = new char[,]{{ ' ', '*', '*', '*'},
                                    { '*', '*', '*', '*'},
                                    { '*', '*', '*', '*'},
                                    { '*', '*', '*', '*'} }
            };
            int result = field.CalculateNeighbours(1, 1, field.array);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void CalculateNeighbours_Point0_0_Return3()
        {
            Field field = new Field(4, 4)
            {
                array = new char[,]{{ ' ', '*', '*', '*'},
                                    { '*', '*', '*', '*'},
                                    { '*', '*', '*', '*'},
                                    { '*', '*', '*', '*'} }
            };
            int result = field.CalculateNeighbours(0, 0, field.array);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void CalculateNeighbours_Point0_1_Return4()
        {
            Field field = new Field(4, 4)
            {
                array = new char[,]{{ ' ', '*', '*', '*'},
                                    { '*', '*', '*', '*'},
                                    { '*', '*', '*', '*'},
                                    { '*', '*', '*', '*'} }
            };
            int result = field.CalculateNeighbours(0, 1, field.array);
            Assert.AreEqual(4, result);
        }
    }
}