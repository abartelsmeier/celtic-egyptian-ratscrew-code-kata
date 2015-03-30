using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayCardResult
    {
        public TurnResult TurnResult { get; private set; }
        public Penalty Penalty { get; private set; }

        public PlayCardResult(TurnResult turnResult, Penalty penalty)
        {
            TurnResult = turnResult;
            Penalty = penalty;
        }

        #region Equality Members
        protected bool Equals(PlayCardResult other)
        {
            return TurnResult == other.TurnResult && Penalty == other.Penalty;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlayCardResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) TurnResult*397) ^ (int) Penalty;
            }
        }
        #endregion
    }
}