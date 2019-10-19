using System;

namespace GameOfLife
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var field = new Field(10, 10);
            field.FillArray();
            field.PrintField();
            var newField = new Field(10, 10);
        }
    }
}