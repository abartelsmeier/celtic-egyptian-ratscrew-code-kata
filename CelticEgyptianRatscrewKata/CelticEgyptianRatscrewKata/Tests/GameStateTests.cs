using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameStateTests
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

    public interface IGameControllerListener
    {
        void Notify(GameControllerUpdate update);
    }

    public class GameControllerUpdate
    {
        public GameStateUpdate State { get; private set; }
        public IPlayer Player { get; private set; }
        public IPlayer NextPlayer { get; private set; }
        public GameControllerAction Action { get; private set; }

        public GameControllerUpdate(GameStateUpdate state, IPlayer player, IPlayer nextPlayer, GameControllerAction action)
        {
            State = state;
            Player = player;
            NextPlayer = nextPlayer;
            Action = action;
        }
    }

    public enum GameControllerAction
    {
        PlayCardSuccess,
        PlayCardFail,
        AttemptSnapSuccess,
        AttemptSnapFail,
        WinGame
    }

    public class GameStateUpdate
    {
        public Cards Stack { get; private set; }
        public IDictionary<IPlayer, Cards> Decks { get; private set; }

        public GameStateUpdate(Cards stack, IDictionary<IPlayer, Cards> decks)
        {
            Stack = stack;
            Decks = decks;
        }
    }
}
