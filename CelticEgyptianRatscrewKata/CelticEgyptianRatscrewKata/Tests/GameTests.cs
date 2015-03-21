using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameTests
    {
        [Test]
        public void CreateGameWithEmptyCardsAndPlayers()
        {
            Cards deck = new Cards(new List<Card>());
            List<Player> players = new List<Player>();

            Game game = new Game(players, deck);
        }

        [Test]
        public void CreateGameWithSingleCardsAndSinglePlayer()
        {
            Cards deck = new Cards(new List<Card> { GameTestVariables.AceOfClubs() });
            List<Player> players = new List<Player> { new Player() };

            Game game = new Game(players, deck);
        }

        [Test]
        public void CreateGameWithMultipleCardsAndMultiplePlayers()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.TwoOfClubs(),
                                GameTestVariables.ThreeOfClubs()
                            });
            List<Player> players = new List<Player>
                            {
                                new Player(),
                                new Player(),
                                new Player()
                            };

            Game game = new Game(players, deck);
        }

        [Test]
        public void DealGameDeckToPlayers()
        {
            Cards deck = new Cards(new List<Card>
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.TwoOfClubs(),
                                GameTestVariables.ThreeOfClubs()
                            });
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            List<Player> players = new List<Player> { player1, player2, player3 };
            Game game = new Game(players, deck);
            var hand1 = new Cards(new List<Card> { GameTestVariables.AceOfClubs() });
            var hand2 = new Cards(new List<Card> { GameTestVariables.TwoOfClubs() });
            var hand3 = new Cards(new List<Card> { GameTestVariables.ThreeOfClubs() });
            var expectedPlayerHands = new Dictionary<IPlayer, Cards> {
                                {player1,  hand1},
                                {player2,  hand2},
                                {player3,  hand3}
                            };

            game.Deal();

            Assert.AreEqual((Dictionary<IPlayer, Cards>)game.PlayersWithHands, expectedPlayerHands);
        }

        [Test]
        public void DealShuffledGameDeckToPlayers()
        {
            Cards deck = new Cards(new List<Card>
                            {
                                GameTestVariables.TwoOfClubs(),
                                GameTestVariables.ThreeOfClubs(),
                                GameTestVariables.AceOfClubs()
                            });
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            List<Player> players = new List<Player> { player1, player2, player3 };
            Game game = new Game(players, deck);
            var hand1 = new Cards(new List<Card> { GameTestVariables.TwoOfClubs() });
            var hand2 = new Cards(new List<Card> { GameTestVariables.ThreeOfClubs() });
            var hand3 = new Cards(new List<Card> { GameTestVariables.AceOfClubs() });
            var expectedPlayerHands = new Dictionary<IPlayer, Cards> {
                                {player1,  hand1},
                                {player2,  hand2},
                                {player3,  hand3}
                            };

            game.Deal();

            Assert.AreEqual((Dictionary<IPlayer, Cards>)game.PlayersWithHands, expectedPlayerHands);
        }

        [Test]
        public void ShuffleAndDealWholeGameDeck()
        {
            Cards deck = new Cards(GameTestVariables.WholeDeck());
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            List<Player> players = new List<Player> { player1, player2, player3 };
            Game game = new Game(players, deck);

            game.Shuffle();
            game.Deal();
        }
    }
}
