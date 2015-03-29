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
        public void CreatePlayerTurnManagerAndTakeTurn()
        {
            List<IPlayer> players = new List<IPlayer>();
            PlayerTurnManager playerTurnManager = new PlayerTurnManager(players);
        }
    }

    public class PlayerTurnManager
    {
        public PlayerTurnManager(IEnumerable<IPlayer> players)
        {
            
        }
    }
}
