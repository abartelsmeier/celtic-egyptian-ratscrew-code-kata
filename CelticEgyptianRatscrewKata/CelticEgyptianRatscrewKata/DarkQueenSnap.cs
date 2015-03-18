using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class DarkQueenSnap: ISnapRule
    {
        private static readonly Card s_DarkQueen = new Card(Suit.Spades, Rank.Queen);

        public bool IsSnap(Stack stack)
        {
            if (stack.Any())
            {
                var topCardOfStack = stack.First();
                return topCardOfStack.Equals(s_DarkQueen);
            }

            return false;
        }
    }
}
