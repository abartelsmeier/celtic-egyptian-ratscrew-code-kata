using System;
using System.Linq;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.PenaltyGame;
using CelticEgyptianRatscrewKata.PenaltyManagement;

namespace CelticEgyptianRatscrewKata.ActionManagement
{
    public class PlayerTurnManager : IPlayerTurnManager
    {
        private readonly IPenaltyGameController _gameController;
        private readonly IPenaltyManager _penaltyManager;
        private int _nextPlayer;

        public PlayerTurnManager(IPenaltyGameController gameController, IPenaltyManager penaltyManager)
        {
            _gameController = gameController;
            _penaltyManager = penaltyManager;
            _nextPlayer = 0;
        }

        public PlayerTurnResult PlayCard(IPlayer player)
        {
            string logMessage;
            var penalty = _penaltyManager.HasPenalty(player);

            switch (penalty)
            {
                case Penalty.Null:
                    logMessage = String.Format("{0} not found in penalty manager", player.Name);
                    return new PlayerTurnResult(null, logMessage);

                case Penalty.PlayedOutOfTurn:
                    logMessage = String.Format("{0} is blocked (played out of turn)", player.Name);
                    return new PlayerTurnResult(null, logMessage);

                case Penalty.IncorrectSnap:
                    logMessage = String.Format("{0} is blocked (incorrect snap)", player.Name);
                    return new PlayerTurnResult(null, logMessage);

                case Penalty.None:
                    return AttemptTakeTurn(player);

                default:
                    throw new Exception("Unhandled HasPenalty Result");
            }
        }

        private PlayerTurnResult AttemptTakeTurn(IPlayer player)
        {
            Card playedCard = null;
            string message;
            if (IsPlayersTurn(player))
            {
                playedCard = _gameController.PlayCard(player);
                IncrementTurn();
                message = String.Format("{0} played {1}", player.Name, playedCard);
            }
            else
            {
                _gameController.PlayCardOutOfTurn(player);
                _penaltyManager.ImposePenalty(player, Penalty.PlayedOutOfTurn);
                message = String.Format("{0} recieves out of turn penalty", player.Name);
                message += CheckForDeadlock();
            }

            return new PlayerTurnResult(playedCard, message);
        }

        private string CheckForDeadlock()
        {
            if (_penaltyManager.IsDeadlock())
            {
                _penaltyManager.ClearAllPenalties();
                return "\nPenalty deadlock! All penalties removed";
            }
            return "";
        }

        private bool IsPlayersTurn(IPlayer player)
        {
            return _gameController.Players.ElementAt(_nextPlayer).Equals(player);
        }

        private void IncrementTurn()
        {
            while (true)
            {
                _nextPlayer++;
                if (_nextPlayer >= _gameController.Players.Count()) _nextPlayer = 0;
                if (_penaltyManager.IsDeadlock())
                {
                    _penaltyManager.ClearAllPenalties();
                    return;
                }
                if (_penaltyManager.HasPenalty(_gameController.Players.ElementAt(_nextPlayer)) != Penalty.None)
                {
                    continue;
                }

                break;
            }
        }
    }
}