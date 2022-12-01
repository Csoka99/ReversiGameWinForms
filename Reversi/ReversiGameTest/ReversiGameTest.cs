using Moq;
using ReversiGame.Model;
using ReversiGame.Persistence;
using System.Drawing;
using System.Drawing.Text;

namespace ReversiGameTest
{
    [TestClass]
    public class ReversiGameTest
    {
        private ReversiModel model;
        private Mock<IDataAccess> mock;
        private FieldStates[,] mockedBoard;
        private int mockedBlackNum;
        private int mockedWhiteNum;
        private int mockedSize;
        private FieldStates _current;

        [TestInitialize]
        public void Initialize()
        {
            mockedSize = 10;
            mockedBoard = new FieldStates[mockedSize,mockedSize];
            mockedBlackNum = 2;
            mockedWhiteNum = 2;
            _current = FieldStates.Black;

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    mockedBoard[i, j] = FieldStates.Empty;
                }
            }

            var half = mockedSize / 2;

            mockedBoard[half - 1, half - 1] = FieldStates.Black;
            mockedBoard[half - 1, half] = FieldStates.White;
            mockedBoard[half, half] = FieldStates.Black;
            mockedBoard[half, half - 1] = FieldStates.White;

            mockedBoard[3, 5] = FieldStates.ValidMove;
            mockedBoard[4, 6] = FieldStates.ValidMove;
            mockedBoard[5, 3] = FieldStates.ValidMove;
            mockedBoard[6, 4] = FieldStates.ValidMove;

            mock = new Mock<IDataAccess>();
            mock.Setup(mock => mock.LoadGameAsync(It.IsAny<String>()))
                .Returns(() => Task.FromResult((mockedSize,_current,mockedBlackNum, mockedWhiteNum,mockedBoard)));

            model = new ReversiModel(mock.Object);
        }


        [TestMethod]
        public void ReversiModelNewGameTenTest()
        {
            model.StartNewGame(mockedSize);

            Assert.AreEqual(model.BlackNum, mockedBlackNum);
            Assert.AreEqual(model.WhiteNum, mockedWhiteNum);

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    Assert.AreEqual(model.Board[i, j], mockedBoard[i, j]);
                }
            }

        }

        [TestMethod]
        public void ReversiModelNewGameTwentyTest()
        {
            mockedSize = 20;
            mockedBoard = new FieldStates[mockedSize, mockedSize];
            mockedBlackNum = 2;
            mockedWhiteNum = 2;

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    mockedBoard[i, j] = FieldStates.Empty;
                }
            }

            var half = mockedSize / 2;

            mockedBoard[half - 1, half - 1] = FieldStates.Black;
            mockedBoard[half - 1, half] = FieldStates.White;
            mockedBoard[half, half] = FieldStates.Black;
            mockedBoard[half, half - 1] = FieldStates.White;

            mockedBoard[8, 10] = FieldStates.ValidMove;
            mockedBoard[9, 11] = FieldStates.ValidMove;
            mockedBoard[10, 8] = FieldStates.ValidMove;
            mockedBoard[11, 9] = FieldStates.ValidMove;

            model.StartNewGame(mockedSize);

            Assert.AreEqual(model.BlackNum, mockedBlackNum);
            Assert.AreEqual(model.WhiteNum, mockedWhiteNum);

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    Assert.AreEqual(model.Board[i, j], mockedBoard[i, j]);
                }
            }

        }

        [TestMethod]
        public void ReversiModelNewGameThirtyTest()
        {
            mockedSize = 30;
            mockedBoard = new FieldStates[mockedSize, mockedSize];
            mockedBlackNum = 2;
            mockedWhiteNum = 2;

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    mockedBoard[i, j] = FieldStates.Empty;
                }
            }

            var half = mockedSize / 2;

            mockedBoard[half - 1, half - 1] = FieldStates.Black;
            mockedBoard[half - 1, half] = FieldStates.White;
            mockedBoard[half, half] = FieldStates.Black;
            mockedBoard[half, half - 1] = FieldStates.White;

            mockedBoard[13, 15] = FieldStates.ValidMove;
            mockedBoard[14, 16] = FieldStates.ValidMove;
            mockedBoard[15, 13] = FieldStates.ValidMove;
            mockedBoard[16, 14] = FieldStates.ValidMove;

            model.StartNewGame(mockedSize);

            Assert.AreEqual(model.BlackNum, mockedBlackNum);
            Assert.AreEqual(model.WhiteNum, mockedWhiteNum);

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    Assert.AreEqual(model.Board[i, j], mockedBoard[i, j]);
                }
            }

        }

        [TestMethod]
        public void ReversiModelStepTest()
        {
            model.StartNewGame(mockedSize);
            model.FieldClicked(3, 5);

            mockedBoard[4, 6] = FieldStates.Empty;
            mockedBoard[5, 3] = FieldStates.Empty;
            mockedBoard[6, 4] = FieldStates.Empty;
            mockedBoard[3, 5] = FieldStates.Black;
            mockedBoard[4, 5] = FieldStates.Black;
            mockedBoard[3, 4] = FieldStates.ValidMove;
            mockedBoard[3, 6] = FieldStates.ValidMove;
            mockedBoard[5, 6] = FieldStates.ValidMove;

            mockedBlackNum = 4;
            mockedWhiteNum = 1;

            Assert.AreEqual(model.BlackNum, mockedBlackNum);
            Assert.AreEqual(model.WhiteNum, mockedWhiteNum);

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    Assert.AreEqual(model.Board[i, j], mockedBoard[i, j]);
                }
            }
        }

        [TestMethod]
        public void ReversiModelGameOverTest()
        {
            model.StartNewGame(mockedSize);
            model.FieldClicked(3, 5);

            mockedBoard[4, 6] = FieldStates.Empty;
            mockedBoard[5, 3] = FieldStates.Empty;
            mockedBoard[6, 4] = FieldStates.Empty;
            mockedBoard[3, 5] = FieldStates.Black;
            mockedBoard[4, 5] = FieldStates.Black;
            mockedBoard[3, 4] = FieldStates.ValidMove;
            mockedBoard[3, 6] = FieldStates.ValidMove;
            mockedBoard[5, 6] = FieldStates.ValidMove;

            mockedBlackNum = 4;
            mockedWhiteNum = 1;

            Assert.AreEqual(model.BlackNum, mockedBlackNum);
            Assert.AreEqual(model.WhiteNum, mockedWhiteNum);

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    Assert.AreEqual(model.Board[i, j], mockedBoard[i, j]);
                }
            }

            Winner mockedWinner = Winner.Black;

            model.GameOverModel();

            Assert.AreEqual(mockedWinner,model.Winner);

        }

        [TestMethod]
        public void ReversiModelLoadTest()
        {
            mockedSize = 10;

            model.StartNewGame(mockedSize);

            model.LoadGame(String.Empty);

            for (int i = 0; i < mockedSize; i++)
            {
                for (int j = 0; j < mockedSize; j++)
                {
                    Assert.AreEqual(mockedBoard[i, j], model.Board[i, j]);
                }
            }

            mock.Verify(dataAccess => dataAccess.LoadGameAsync(String.Empty), Times.Once());

        }
    }
}
