using System.Linq;
using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerTurnManager
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