using System;

namespace GameOfLife
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(15, 10);
            game.Start();
        }
    }
}