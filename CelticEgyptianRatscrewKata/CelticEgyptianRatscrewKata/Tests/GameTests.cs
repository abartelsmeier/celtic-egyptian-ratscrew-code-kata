using NUnit.Framework;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameTests
    {
        [Test]
        public void ShouldCreateGame()
        {
            Game game = new Game();
            Assert.That(game, Is.TypeOf(typeof(Game)));
        }

        [Test]
        public void ShouldAddPlayerToGame()
        {
            Game game = new Game();
            var player = new Player();
            game.AddPlayer(player);
            Assert.Pass();
        }
        
        [Test]
        public void ShouldCreateEmptyDeckAndPassToGame()
        {
            Cards deck = new Cards(new List<Card>());
            Game game = new Game(deck);            
            Assert.That(game, Is.TypeOf(typeof(Game)));
        }

        [Test]
        public void ShouldCreateEmptyDeckAndPlayersAndPassToGame()
        {
            Cards deck = new Cards(new List<Card>());
            List<Player> players = new List<Player>();
            Game game = new Game(players, deck);
            Assert.That(game, Is.TypeOf(typeof(Game)));
        }

        [Test]
        public void ShouldCreateSingleCardDeckAndSinglePlayerAndPassToGame()
        {
            Cards deck = new Cards(new List<Card> { new Card(Suit.Clubs, Rank.Ace) });
            List<Player> players = new List<Player> { new Player() };
            Game game = new Game(players, deck);
            Assert.That(game, Is.TypeOf(typeof(Game)));
        }

        [Test]
        public void ShouldCreateMultipleCardDeckAndMultiplePlayersAndPassToGame()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                new Card(Suit.Clubs, Rank.Ace),
                                new Card(Suit.Diamonds, Rank.Two),
                                new Card(Suit.Hearts, Rank.Three)
                            });
            List<Player> players = new List<Player>
                            {
                                new Player(),
                                new Player(),
                                new Player()
                            };
            Game game = new Game(players, deck);
            Assert.That(game, Is.TypeOf(typeof(Game)));
        }

        [Test]
        public void ShouldDealGameDeckToPlayers()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                AceOfClubs(),
                                TwoOfClubs(),
                                ThreeOfClubs()
                            });
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            List<Player> players = new List<Player>
                            {
                                player1,
                                player2,
                                player3
                            };
            Game game = new Game(players, deck);
            var hand1 = new Cards(new List<Card> { AceOfClubs() });
            var hand2 = new Cards(new List<Card> { TwoOfClubs() });
            var hand3 = new Cards(new List<Card> { ThreeOfClubs() });
            var expectedPlayerHands = new Dictionary<IPlayer, Cards>
                            {
                                {player1,  hand1},
                                {player2,  hand2},
                                {player3,  hand3}
                            };

            game.DealDeck();

            Assert.That((Dictionary<IPlayer, Cards>)game.PlayersWithHands, Is.EqualTo(expectedPlayerHands));
        }

        private static Card AceOfClubs()
        {
            return new Card(Suit.Clubs, Rank.Ace);
        }

        private static Card TwoOfClubs()
        {
            return new Card(Suit.Clubs, Rank.Two);
        }

        private static Card ThreeOfClubs()
        {
            return new Card(Suit.Clubs, Rank.Three);
        }
    }
}
