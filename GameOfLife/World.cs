using System;
using System.Linq;

namespace GameOfLife
{
    public class World
    {
        public char[,] Array { get; set;}
        private readonly int _height;
        private readonly int _width;

        public World(int height, int width)
        {
            Array = new char[height, width];
            _height = Array.GetLength(0);
            _width = Array.GetLength(1);
        }

        public void FillField()
        {
            var rnd = new Random();
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    Array[i, j] = (rnd.Next() % 2 == 0) ? 'o' : ' ';
                }
            }
        }

        public void BornNextGeneration(World newWorld)
        {
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    var neighbours = CalculateNeighbours(i, j, Array);
                    if (Array[i, j] == ' ' && neighbours == 3)
                    {
                        newWorld.Array[i, j] = 'o';
                    }
                    else if (Array[i, j] == ' ' && neighbours != 3)
                    {
                        newWorld.Array[i, j] = ' ';
                    }
                    else if (Array[i, j] == 'o' && (neighbours < 2 || neighbours > 3))
                    {
                        newWorld.Array[i, j] = ' ';
                    }
                    else
                    {
                        newWorld.Array[i, j] = 'o';
                    }
                }
            }
        }

        public int CalculateNeighbours(int indexVert, int indexHoriz, char[,] array)
        {
            var neighbourCount = 0;
            //проверяем, если это угловые точки
            if (indexVert == 0 && indexHoriz == 0)
            {
                neighbourCount += CheckUpperLeftCorner(indexVert, indexHoriz, array);
            }
            else if (indexVert == 0 && indexHoriz == _width - 1)
            {
                neighbourCount += CheckUpperRightCorner(indexVert, indexHoriz, array);
            }
            else if (indexVert == _height - 1 && indexHoriz == 0)
            {
                neighbourCount += CheckLowerLeftCorner(indexVert, indexHoriz, array);
            }
            else if (indexVert == _height - 1 && indexHoriz == _width - 1)
            {
                neighbourCount += CheckLowerRightCorner(indexVert, indexHoriz, array);
            }

            //проверяем, если точка на верхней грани, но не угловая
            else if (indexVert == 0)
            {
                if (array[0, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[0, indexHoriz + 1] == 'o')
                    neighbourCount++;
                if (array[1, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[1, indexHoriz] == 'o')
                    neighbourCount++;
                if (array[1, indexHoriz + 1] == 'o')
                    neighbourCount++;
            }

            //проверяем, если точка на левой грани, но не угловая
            else if (indexHoriz == 0)
            {
                if (array[indexVert - 1, 0] == 'o')
                    neighbourCount++;
                if (array[indexVert - 1, 1] == 'o')
                    neighbourCount++;
                if (array[indexVert, 1] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, 1] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, 0] == 'o')
                    neighbourCount++;
            }

            //проверяем, если точка на нижней грани, но не угловая
            else if (indexVert == _height - 1)
            {
                if (array[indexVert - 1, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz] == 'o')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz + 1] == 'o')
                    neighbourCount++;
                if (array[indexVert, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert, indexHoriz + 1] == 'o')
                    neighbourCount++;
            }

            //проверяем, если точка на правой грани, но не угловая
            else if (indexHoriz == _width - 1)
            {
                if (array[indexVert - 1, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz] == 'o')
                    neighbourCount++;
                if (array[indexVert, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz] == 'o')
                    neighbourCount++;
            }

            //проверяем, если центр
            else /*if (indexVert != 0 && indexVert != _width - 1 && indexHoriz != 0 && indexHoriz != _height - 1)*/
            {
                if (array[indexVert - 1, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz] == 'o')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz + 1] == 'o')
                    neighbourCount++;
                if (array[indexVert, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert, indexHoriz + 1] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz - 1] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz] == 'o')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz + 1] == 'o')
                    neighbourCount++;
            }

            return neighbourCount;
        }

        private static int CheckLowerRightCorner(int indexV, int indexH, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexV, indexH - 1] == 'o')
                neighbourCount++;
            if (array[indexV - 1, indexH] == 'o')
                neighbourCount++;
            if (array[indexV - 1, indexH - 1] == 'o')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckLowerLeftCorner(int indexV, int indexH, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexV - 1, indexH] == 'o')
                neighbourCount++;
            if (array[indexV - 1, indexH + 1] == 'o')
                neighbourCount++;
            if (array[indexV, indexH + 1] == 'o')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckUpperRightCorner(int indexV, int indexH, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexV, indexH - 1] == 'o')
                neighbourCount++;
            if (array[indexV + 1, indexH - 1] == 'o')
                neighbourCount++;
            if (array[indexV + 1, indexH] == 'o')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckUpperLeftCorner(int indexV, int indexH, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexV, indexH + 1] == 'o')
                neighbourCount++;
            if (array[indexV + 1, indexH] == 'o')
                neighbourCount++;
            if (array[indexV + 1, indexH + 1] == 'o')
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
                Console.Write(Array[rowNumber, i] + " ");
            }

            Console.WriteLine();
        }

        public int CalculatePopulation()
        {
            return Array.Cast<char>().Count(point => point == 'o');
        }
    }
}