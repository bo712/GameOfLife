using System;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private Field _field;
        private  Field _newField;

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
                _field.CheckField(_newField);
                _field = _newField;
                Thread.Sleep(300);
            }
        }
    }
}