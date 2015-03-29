using System.Collections.Generic;
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

            mockListener.Object.Notify(TestUpdate());

            mockListener.Verify();
        }

        [Test]
        public void CreateGameStateWithListener()
        {
            var mockListener = new Mock<IGameStateListener>();
            mockListener.Setup(x => x.Notify(It.IsAny<GameStateUpdate>())).Verifiable();
            
            var gameState = new GameState(mockListener.Object);
        }

        [Test]
        public void CreateGameStateWithListenerAndTriggerUpdate()
        {
            var playerA = new Player("PlayerA");
            var mockListener = new Mock<IGameStateListener>();
            mockListener.Setup(x => x.Notify(It.IsAny<GameStateUpdate>())).Verifiable();
            var gameState = new GameState(mockListener.Object);
            gameState.AddPlayer(playerA, TestCards());

            gameState.PlayCard(playerA);

            mockListener.Verify();
        }

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

        private static GameStateUpdate TestUpdate()
        {
            return new GameStateUpdate(TestCards(), new Player("PlayerA"), null, TestDecks());
        }
        
    }

    public interface IGameControllerListener
    {
        void Notify(GameControllerUpdate update);
    }

    public class GameControllerUpdate
    {
        public IPlayer Player { get; private set; }
        public GameControllerAction Action { get; private set; }

        public GameControllerUpdate(IPlayer player, GameControllerAction action)
        {
            Player = player;
            Action = action;
        }
    }

    public enum GameControllerAction
    {
        PlayCardSuccess,
        PlayCardFail,
        AttemptSnapSuccess,
        AttemptSnapFail
    }

    public interface IGameStateListener
    {
        void Notify(GameStateUpdate update);
    }

    public class GameStateUpdate
    {
        public Cards Stack { get; private set; }
        public IPlayer Player { get; private set; }
        public IPlayer NextPlayer { get; private set; }
        public IDictionary<IPlayer, Cards> Decks { get; private set; }

        public GameStateUpdate(Cards stack, IPlayer player, IPlayer nextPlayer, IDictionary<IPlayer, Cards> decks)
        {
            Stack = stack;
            Player = player;
            NextPlayer = nextPlayer;
            Decks = decks;
        }
    }
}
