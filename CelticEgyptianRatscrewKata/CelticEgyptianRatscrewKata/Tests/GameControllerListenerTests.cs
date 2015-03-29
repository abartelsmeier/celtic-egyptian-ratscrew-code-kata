using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameControllerListenerTests
    {
        [Test]
        public void CreateGameControllerWithListenerAndTriggerUpdate()
        {
            var playerA = new Player("PlayerA");
            var mockListener = new Mock<IGameControllerListener>();
            mockListener.Setup(x => x.Notify(It.IsAny<GameControllerUpdate>())).Verifiable();
            var gameController = new GameFactory().Create(mockListener.Object);
            gameController.AddPlayer(playerA);

            gameController.PlayCard(playerA);

            mockListener.Verify();
        }

        [Test]
        public void CreateGameControllerWithListenerAndTriggerUpdateTwice()
        {
            var playerA = new Player("PlayerA");
            var mockListener = new Mock<IGameControllerListener>();
            mockListener.Setup(x => x.Notify(It.IsAny<GameControllerUpdate>())).Verifiable();
            var gameController = new GameFactory().Create(mockListener.Object);
            gameController.AddPlayer(playerA);

            gameController.PlayCard(playerA);
            gameController.AttemptSnap(playerA);

            mockListener.Verify(x => x.Notify(It.IsAny<GameControllerUpdate>()), Times.Exactly(2));
        }

        private static Cards TestCards()
        {
            return new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace)
            }); 
        }

        private static IDictionary<IPlayer, Cards> TestDecks()
        {
            return new Dictionary<IPlayer, Cards>
                   {
                       {new Player("PlayerA"), new Cards(new List<Card>())}
                   };
        }
    }
}
