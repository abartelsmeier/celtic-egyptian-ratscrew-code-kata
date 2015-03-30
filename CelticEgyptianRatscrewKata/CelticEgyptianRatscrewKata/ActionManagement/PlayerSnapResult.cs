namespace CelticEgyptianRatscrewKata.ActionManagement
{
    public class PlayerSnapResult
    {
        public bool State { get; private set; }
        public string LogMessage { get; private set; }

        public PlayerSnapResult(bool state, string logMessage)
        {
            State = state;
            LogMessage = logMessage;
        }
        #region Equality Members

        protected bool Equals(PlayerSnapResult other)
        {
            return State.Equals(other.State) && string.Equals(LogMessage, other.LogMessage);
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
                return (State.GetHashCode()*397) ^ (LogMessage != null ? LogMessage.GetHashCode() : 0);
            }
        }

        #endregion
    }
}