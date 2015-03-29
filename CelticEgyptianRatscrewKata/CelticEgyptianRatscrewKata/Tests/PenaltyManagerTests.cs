using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class PenaltyManagerTests
    {
        [Test]
        public void CreatePenaltyManagerInstance()
        {
            List<IPlayer> players = new List<IPlayer>(); 
            PenaltyManager penaltyManager = new PenaltyManager(players);
        }

        [Test]
        public void CreatePenaltyManagerAndTakeTurn()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer>{playerA};
            PenaltyManager penaltyManager = new PenaltyManager(players);

            Penalty penalty = penaltyManager.HasPenalty(playerA);
        }
    }

    public class PenaltyManager
    {
        private readonly IEnumerable<IPlayer> _players;

        public PenaltyManager(IEnumerable<IPlayer> players)
        {
            _players = players;
        }
    }
}
