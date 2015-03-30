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

            PlayerSnapResult result = playerSnapManager.AttemptSnap(playerA);

            PlayerSnapResult expectedResult = new PlayerSnapResult(SnapResult.Success, Penalty.None);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

    public enum SnapResult
    {
        Null,
        Success,
        Fail
    }

    public class PlayerSnapResult
    {
        public SnapResult _snapResult { get; private set; }
        public Penalty _penalty { get; private set; }

        public PlayerSnapResult(SnapResult snapResult, Penalty penalty)
        {
            _snapResult = snapResult;
            _penalty = penalty;
        }
        #region Equality Members
        protected bool Equals(PlayerSnapResult other)
        {
            return _snapResult == other._snapResult && _penalty == other._penalty;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlayerSnapResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _snapResult*397) ^ (int) _penalty;
            }
        }
        #endregion
    }

    public class PlayerSnapManager
    {
        private readonly IGameController _gameController;
        private readonly IPenaltyManager _penaltyManager;

        public PlayerSnapManager(IGameController gameController, IPenaltyManager penaltyManager)
        {
            _gameController = gameController;
            _penaltyManager = penaltyManager;
        }

        public PlayerSnapResult AttemptSnap(IPlayer player)
        {
            Penalty penalty = _penaltyManager.HasPenalty(player);
            if (penalty != Penalty.None)
                return new PlayerSnapResult(SnapResult.Fail,penalty);

            SnapResult snapResult = _gameController.AttemptSnap(player) ? SnapResult.Success : SnapResult.Fail;

            return new PlayerSnapResult(snapResult, penalty);
        }
    }
}
