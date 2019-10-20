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
            _array = new char[height, width];
            _height = _array.GetLength(0);
            _width = _array.GetLength(1);
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
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
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
                if (array[0, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[0, indexHoriz + 1] == '*')
                    neighbourCount++;
                if (array[1, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[1, indexHoriz] == '*')
                    neighbourCount++;
                if (array[1, indexHoriz + 1] == '*')
                    neighbourCount++;
            }
            
            //проверяем, если точка на левой грани, но не угловая
            else if (indexHoriz == 0)
            {
                if (array[indexVert - 1, 0] == '*')
                    neighbourCount++;
                if (array[indexVert - 1, 1] == '*')
                    neighbourCount++;
                if (array[indexVert, 1] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, 1] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, 0] == '*')
                    neighbourCount++;
            }
            
            //проверяем, если точка на нижней грани, но не угловая
            else if (indexVert == _height - 1)
            {
                if (array[indexVert - 1, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz] == '*')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz + 1] == '*')
                    neighbourCount++;
                if (array[indexVert, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert, indexHoriz + 1] == '*')
                    neighbourCount++;
            }
            
            //проверяем, если точка на правой грани, но не угловая
            else if (indexHoriz == _width - 1)
            {
                if (array[indexVert - 1, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz] == '*')
                    neighbourCount++;
                if (array[indexVert, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz] == '*')
                    neighbourCount++;
            }

            //проверяем, если центр
            else if (indexVert != 0 && indexVert != _width - 1 && indexHoriz != 0 && indexHoriz != _height - 1)
            {
                if (array[indexVert - 1, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz] == '*')
                    neighbourCount++;
                if (array[indexVert - 1, indexHoriz + 1] == '*')
                    neighbourCount++;
                if (array[indexVert, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert, indexHoriz + 1] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz - 1] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz] == '*')
                    neighbourCount++;
                if (array[indexVert + 1, indexHoriz + 1] == '*')
                    neighbourCount++;
            }

            return neighbourCount;
        }

        private static int CheckLowerRightCorner(int indexV, int indexH, char[,] array)
        {
            int neighbourCount = 0;
            if (array[indexV, indexH - 1] == '*')
                neighbourCount++;
            if (array[indexV - 1, indexH] == '*')
                neighbourCount++;
            if (array[indexV - 1, indexH - 1] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        private static int  CheckLowerLeftCorner (int indexV, int indexH, char[,] array)
        {
            int neighbourCount = 0;
            if (array[indexV - 1, indexH] == '*')
                neighbourCount++;
            if (array[indexV - 1, indexH + 1] == '*')
                neighbourCount++;
            if (array[indexV, indexH + 1] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckUpperRightCorner(int indexV, int indexH, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexV, indexH - 1] == '*')
                neighbourCount++;
            if (array[indexV + 1, indexH - 1] == '*')
                neighbourCount++;
            if (array[indexV + 1, indexH] == '*')
                neighbourCount++;
            return neighbourCount;
        }

        private static int CheckUpperLeftCorner(int indexV, int indexH, char[,] array)
        {
            var neighbourCount = 0;
            if (array[indexV, indexH + 1] == '*')
                neighbourCount++;
            if (array[indexV + 1, indexH] == '*')
                neighbourCount++;
            if (array[indexV + 1, indexH + 1] == '*')
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