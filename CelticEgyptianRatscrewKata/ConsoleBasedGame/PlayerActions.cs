using System;
using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    internal class PlayerActions : IPlayerActions
    {
        private readonly IDictionary<char, PlayerAction> m_PlayerActions;
        
        public PlayerActions()
        {
            m_PlayerActions = new Dictionary<char, PlayerAction>();
        }

        public void Add(char key, PlayerMethod actionMethod, IPlayer player)
        {
            var playerAction = new PlayerAction(actionMethod, player);
            m_PlayerActions.Add(key, playerAction);
        }

        public void HandleKey(char key)
        {
            if(m_PlayerActions.ContainsKey(key))
                m_PlayerActions[key].Execute();
        }
    }
}