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

            playerActions.Add('a', ActionMethod, PlayerA());
        }

        private static IPlayer PlayerA()
        {
            return new Player("PlayerA");
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
