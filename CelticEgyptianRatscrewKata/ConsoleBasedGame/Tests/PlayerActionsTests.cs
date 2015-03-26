﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using NUnit.Framework;

namespace ConsoleBasedGame.Tests
{
    class PlayerActionsTests
    {
        private bool m_ActionMethodHasFired;

        [Test]
        public void CreateAndAddPlayerActions()
        {
            PlayerActions playerActions = new PlayerActions();

            playerActions.Add('a', ActionMethod, PlayerA());
        }

        [Test]
        public void HandleKeyExecutesMethod()
        {
            PlayerActions playerActions = new PlayerActions();
            playerActions.Add('a', ActionMethod, PlayerA());

            m_ActionMethodHasFired = false;
            playerActions.HandleKey('a');

            Assert.That(m_ActionMethodHasFired, Is.True);
        }

        private static IPlayer PlayerA()
        {
            return new Player("PlayerA");
        }

        private void ActionMethod(IPlayer player)
        {
            m_ActionMethodHasFired = true;
        }
    }

    internal class PlayerActions
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
