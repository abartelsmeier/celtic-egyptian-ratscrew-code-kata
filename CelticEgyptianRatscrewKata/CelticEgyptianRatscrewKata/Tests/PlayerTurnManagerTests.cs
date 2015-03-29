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

    public enum TurnResult
    {
        Success
    }

    public class PlayCardResult
    {
        public TurnResult TurnResult { get; private set; }
        public Penalty Penalty { get; private set; }

        public PlayCardResult(TurnResult turnResult, Penalty penalty)
        {
            TurnResult = turnResult;
            Penalty = penalty;
        }

        #region Equality Members
        protected bool Equals(PlayCardResult other)
        {
            return TurnResult == other.TurnResult && Penalty == other.Penalty;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlayCardResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) TurnResult*397) ^ (int) Penalty;
            }
        }
        #endregion
    }

    public class PlayerTurnManager
    {
        public PlayerTurnManager(IEnumerable<IPlayer> players)
        {
            
        }

        public PlayCardResult PlayCard(IPlayer player)
        {
            return new PlayCardResult(TurnResult.Success, Penalty.None);
        }
    }
}
