using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class PlayerTurnManagerTests
    {
        [Test]
        public void CreatePlayerTurnManager()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer>{playerA};
            var gameMock = new Mock<IGameController>();
            gameMock.Setup(x => x.Players).Returns(players);
            var penaltyManager = new PenaltyManager(gameMock.Object.Players);

            var playerTurnManager = new PlayerTurnManager(gameMock.Object, penaltyManager);
        }

        [Test]
        public void CreatePlayerTurnManagerAndPlayCard()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer>{playerA};
            Card aceOfClubs = new Card(Suit.Clubs, Rank.Ace);
            var gameMock = new Mock<IGameController>();
            gameMock.Setup(x => x.Players).Returns(players);
            gameMock.Setup(x => x.PlayCard(playerA)).Returns(aceOfClubs);
            var penaltyManager = new PenaltyManager(gameMock.Object.Players);
            var playerTurnManager = new PlayerTurnManager(gameMock.Object, penaltyManager);

            var playResult = playerTurnManager.PlayCard(playerA);

            var expectedResult = new PlayerTurnResult(aceOfClubs, "PlayerA played Card Ace of Clubs");
            Assert.That(playResult, Is.EqualTo(expectedResult));
        }
    }
}
