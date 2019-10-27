using System;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        public World CurrentGeneration { get; private set; }
        public World NextGeneration { get; private set; }
        public World PrevGeneration { get; private set; }

        public Game(int height, int width)
        {
            CurrentGeneration = new World(height, width);
            NextGeneration = new World(height, width);
            PrevGeneration = new World(height, width);
        }

        public void StartGame()
        {
            CurrentGeneration.FillField();

            while (true)
            {
                CurrentGeneration.PrintField();
                if (CheckPopulationForZero()) break;
                CurrentGeneration.BornNextGeneration(NextGeneration);
                TryToFixStalemate();
                ShiftGenerations();
                Thread.Sleep(100);
            }
        }

        private void TryToFixStalemate()
        {
            if (CheckCurrentAndNextGenerationsForEquality() || CheckPrevAndNextGenerationsForEquality())
            {
                DropRandomCells();
            }
        }

        private bool CheckPopulationForZero()
        {
            if (CurrentGeneration.CalculatePopulation() != 0) return false;
            Console.WriteLine("All dead! All dead!");
            return true;
        }

        private void ShiftGenerations()
        {
            PrevGeneration = CurrentGeneration;
            CurrentGeneration = NextGeneration;
            NextGeneration = new World(CurrentGeneration.Array.GetLength(0), CurrentGeneration.Array.GetLength(1));
        }

        private void DropRandomCells()
        {
            var arrayHeight = NextGeneration.Array.GetLength(0);
            var arrayWidth = NextGeneration.Array.GetLength(1);
            var rnd = new Random();

            for (var i = 0; i < 4; i++)
            {
                NextGeneration.Array[rnd.Next(0, arrayHeight), rnd.Next(0, arrayWidth)] = '*';
            }
        }

        public bool CheckCurrentAndNextGenerationsForEquality()
        {
            for (var i = 0; i < CurrentGeneration.Array.GetLength(0); i++)
            {
                for (var j = 0; j < CurrentGeneration.Array.GetLength(1); j++)
                {
                    if (CurrentGeneration.Array[i, j] != NextGeneration.Array[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckPrevAndNextGenerationsForEquality()
        {
            for (var i = 0; i < PrevGeneration.Array.GetLength(0); i++)
            {
                for (var j = 0; j < PrevGeneration.Array.GetLength(1); j++)
                {
                    if (PrevGeneration.Array[i, j] != NextGeneration.Array[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}