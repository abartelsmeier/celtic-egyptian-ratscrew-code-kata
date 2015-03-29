using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using NSubstitute.Routing.Handlers;
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
        public void CreatePenaltyManagerAndQueryPenalty()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer>{playerA};
            PenaltyManager penaltyManager = new PenaltyManager(players);

            Penalty penalty = penaltyManager.HasPenalty(playerA);

            Assert.That(penalty, Is.EqualTo(Penalty.None));
        }

        [Test]
        public void CreatePenaltyManagerAndImposePlayOutOfTurnPenalty()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer> { playerA };
            PenaltyManager penaltyManager = new PenaltyManager(players);

            penaltyManager.ImposePenalty(playerA, Penalty.PlayedOutOfTurn);

            Penalty imposedPenalty = penaltyManager.HasPenalty(playerA);
            Assert.That(imposedPenalty, Is.EqualTo(Penalty.PlayedOutOfTurn));
        }
    }
}
