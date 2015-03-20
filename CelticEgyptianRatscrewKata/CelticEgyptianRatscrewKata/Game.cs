using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    class Game
    {
        Dictionary<IPlayer, Cards> m_PlayersWithHands;
        Cards m_Deck;
        IDealer m_Dealer;
        IShuffler m_Shuffler;

        public IDictionary<IPlayer, Cards> PlayersWithHands
        {
            get { return m_PlayersWithHands; }
        }

        public Game(): this(new List<IPlayer>(), new Cards(new List<Card>()))
        {
        }

        public Game(Cards cards): this(new List<IPlayer>(), cards)
        {
        }

        public Game(IEnumerable<IPlayer> players, Cards deck)
        {
            m_PlayersWithHands = new Dictionary<IPlayer, Cards>();
            foreach(var player in players)
            {
                m_PlayersWithHands.Add( player, new Cards(new List<Card>()) );
            }
            m_Deck = deck;
            m_Dealer = new Dealer();
            m_Shuffler = new Shuffler();
        }
               
        public void AddPlayer(IPlayer player)
        {
            m_PlayersWithHands.Add(player,new Cards(new List<Card>()));
        }

        public void ShuffleDeck()
        {
            m_Deck = m_Shuffler.Shuffle(m_Deck);
        }

        public void DealDeck()
        {
            int numberOfPlayers = m_PlayersWithHands.Count;
            List<Cards> hands = (List<Cards>) m_Dealer.Deal(numberOfPlayers, m_Deck);
            for(int i = 0; i < numberOfPlayers; ++i)
            {
                m_PlayersWithHands[m_PlayersWithHands.ElementAt(i).Key] = hands.ElementAt(i);
            }
        }
    }
}
