using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata
{
    class Game
    {
        List<IPlayer> m_Players;

        public Game()
        {
            m_Players = new List<IPlayer>();
        }

        public void AddPlayer(IPlayer player)
        {
            m_Players.Add(player);
        }
    }
}
