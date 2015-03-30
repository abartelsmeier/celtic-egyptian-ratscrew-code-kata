namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerSnapResult
    {
        public SnapResult _snapResult { get; private set; }
        public Penalty _penalty { get; private set; }

        public PlayerSnapResult(SnapResult snapResult, Penalty penalty)
        {
            _snapResult = snapResult;
            _penalty = penalty;
        }
        #region Equality Members
        protected bool Equals(PlayerSnapResult other)
        {
            return _snapResult == other._snapResult && _penalty == other._penalty;
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
                return ((int) _snapResult*397) ^ (int) _penalty;
            }
        }
        #endregion
    }
}