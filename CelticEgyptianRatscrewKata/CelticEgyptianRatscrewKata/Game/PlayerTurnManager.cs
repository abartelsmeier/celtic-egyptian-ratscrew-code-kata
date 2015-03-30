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

        public PlayCardResult PlayCard(IPlayer player)
        {
            Penalty penalty = _penaltyManager.HasPenalty(player);
            if (penalty == Penalty.Null)
                return new PlayCardResult(TurnResult.PlayerNotFound, Penalty.Null);

            if (penalty != Penalty.None)
                return new PlayCardResult(TurnResult.Blocked, penalty);

            TurnResult result = TurnResult.Null;
            Card playedCard = null;

            if (penalty == Penalty.None)
            {
                if (!IsPlayersTurn(player))
                {
                    _penaltyManager.ImposePenalty(player, Penalty.PlayedOutOfTurn);
                    return new PlayCardResult(TurnResult.Fail, Penalty.PlayedOutOfTurn); 
                }
                playedCard = _gameController.PlayCard(player);
                result = playedCard != null ? TurnResult.Success : TurnResult.Null;
                IncrementTurn();
            }
            return new PlayCardResult(result, penalty, playedCard);    
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