using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    class Game
    {
        Dictionary<IPlayer, Cards> m_PlayersWithHands;
        Cards m_Deck;
        Cards m_Stack;
        IDealer m_Dealer;
        IShuffler m_Shuffler;

        public Cards Deck
        {
            get { return m_Deck; }
        }

        public Cards Stack
        {
            get { return m_Stack; }
        }

        public Game(IEnumerable<IPlayer> players, Cards deck)
        {
            m_PlayersWithHands = new Dictionary<IPlayer, Cards>();
            foreach(var player in players)
            {
                m_PlayersWithHands.Add(player,null);
            }
            m_Deck = deck;
            m_Dealer = new Dealer();
            m_Shuffler = new Shuffler();
        }
        
        public void Start()
        {
            m_Deck = m_Shuffler.Shuffle(m_Deck);
            m_Stack = new Cards(new List<Card>());
            int totalPlayers = m_PlayersWithHands.Count;
            List<Cards> hands = (List<Cards>)m_Dealer.Deal(totalPlayers, new Cards(m_Deck));
            for (int i = 0; i < totalPlayers; ++i)
            {
                m_PlayersWithHands[m_PlayersWithHands.ElementAt(i).Key] = hands.ElementAt(i);
            }
        }

        public void PlayCard(IPlayer player)
        {
            if (m_PlayersWithHands.ContainsKey(player))
            {
                Card card = m_PlayersWithHands[player].Pop();
                Stack.AddToTop(card);
            }                
        }

        public bool DeckContainsAllCardsIn(Cards cards)
        {
            Cards cardsInHands = new Cards(m_PlayersWithHands.Values.SelectMany(x => x)
                .OrderBy(c => c.Suit)
                .ThenBy(c => c.Rank));
            Cards expectedCards = new Cards(cards.OrderBy(c => c.Suit).ThenBy(c => c.Rank));

            return cardsInHands.SequenceEqual(expectedCards);
        }
    }
}
