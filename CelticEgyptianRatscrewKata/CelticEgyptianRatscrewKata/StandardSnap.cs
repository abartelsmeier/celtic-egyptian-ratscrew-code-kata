using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class StandardSnap: ISnapRule
    {
        public bool IsSnap(Stack stack)
        {
           
            Card previousCard = null;

            foreach (var card in stack)
            {
                if(previousCard != null && card.Rank == previousCard.Rank) return true;
                previousCard = card;
            }

            return false;
        }
    }
}