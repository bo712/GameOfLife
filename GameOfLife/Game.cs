using System;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private Field _field;
        private Field _newField;

        public Game(int height, int width)
        {
            _field = new Field(height, width);
            _newField = new Field(height, width);
        }

        public void Start()
        {
            _field.FillField();
            while (true)
            {
                _field.PrintField();

                if (_field.CalculatePopulation() == 0)
                {
                    Console.WriteLine("All dead! All dead!");
                    break;
                }

                _field.CheckField(_newField);

                if (CheckGenerationsForEquality())
                {
                    DropRandomCells();
                }

                _field = _newField;
                _newField = new Field(_field._array.GetLength(0), _field._array.GetLength(1));
                Thread.Sleep(40);
            }
        }

        private void DropRandomCells()
        {
            var arrayHeight = _newField._array.GetLength(0);
            var arrayWidth = _newField._array.GetLength(1);
            var rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                _newField._array[rnd.Next(0, arrayHeight), rnd.Next(0, arrayWidth)] = '*';
            }
            Thread.Sleep(100);
        }

        private bool CheckGenerationsForEquality()
        {
            for (int i = 0; i < _field._array.GetLength(0); i++)
            {
                for (int j = 0; j < _field._array.GetLength(1); j++)
                {
                    if (_field._array[i, j] != _newField._array[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}