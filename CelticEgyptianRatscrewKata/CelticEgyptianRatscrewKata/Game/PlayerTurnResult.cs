using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerTurnResult
    {
        public Card PlayedCard { get; private set; }
        public string LogMessage { get; private set; }
        
        public PlayerTurnResult(Card card, string logMessage)
        {
            LogMessage = logMessage;
            PlayedCard = card;
        }

        #region Equality Members

        protected bool Equals(PlayerTurnResult other)
        {
            return Equals(PlayedCard, other.PlayedCard) && string.Equals(LogMessage, other.LogMessage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlayerTurnResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((PlayedCard != null ? PlayedCard.GetHashCode() : 0)*397) ^ (LogMessage != null ? LogMessage.GetHashCode() : 0);
            }
        }

        #endregion
    }
}