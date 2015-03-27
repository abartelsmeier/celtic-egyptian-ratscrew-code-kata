using CelticEgyptianRatscrewKata.Game;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameStateTests
    {
        [Test]
        public void MockGameStateListener()
        {
            var mockListener = new Mock<IGameStateListener>();
            mockListener.Setup(x => x.Notify(It.IsAny<GameStateUpdate>())).Verifiable();

            mockListener.Object.Notify(new GameStateUpdate());

            mockListener.Verify();
        }

        [Test]
        public void CreateGameStateWithListener()
        {
            var mockListener = new Mock<IGameStateListener>();
            mockListener.Setup(x => x.Notify(It.IsAny<GameStateUpdate>())).Verifiable();
            var gameState = new GameState(mockListener);
        }
    }

    public interface IGameStateListener
    {
        void Notify(GameStateUpdate gameStateUpdate);
    }

    public class GameStateUpdate
    {
    }
}
