using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Field
    {
        public char[,] Array;
        private readonly int _height;
        private readonly int _width;

        public Field(int height, int width)
        {
            _height = height;
            _width = width;
            Array = new char[height, width];
        }

        public void FillArray()
        {
            var rnd = new Random();
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    Array[i, j] = (rnd.Next() % 2 == 0) ? '*' : ' ';
                }
            }
        }

        private void CheckField()
        {
            for (var i = 0; i < this._width; i++)
            {
                for (var j = 0; j < this._height; j++)
                {
                    var neighbours = CalculateNeighbours(i, j, Array);
                    if (neighbours < 3)
                    {
                    }
                    else if (neighbours > 3)
                    {
                    }
                    else if (neighbours == 3)
                    {
                    }
                }
            }
        }

        private void CheckBorder()
        {
        }

        private void CheckCorner(int indexX, int indexY)
        {
        }

        private void CheckPoint(int indexX, int indexY)
        {
            CalculateNeighbours(indexX, indexY, Array);
        }

        public int CalculateNeighbours(int indexX, int indexY, char[,] array)
        {
            var neighbourCount = 0;

            switch (indexX)
            {
                //проверяем, если это угловая точка
                case 0 when indexY == 0:
                {
                    if (array[indexX, indexY + 1] == '*')
                        neighbourCount++;
                    if (array[indexX + 1, indexY] == '*')
                        neighbourCount++;
                    if (array[indexX + 1, indexY + 1] == '*')
                        neighbourCount++;
                    break;
                }
                case 0 when indexY == _height - 1:
                {
                    if (array[indexX, indexY - 1] == '*')
                        neighbourCount++;
                    if (array[indexX + 1, indexY - 1] == '*')
                        neighbourCount++;
                    if (array[indexX + 1, indexY] == '*')
                        neighbourCount++;
                    break;
                }
                default:
                {
                    if (indexX == this._width - 1 && indexY == 0)
                    {
                        if (array[indexX - 1, indexY] == '*')
                            neighbourCount++;
                        if (array[indexX - 1, indexY + 1] == '*')
                            neighbourCount++;
                        if (array[indexX, indexY + 1] == '*')
                            neighbourCount++;
                    }
                    else if (indexX == this._height - 1 && indexY == this._width - 1)
                    {
                        if (array[indexX, indexY - 1] == '*')
                            neighbourCount++;
                        if (array[indexX - 1, indexY] == '*')
                            neighbourCount++;
                        if (array[indexX - 1, indexY - 1] == '*')
                            neighbourCount++;
                    }

                    //проверяем, если это боковая, но не угловая
                    else if (indexX == 0)
                    {
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
                    else if (indexY == 0)
                    {
                        if (array[indexX - 1, indexY] == '*')
                            neighbourCount++;
                        if (array[indexX - 1, indexY + 1] == '*')
                            neighbourCount++;
                        if (array[indexX, indexY + 1] == '*')
                            neighbourCount++;
                        if (array[indexX + 1, indexY] == '*')
                            neighbourCount++;
                        if (array[indexX + 1, indexY + 1] == '*')
                            neighbourCount++;
                    }
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
                    else if (indexX != 0 && indexX != this._width - 1 && indexY != 0 && indexY != this._height - 1)
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

                    break;
                }
            }

            return neighbourCount;
        }

        public void PrintField()
        {
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
    }
}