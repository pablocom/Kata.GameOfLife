using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class GameOfLife 
    {
        public bool[][] Board { get; private set; }
        public int CellsAliveCount => Board.SelectMany(cellRow => cellRow).Count(cell => cell);

        public GameOfLife(bool[][] board)
        {
            Board = board;
        }

        public void NextGeneration()
        {
            var cellsToChange = new Dictionary<Tuple<int, int>, bool>();

            for (var i = 0; i < Board.Length; i++)
            for (var j = 0; j < Board[i].Length; j++)
            {
                if (Board[i][j])
                {
                    if (CountNeighborsAliveOfCell(i, j) < 2) 
                        cellsToChange.Add(new Tuple<int, int>(i, j), false);
                    if (CountNeighborsAliveOfCell(i, j) > 3) 
                        cellsToChange.Add(new Tuple<int, int>(i, j), false);
                }
                else if (CountNeighborsAliveOfCell(i, j) == 3)
                    cellsToChange.Add(new Tuple<int, int>(i, j), true);
            }

            foreach (var cellToChange in cellsToChange)
                Board[cellToChange.Key.Item1][cellToChange.Key.Item2] = cellToChange.Value;
        }

        public int CountNeighborsAliveOfCell(int x, int y)
        {
            var positionsToCheck = new List<Tuple<int, int>>();

            if (x > 0) 
                positionsToCheck.Add(new Tuple<int, int>(x - 1, y));
            if (y > 0) 
                positionsToCheck.Add(new Tuple<int, int>(x, y - 1));
            if (x < Board.Length - 1) 
                positionsToCheck.Add(new Tuple<int, int>(x + 1, y));
            if (y < Board[0].Length - 1) 
                positionsToCheck.Add(new Tuple<int, int>(x, y + 1));

            // Corners
            if (x > 0 && y > 0)
                positionsToCheck.Add(new Tuple<int, int>(x - 1, y - 1));
            if (x < Board.Length - 1 && y < Board[0].Length - 1)
                positionsToCheck.Add(new Tuple<int, int>(x + 1, y + 1));
            if (x > 0 && y < Board[0].Length - 1)
                positionsToCheck.Add(new Tuple<int, int>(x - 1, y + 1));
            if (x < Board.Length - 1 && y > 0)
                positionsToCheck.Add(new Tuple<int, int>(x + 1, y - 1));

            var count = 0;
            foreach (var positionToCheck in positionsToCheck)
                if (Board[positionToCheck.Item1][positionToCheck.Item2]) count++;

            return count;
        }
    }
}