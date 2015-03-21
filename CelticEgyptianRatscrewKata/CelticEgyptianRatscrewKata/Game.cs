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
        
        public void Shuffle()
        {
            m_Deck = m_Shuffler.Shuffle(m_Deck);
        }

        public void Deal()
        {
            int totalPlayers = m_PlayersWithHands.Count;
            List<Cards> hands = (List<Cards>)m_Dealer.Deal(totalPlayers, m_Deck);
            for (int i = 0; i < totalPlayers; ++i)
            {
                m_PlayersWithHands[m_PlayersWithHands.ElementAt(i).Key] = hands.ElementAt(i);
            }
        }
    }
}
