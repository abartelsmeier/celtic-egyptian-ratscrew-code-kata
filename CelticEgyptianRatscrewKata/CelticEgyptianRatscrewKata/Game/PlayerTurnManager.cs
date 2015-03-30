using System;
using System.Linq;
using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerTurnManager : IPlayerTurnManager
    {
        private readonly IGameController _gameController;
        private readonly IPenaltyManager _penaltyManager;
        private int _nextPlayer;

        public PlayerTurnManager(IGameController gameController, IPenaltyManager penaltyManager)
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
            }

            throw new Exception("Unhandled HasPenalty Result");
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
                _penaltyManager.ImposePenalty(player, Penalty.PlayedOutOfTurn);
                message = String.Format("{0} recieves out of turn penalty", player.Name);
            }

            return new PlayerTurnResult(playedCard, message);
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