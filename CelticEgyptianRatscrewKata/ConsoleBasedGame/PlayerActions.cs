using System;
using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    internal class PlayerActions : IPlayerActions
    {
        private IDictionary<char, Tuple<Action<IPlayer>, IPlayer>> m_PlayerActions;

        public PlayerActions()
        {
            m_PlayerActions = new Dictionary<char, Tuple<Action<IPlayer>, IPlayer>>();
        }

        public void Add(char key, Action<IPlayer> actionMethod, IPlayer player)
        {
            m_PlayerActions.Add(key,new Tuple<Action<IPlayer>, IPlayer>(actionMethod,player));
        }

        public void HandleKey(char key)
        {
            if(m_PlayerActions.ContainsKey(key))
                m_PlayerActions[key].Item1(m_PlayerActions[key].Item2);
        }
    }
}