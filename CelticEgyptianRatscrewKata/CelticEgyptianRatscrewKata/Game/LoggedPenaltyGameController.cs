using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public class LoggedPenaltyGameController : IGameController
    {
        private readonly IGameController _gameController;
        private IPenaltyManager _penaltyManager;
        private IPlayerTurnManager _playerTurnManager;
        private IPlayerSnapManager _playerSnapManager;
        private readonly ILog _log;

        public LoggedPenaltyGameController(IGameController gameController, ILog log)
        {
            _gameController = gameController;
            _log = log;
        }

        public bool AddPlayer(IPlayer player)
        {
            return _gameController.AddPlayer(player);
        }

        public Card PlayCard(IPlayer player)
        {
            var playResult = _playerTurnManager.PlayCard(player);

            if(playResult.TurnResult == TurnResult.Success)
                _log.Log(string.Format("{0} has played the {1}", player.Name, playResult.PlayedCard));
            else if (playResult.TurnResult == TurnResult.Fail)
                _log.Log(string.Format("{0} has played out of turn", player.Name));
            else if (playResult.TurnResult == TurnResult.Blocked)
                _log.Log(string.Format("{0} is blocked from playing", player.Name));
            
            LogGameState();
            return playResult.PlayedCard;
        }

        public bool AttemptSnap(IPlayer player)
        {
            var snapResult = _playerSnapManager.AttemptSnap(player);
            var wasValidSnap = snapResult.SnapResult == SnapResult.Success; 
            var snapLogMessage = wasValidSnap ? "won the stack" : "did not win the stack";
            _log.Log(string.Format("{0} {1}", player.Name, snapLogMessage));
            LogGameState();
            return wasValidSnap;
        }

        public void StartGame(Cards deck)
        {
            _gameController.StartGame(deck);
            _penaltyManager = new PenaltyManager(_gameController.Players);
            _playerTurnManager = new PlayerTurnManager(_gameController, _penaltyManager);
            _playerSnapManager = new PlayerSnapManager(_gameController, _penaltyManager);
            LogGameState();
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            var hasWinner = _gameController.TryGetWinner(out winner);
            if (hasWinner)
            {
                _log.Log(string.Format("{0} won the game!", winner.Name));
            }
            return hasWinner;
        }

        public IEnumerable<IPlayer> Players
        {
            get { return _gameController.Players; }
        }

        public int StackSize
        {
            get { return _gameController.StackSize; }
        }

        public Card TopOfStack
        {
            get { return _gameController.TopOfStack; }
        }

        public int NumberOfCards(IPlayer player)
        {
            return _gameController.NumberOfCards(player);
        }

        private void LogGameState()
        {
            _log.Log(string.Format("Stack ({0}): {1} ", _gameController.StackSize, _gameController.StackSize > 0 ? _gameController.TopOfStack.ToString() : ""));
            foreach (var player in _gameController.Players)
            {
                _log.Log(string.Format("{0}: {1} cards", player.Name, _gameController.NumberOfCards(player)));
            }
        }
    }
}