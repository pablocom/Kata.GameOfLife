using NUnit.Framework;

namespace Kata.GameOfLife.Tests
{
    public class GameOfLifeShould
    {
        private GameOfLife gameOfLife;

        [Test]
        public void RecognizeNoNeighborsAlive()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { false, false, false },
                new [] { false, true, false },
                new [] { false, false, false },
            });

            var neighborsAlive = gameOfLife.CountNeighborsAliveOfCell(1, 1);

            Assert.That(neighborsAlive, Is.EqualTo(0));
        }

        [Test]
        public void RecognizeOneNeighborsAlive()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { false, false, false },
                new [] { false, true, true },
                new [] { false, false, false }
            });

            var neighborsAlive = gameOfLife.CountNeighborsAliveOfCell(1, 1);

            Assert.That(neighborsAlive, Is.EqualTo(1));
        }

        [Test]
        public void RecognizeEightNeighborsAlive()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { true, true, true },
                new [] { true, true, true },
                new [] { true, true, true }
            });

            var neighborsAlive = gameOfLife.CountNeighborsAliveOfCell(1, 1);

            Assert.That(neighborsAlive, Is.EqualTo(8));
        }

        [TestCase(0, 0)]
        [TestCase(0, 2)]
        [TestCase(2, 0)]
        [TestCase(2, 2)]
        public void RecognizeThreeNeighborsAliveAtCorners(int x, int y)
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { true, true, true },
                new [] { true, true, true },
                new [] { true, true, true }
            });

            var neighborsAlive = gameOfLife.CountNeighborsAliveOfCell(x, y);

            Assert.That(neighborsAlive, Is.EqualTo(3));
        }

        [Test]
        public void MakeDieCellWithNoNeighbors()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { false, false, false },
                new [] { false, true, false },
                new [] { false, false, false }
            });

            gameOfLife.NextGeneration();    

            Assert.That(gameOfLife.CellsAliveCount, Is.EqualTo(0));
            Assert.That(gameOfLife.Board[1][1], Is.False);
        }

        [Test]
        public void MakeDieCellWithOneNeighbors()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { false, true, false },
                new [] { false, true, false },
                new [] { false, false, false }
            });

            gameOfLife.NextGeneration();

            Assert.That(gameOfLife.CellsAliveCount, Is.EqualTo(0));
            Assert.That(gameOfLife.Board[1][1], Is.False);
            Assert.That(gameOfLife.Board[0][1], Is.False);
        }

        [Test]
        public void MakeDieCellWithFourNeighbors()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { true, true, true },
                new [] { true, true, false },
                new [] { false, false, false }
            });

            gameOfLife.NextGeneration();
            
            Assert.That(gameOfLife.Board[0][1], Is.False);
            Assert.That(gameOfLife.Board[1][1], Is.False);
        }

        [Test]
        public void MakeLiveDeadCellWithExactThreeNeighborsAlive()
        {
            GivenGameOfLifeWithInitialState(new[]
            {
                new [] { false, true, false },
                new [] { true, true, false },
                new [] { false, false, false }
            });

            gameOfLife.NextGeneration();
            
            Assert.That(gameOfLife.Board[0][0], Is.True);
        }

        private void GivenGameOfLifeWithInitialState(bool[][] board)
        {
            gameOfLife = new GameOfLife(board);
        }
    }
}