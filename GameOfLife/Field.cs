using System;

namespace GameOfLife
{
    public class Field
    {
        public char[,] _array;
        private readonly int _height;
        private readonly int _width;

        public Field(int height, int width)
        {
            _height = height;
            _width = width;
            _array = new char[height, width];
        }

        public void FillField()
        {
            var rnd = new Random();
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    _array[i, j] = (rnd.Next() % 2 == 0) ? '*' : ' ';
                }
            }
        }

        public void CheckField(Field newField)
        {
            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    var neighbours = CalculateNeighbours(i, j, _array);
                    if (neighbours < 2 || neighbours > 3)
                    {
                        newField._array[i, j] = ' ';
                    }
                    else
                    {
                        newField._array[i, j] = '*';
                    }
                }
            }
        }

        public int CalculateNeighbours(int indexX, int indexY, char[,] array)
        {
            var neighbourCount = 0;
            //проверяем, если это угловые точки
            if (indexX == 0 && indexY == 0)
            {
                neighbourCount += CheckUpperLeftCorner(indexX, indexY, array);
            }
            else if (indexX == 0 && indexY == _height - 1)
            {
                neighbourCount += CheckLowerLeftCorner(indexX, indexY, array);
            }
            else if (indexX == _width - 1 && indexY == 0)
            {
                neighbourCount += CheckUpperRightCorner(indexX, indexY, array);
            }
            else if (indexX == _width - 1 && indexY == _height - 1)
            {
                neighbourCount += CheckLowerRightCorner(indexX, indexY, array);
            }

            //проверяем, если точка на левой грани, но не угловая
            else if (indexX == 0)
            {
                if (array[0, indexY - 1] == '*')
                    neighbourCount++;
                if (array[0, indexY + 1] == '*')
                    neighbourCount++;
                if (array[1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[1, indexY] == '*')
                    neighbourCount++;
                if (array[1, indexY + 1] == '*')
                    neighbourCount++;
            }
            
            //проверяем, если точка на верхней грани, но не угловая
            else if (indexY == 0)
            {
                if (array[indexX - 1, 0] == '*')
                    neighbourCount++;
                if (array[indexX - 1, 1] == '*')
                    neighbourCount++;
                if (array[indexX, 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, 0] == '*')
                    neighbourCount++;
            }
            
            //проверяем, если точка на правой грани, но не угловая
            else if (indexX == _width - 1)
            {
                if (array[indexX - 1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX - 1, indexY] == '*')
                    neighbourCount++;
                if (array[indexX - 1, indexY + 1] == '*')
                    neighbourCount++;
                if (array[indexX, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX, indexY + 1] == '*')
                    neighbourCount++;
            }
            
            //проверяем, если точка на нижней грани, но не угловая
            else if (indexY == _height - 1)
            {
                if (array[indexX - 1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX - 1, indexY] == '*')
                    neighbourCount++;
                if (array[indexX, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY] == '*')
                    neighbourCount++;
            }

            //проверяем, если центр
            else if (indexX != 0 && indexX != _width - 1 && indexY != 0 && indexY != _height - 1)
            {
                if (array[indexX - 1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX - 1, indexY] == '*')
                    neighbourCount++;
                if (array[indexX - 1, indexY + 1] == '*')
                    neighbourCount++;
                if (array[indexX, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX, indexY + 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY + 1] == '*')
                    neighbourCount++;
            }

            return neighbourCount;
        }

        private static int CheckLowerRightCorner(int indexX, int indexY, char[,] array)
        {
            int neighbourCount = 0;
            if (array[indexX, indexY - 1] == '*')
                neighbourCount++;
            if (array[indexX - 1, indexY] == '*')
                neighbourCount++;
            if (array[indexX - 1, indexY - 1] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckUpperRightCorner(int indexX, int indexY, char[,] array)
        {
            int neighbourCount = 0;
            if (array[indexX - 1, indexY] == '*')
                neighbourCount++;
            if (array[indexX - 1, indexY + 1] == '*')
                neighbourCount++;
            if (array[indexX, indexY + 1] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckLowerLeftCorner(int indexX, int indexY, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexX, indexY - 1] == '*')
                neighbourCount++;
            if (array[indexX + 1, indexY - 1] == '*')
                neighbourCount++;
            if (array[indexX + 1, indexY] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckUpperLeftCorner(int indexX, int indexY, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexX, indexY + 1] == '*')
                neighbourCount++;
            if (array[indexX + 1, indexY] == '*')
                neighbourCount++;
            if (array[indexX + 1, indexY + 1] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        public void PrintField()
        {
            Console.Clear();
            for (var i = 0; i < _height; i++)
            {
                PrintRow(i);
            }
        }

        private void PrintRow(int rowNumber)
        {
            for (var i = 0; i < _width; i++)
            {
                Console.Write(_array[rowNumber, i] + " ");
            }

            Console.WriteLine();
        }
    }
}