using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata
{
    class Game
    {
        Dictionary<IPlayer, Cards> m_PlayersWithHands;
        Cards m_Deck;

        public Game(): this(new List<IPlayer>(), new Cards(new List<Card>()))
        {
        }

        public Game(Cards cards): this(new List<IPlayer>(), cards)
        {
        }

        public Game(IEnumerable<IPlayer> players, Cards deck)
        {
            m_PlayersWithHands = new Dictionary<IPlayer, Cards>();
            foreach( var player in players )
            {
                m_PlayersWithHands.Add( player, new Cards(new List<Card>()) );
            }
            m_Deck = deck;
        }

        public void AddPlayer(IPlayer player)
        {
            m_PlayersWithHands.Add(player,new Cards(new List<Card>()));
        }
    }
}
