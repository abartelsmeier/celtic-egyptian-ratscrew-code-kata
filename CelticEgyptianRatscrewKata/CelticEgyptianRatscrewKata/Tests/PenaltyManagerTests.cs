using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.PenaltyManagement;
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
