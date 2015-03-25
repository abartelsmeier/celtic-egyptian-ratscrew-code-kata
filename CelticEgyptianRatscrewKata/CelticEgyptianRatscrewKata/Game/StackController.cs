using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    class StackController : IStackController
    {
        private Cards m_Deck;
        private Cards m_Stack;
        private IDictionary<IPlayer, Cards> m_PlayersWithHands;
        private IDealer m_Dealer;
        private IShuffler m_Shuffler;

        public Cards Stack()
        {
            return m_Stack;
        }

        public StackController(IEnumerable<IPlayer> players, Cards deck)
        {
            m_PlayersWithHands = new Dictionary<IPlayer, Cards>();
            foreach (var player in players)
            {
                m_PlayersWithHands.Add(player, null);
            }
            m_Deck = deck;
            m_Dealer = new Dealer();
            m_Shuffler = new Shuffler();
            m_Stack = new Cards(new List<Card>());
        }

        public void Shuffle()
        {
            m_Deck = m_Shuffler.Shuffle(m_Deck);
        }

        public void Deal()
        {
            var hands = (List<Cards>)m_Dealer.Deal(m_PlayersWithHands.Count(), new Cards(m_Deck));
            for (int i = 0; i < m_PlayersWithHands.Count(); ++i)
            {
                m_PlayersWithHands[m_PlayersWithHands.ElementAt(i).Key] = hands.ElementAt(i);
            }
        }

        public void PlayCard(IPlayer player)
        {
            if (m_PlayersWithHands.ContainsKey(player))
            {
                Card card = m_PlayersWithHands[player].Pop();
                m_Stack.AddToTop(card);
            }
        }

        public void TakeStack(IPlayer player)
        {
            while (m_Stack.HasCards)
            {
                m_PlayersWithHands[player].AddToTop(m_Stack.Pop());
            }
        }

        public IPlayer Winner()
        {
            for (int i = 0; i < m_PlayersWithHands.Count; ++i)
            {
                if (m_PlayersWithHands.ElementAt(i).Value.Count() == m_Deck.Count())
                    return m_PlayersWithHands.ElementAt(i).Key;
            }
            return null;
        }
    }
}
