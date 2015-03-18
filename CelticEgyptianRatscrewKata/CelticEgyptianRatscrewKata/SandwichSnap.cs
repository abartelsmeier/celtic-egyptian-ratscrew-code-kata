namespace CelticEgyptianRatscrewKata
{
    public class SandwichSnap : ISnapRule
    {
        public bool IsSnap(Stack stack)
        {
            Card previousCard = null;
            Card previousPreviousCard = null;
            
            foreach (var card in stack)
            {
                if (previousPreviousCard != null && card.Rank == previousPreviousCard.Rank) return true;
                previousPreviousCard = previousCard;
                previousCard = card;
            }

            return false;
        }
    }
}