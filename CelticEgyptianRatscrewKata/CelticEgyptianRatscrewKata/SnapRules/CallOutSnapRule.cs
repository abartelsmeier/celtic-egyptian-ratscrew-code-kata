using System.Linq;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    public class CallOutSnapRule : ISnapRule
    {
        private readonly ICallout _callout;

        public CallOutSnapRule(ICallout callout)
        {
            _callout = callout;
        }

        public bool IsSnapValid(Cards cardStack)
        {
            if(cardStack.Any()) return cardStack.CardAt(0).Rank == _callout.CurrentRank;
            return false;
        }
    }
}