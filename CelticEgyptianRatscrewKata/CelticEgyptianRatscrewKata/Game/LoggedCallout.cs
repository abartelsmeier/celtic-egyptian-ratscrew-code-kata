namespace CelticEgyptianRatscrewKata.Game
{
    public class LoggedCallout : IPlayerSequence
    {
        private readonly IPlayerSequence _playerSequence;
        private readonly ILog _log;
        public Rank CurrentRank { get; private set; }

        public LoggedCallout(IPlayerSequence playerSequence, ILog log)
        {
            _playerSequence = playerSequence;
            _log = log;
        }

        public void IncrementRank()
        {
            CurrentRank++;
            if (CurrentRank > Rank.King) ResetRank();
        }

        private void ResetRank()
        {
            CurrentRank = Rank.Ace;
        }

        public void AddPlayer(string name)
        {
            _playerSequence.AddPlayer(name);
        }

        public void AdvanceToNextPlayer()
        {
            _playerSequence.AdvanceToNextPlayer();
            IncrementRank();
        }

        public bool IsCurrentPlayer(string name)
        {
           return _playerSequence.IsCurrentPlayer(name);
        }
    }
}