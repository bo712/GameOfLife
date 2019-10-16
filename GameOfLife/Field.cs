using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Field
    {
        public char[,] array;
        int height;
        int width;

        public Field(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.array = new char[height, width];
        }

        public void FillArray()
        {
            Random rnd = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    this.array[i, j] = (rnd.Next() % 2 == 0) ? '*' : ' ';
                }
            }
        }

        private void CheckField()
        {
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    int neighbours = CalculateNeighbours(i, j, array);
                    if (neighbours < 3)
                    {

                    }
                    else if(neighbours > 3)
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
            CalculateNeighbours(indexX, indexY, array);
        }

        public int CalculateNeighbours(int indexX, int indexY, char[,] array)
        {
            int neighbourCount = 0;

            //проверяем, если это угловая точка
            if (indexX == 0 && indexY == 0)
            {
                if (array[indexX, indexY + 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY + 1] == '*')
                    neighbourCount++;
            }
            else if (indexX == 0 && indexY == this.height - 1)
            {
                if (array[indexX, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY - 1] == '*')
                    neighbourCount++;
                if (array[indexX + 1, indexY] == '*')
                    neighbourCount++;
            }
            else if (indexX == this.width - 1 && indexY == 0)
            {
                if (array[indexX - 1, indexY] == '*')
                    neighbourCount++;
                if (array[indexX - 1, indexY + 1] == '*')
                    neighbourCount++;
                if (array[indexX, indexY + 1] == '*')
                    neighbourCount++;
            }
            else if (indexX == this.height - 1 && indexY == this.width - 1)
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
            else if (indexX == width - 1)
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
            else if (indexY == height - 1)
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
            else if (indexX != 0 && indexX != this.width - 1 && indexY != 0 && indexY != this.height - 1)
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

        public void PrintField()
        {
            for (int i = 0; i < this.height; i++)
            {
                PrintRow(i);
            }
        }

        private void PrintRow(int rowNumber)
        {
            for (int i = 0; i < this.width; i++)
            {
                Console.Write(array[rowNumber, i] + " ");
            }
            Console.WriteLine();
        }
    }
}
