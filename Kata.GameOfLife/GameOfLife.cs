using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class GameOfLife 
    {
        public bool[][] Board { get; private set; }
        
        public GameOfLife(bool[][] board)
        {
            Board = board;
        }

        public void NextGeneration()
        {
            
        }

        public int CountNeighborsAliveOfCell(int x, int y)
        {
            var positionsToCheck = new List<Tuple<int, int>>();

            if (x > 0) positionsToCheck.Add(new Tuple<int, int>(x - 1, y));
            if (y > 0) positionsToCheck.Add(new Tuple<int, int>(x, y - 1));
            if (x < Board.Length - 1) positionsToCheck.Add(new Tuple<int, int>(x + 1, y));
            if (y < Board[0].Length - 1) positionsToCheck.Add(new Tuple<int, int>(x, y + 1));

            if (x > 0 && y > 0)
                positionsToCheck.Add(new Tuple<int, int>(x - 1, y - 1));
            if (x < Board.Length - 1 && y < Board[0].Length - 1)
                positionsToCheck.Add(new Tuple<int, int>(x + 1, y + 1));

            if (x > 0 && y < Board[0].Length - 1)
                positionsToCheck.Add(new Tuple<int, int>(x - 1, y + 1));
            if (x < Board.Length - 1 && y > 0)
                positionsToCheck.Add(new Tuple<int, int>(x + 1, y - 1));

            return positionsToCheck.Count(positionToCheck => Board[positionToCheck.Item1][positionToCheck.Item2]);
        }
    }
}