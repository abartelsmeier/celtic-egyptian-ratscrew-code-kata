namespace CelticEgyptianRatscrewKata.Game
{
    public class Callout : IPlayerSequence
    {
        private readonly IPlayerSequence _playerSequence;
        public Rank CurrentRank { get; private set; }

        public Callout(IPlayerSequence playerSequence)
        {
            _playerSequence = playerSequence;
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