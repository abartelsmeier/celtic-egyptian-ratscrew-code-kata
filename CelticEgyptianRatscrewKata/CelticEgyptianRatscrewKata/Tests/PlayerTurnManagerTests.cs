using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.Game;
using Moq;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class PlayerTurnManagerTests
    {
        [Test]
        public void CreatePlayerTurnManager()
        {
            var gameMock = new Mock<IGameController>();
            
            PlayerTurnManager playerTurnManager = new PlayerTurnManager(gameMock.Object);
        }

        [Test]
        public void CreatePlayerTurnManagerAndPlayCard()
        {
            Player playerA = new Player("PlayerA");
            List<IPlayer> players = new List<IPlayer>{playerA};
            var gameMock = new Mock<IGameController>();
            gameMock.Setup(x => x.Players).Returns(players);
            gameMock.Setup(x => x.PlayCard(playerA)).Returns(new Card(Suit.Clubs, Rank.Ace));
            PlayerTurnManager playerTurnManager = new PlayerTurnManager(gameMock.Object);

            PlayCardResult playResult = playerTurnManager.PlayCard(playerA);

            PlayCardResult expectedResult = new PlayCardResult(TurnResult.Success, Penalty.None);
            Assert.That(playResult, Is.EqualTo(expectedResult));
        }
    }

    public enum TurnResult
    {
        Null,
        Success,
        Fail,
        Blocked,
        PlayerNotFound
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
        private readonly IGameController _gameController;
        private readonly IPenaltyManager _penaltyManager;
        private int _nextPlayer;

        public PlayerTurnManager(IGameController gameController)
        {
            _gameController = gameController;
            _nextPlayer = 0;
            _penaltyManager = new PenaltyManager(gameController.Players);
        }

        public PlayCardResult PlayCard(IPlayer player)
        {
            Penalty penalty = _penaltyManager.HasPenalty(player);
            if (penalty == Penalty.Null)
                return new PlayCardResult(TurnResult.PlayerNotFound, Penalty.Null);

            if (penalty != Penalty.None)
                return new PlayCardResult(TurnResult.Blocked, penalty);

            TurnResult result = TurnResult.Null;

            if (penalty == Penalty.None)
            {
                if (!IsPlayersTurn(player))
                {
                    _penaltyManager.ImposePenalty(player, Penalty.PlayedOutOfTurn);
                    return new PlayCardResult(TurnResult.Fail, Penalty.PlayedOutOfTurn); 
                }
                result = _gameController.PlayCard(player) != null ? TurnResult.Success : TurnResult.Null;
                IncrementTurn();
            }
            return new PlayCardResult(result, penalty);    
        }

        private bool IsPlayersTurn(IPlayer player)
        {
            return _gameController.Players.ElementAt(_nextPlayer).Equals(player);
        }

        private void IncrementTurn()
        {
            _nextPlayer++;
            if (_nextPlayer >= _gameController.Players.Count()) _nextPlayer = 0;
        }
    }
}
