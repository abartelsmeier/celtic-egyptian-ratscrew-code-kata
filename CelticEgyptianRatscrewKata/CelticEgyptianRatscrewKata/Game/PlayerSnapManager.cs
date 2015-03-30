namespace CelticEgyptianRatscrewKata.Game
{
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