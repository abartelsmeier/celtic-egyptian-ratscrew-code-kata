using System;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.PenaltyManagement;

namespace CelticEgyptianRatscrewKata.ActionManagement
{
    public class PlayerSnapManager : IPlayerSnapManager
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
            string logMessage;
            var penalty = _penaltyManager.HasPenalty(player);

            switch (penalty)
            {
                case Penalty.Null:
                    logMessage = String.Format("{0} not found in penalty manager", player.Name);
                    return new PlayerSnapResult(false, logMessage);

                case Penalty.PlayedOutOfTurn:
                    logMessage = String.Format("{0} is blocked (played out of turn)", player.Name);
                    return new PlayerSnapResult(false, logMessage);

                case Penalty.IncorrectSnap:
                    logMessage = String.Format("{0} is blocked (incorrect snap)", player.Name);
                    return new PlayerSnapResult(false, logMessage);

                case Penalty.None:
                    return AttemptSnapStack(player);

                default:
                    throw new Exception("Unhandled HasPenalty Result");
            }
        }

        private PlayerSnapResult AttemptSnapStack(IPlayer player)
        {
            var snapSuccess = _gameController.AttemptSnap(player);
            string message;

            if (snapSuccess)
            {
                _penaltyManager.ClearAllPenalties();
                message = String.Format("{0} snaps and wins stack", player.Name);
            }
            else
            {
                _penaltyManager.ImposePenalty(player,Penalty.IncorrectSnap);
                message = String.Format("{0} recieves incorrect snap penalty", player.Name);
                message += CheckForDeadlock();
            }

            return new PlayerSnapResult(snapSuccess, message);
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
    }
}