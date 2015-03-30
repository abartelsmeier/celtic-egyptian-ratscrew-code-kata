namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerSnapResult
    {
        public SnapResult SnapResult { get; private set; }
        public Penalty Penalty { get; private set; }

        public PlayerSnapResult(SnapResult snapResult, Penalty penalty)
        {
            SnapResult = snapResult;
            Penalty = penalty;
        }
        #region Equality Members
        protected bool Equals(PlayerSnapResult other)
        {
            return SnapResult == other.SnapResult && Penalty == other.Penalty;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlayerSnapResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) SnapResult*397) ^ (int) Penalty;
            }
        }
        #endregion
    }
}