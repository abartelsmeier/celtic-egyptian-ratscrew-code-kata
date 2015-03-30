using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class PlayerSnapManagerTests
    {
        [Test]
        public void CreatePlayerSnapManager()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer> { playerA };
            var gameMock = new Mock<IGameController>();
            gameMock.Setup(x => x.Players).Returns(players);
            var penaltyManager = new PenaltyManager(gameMock.Object.Players);

            PlayerSnapManager playerSnapManager = new PlayerSnapManager(gameMock.Object, penaltyManager);
        }

        [Test]
        public void CreatePlayerSnapManagerAndAttemptSnap()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer> { playerA };
            var gameMock = new Mock<IGameController>();
            gameMock.Setup(x => x.Players).Returns(players);
            gameMock.Setup(x => x.AttemptSnap(playerA)).Returns(true);
            var penaltyManager = new PenaltyManager(gameMock.Object.Players);
            PlayerSnapManager playerSnapManager = new PlayerSnapManager(gameMock.Object, penaltyManager);

            bool result = playerSnapManager.AttemptSnap(playerA);

            bool expectedResult = true;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

    public class PlayerSnapManager
    {
        public PlayerSnapManager(IGameController gameController, IPenaltyManager penaltyManager)
        {
            
        }
    }
}
