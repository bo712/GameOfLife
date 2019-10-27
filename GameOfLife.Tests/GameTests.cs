using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void CheckCurrentAndNextGenerationsForEquality_currentNextEqual_ReturnsTrue()
        {
            var game = new Game(5, 5)
            {
                CurrentGeneration =
                {
                    Array = new char[,]
                    {
                        {' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' '}
                    }
                },
                NextGeneration =
                {
                    Array = new char[,]
                    {
                        {' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' '}
                    }
                }
            };

            var result = game.CheckCurrentAndNextGenerationsForEquality();
            Assert.True(result);
        }
        
        [Test]
        public void CheckPrevAndNextGenerationsForEquality_prevNextEqual_ReturnsTrue()
        {
            var game = new Game(5, 5)
            {
                PrevGeneration =
                {
                    Array = new char[,]
                    {
                        {' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' '}
                    }
                },
                NextGeneration =
                {
                    Array = new char[,]
                    {
                        {' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', '*', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' '}
                    }
                }
            };

            var result = game.CheckPrevAndNextGenerationsForEquality();
            Assert.True(result);
        }
    }
}