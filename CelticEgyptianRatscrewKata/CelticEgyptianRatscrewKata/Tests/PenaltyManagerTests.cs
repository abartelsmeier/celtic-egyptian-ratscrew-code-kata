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
    }

    public enum Penalty
    {
        None
    }

    public class PenaltyManager
    {
        private readonly IDictionary<IPlayer, Penalty> _penalties;

        public PenaltyManager(IEnumerable<IPlayer> players)
        {
            _penalties = new Dictionary<IPlayer, Penalty>();
            foreach (var player in players)
            {
                _penalties.Add(player, Penalty.None);
            }
        }

        public Penalty HasPenalty(IPlayer player)
        {
            if (_penalties.ContainsKey(player)) return _penalties[player];
            return Penalty.None;
        }
    }
}
