using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(10, 10);
            field.FillArray();
            field.PrintField();
            Field newField = new Field(10, 10);
        }
    }
}
