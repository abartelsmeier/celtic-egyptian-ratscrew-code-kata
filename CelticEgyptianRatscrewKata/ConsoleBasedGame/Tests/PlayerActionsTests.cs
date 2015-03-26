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
}
