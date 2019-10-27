using System;

namespace GameOfLife
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(30, 30);
            game.StartGame();
        }
    }
}