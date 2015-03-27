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
        }
    }
}
