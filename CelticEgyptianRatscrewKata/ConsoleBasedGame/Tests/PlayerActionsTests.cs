using System;
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
        [Test]
        public void CreateAndAddPlayerActions()
        {
            PlayerActions playerActions = new PlayerActions();
            IPlayer player = new Player("PlayerA");

            playerActions.Add('a', ActionMethod, player);
        }

        private void ActionMethod(IPlayer player)
        {
        }
    }

    internal class PlayerActions
    {
        public void Add(char key, Action<IPlayer> actionMethod, IPlayer player)
        {
        }
    }
}
