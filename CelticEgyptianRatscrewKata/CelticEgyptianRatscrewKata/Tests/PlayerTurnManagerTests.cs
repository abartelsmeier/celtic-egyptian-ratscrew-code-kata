using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class PlayerTurnManagerTests
    {
        [Test]
        public void CreatePlayerTurnManager()
        {
            List<IPlayer> players = new List<IPlayer>();
            PlayerTurnManager playerTurnManager = new PlayerTurnManager(players);
        }

        [Test]
        public void CreatePlayerTurnManagerAndPlayCard()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer>{playerA};
            PlayerTurnManager playerTurnManager = new PlayerTurnManager(players);

            PlayCardResult playResult = playerTurnManager.PlayCard(playerA);

            PlayCardResult expectedResult = new PlayCardResult(TurnResult.Success, Penalty.None);
            Assert.That(playResult, Is.EqualTo(expectedResult));
        }
    }

    public class PlayerTurnManager
    {
        public PlayerTurnManager(IEnumerable<IPlayer> players)
        {
            
        }
    }
}
