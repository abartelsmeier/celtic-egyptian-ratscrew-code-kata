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

        [Test]
        public void PassWholeDeckToGameThenDealToPlayersAndCheckEachHandHasCorrectNumberOfCards()
        {
            Cards deck = new Cards(WholeDeck());
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
            int numberOfPlayers = players.Count;
            int numberOfCardsInDeck = deck.Count();
            
            game.DealDeck();

            Assert.That(game.PlayersWithHands[player1].Count(), Is.EqualTo(18)); // 52 / 3 = 17 (remainder 1) 
            Assert.That(game.PlayersWithHands[player2].Count(), Is.EqualTo(17));
            Assert.That(game.PlayersWithHands[player3].Count(), Is.EqualTo(17));
            
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
        private static Cards WholeDeck()
        {
            return new Cards(new List<Card>
                            {
                                new Card(Suit.Clubs, Rank.Ace),
                                new Card(Suit.Clubs, Rank.Two),
                                new Card(Suit.Clubs, Rank.Three),
                                new Card(Suit.Clubs, Rank.Four),
                                new Card(Suit.Clubs, Rank.Five),
                                new Card(Suit.Clubs, Rank.Six),
                                new Card(Suit.Clubs, Rank.Seven),
                                new Card(Suit.Clubs, Rank.Eight),
                                new Card(Suit.Clubs, Rank.Nine),
                                new Card(Suit.Clubs, Rank.Ten),
                                new Card(Suit.Clubs, Rank.Jack),
                                new Card(Suit.Clubs, Rank.Queen),
                                new Card(Suit.Clubs, Rank.King),

                                new Card(Suit.Diamonds, Rank.Ace),
                                new Card(Suit.Diamonds, Rank.Two),
                                new Card(Suit.Diamonds, Rank.Three),
                                new Card(Suit.Diamonds, Rank.Four),
                                new Card(Suit.Diamonds, Rank.Five),
                                new Card(Suit.Diamonds, Rank.Six),
                                new Card(Suit.Diamonds, Rank.Seven),
                                new Card(Suit.Diamonds, Rank.Eight),
                                new Card(Suit.Diamonds, Rank.Nine),
                                new Card(Suit.Diamonds, Rank.Ten),
                                new Card(Suit.Diamonds, Rank.Jack),
                                new Card(Suit.Diamonds, Rank.Queen),
                                new Card(Suit.Diamonds, Rank.King),

                                new Card(Suit.Hearts, Rank.Ace),
                                new Card(Suit.Hearts, Rank.Two),
                                new Card(Suit.Hearts, Rank.Three),
                                new Card(Suit.Hearts, Rank.Four),
                                new Card(Suit.Hearts, Rank.Five),
                                new Card(Suit.Hearts, Rank.Six),
                                new Card(Suit.Hearts, Rank.Seven),
                                new Card(Suit.Hearts, Rank.Eight),
                                new Card(Suit.Hearts, Rank.Nine),
                                new Card(Suit.Hearts, Rank.Ten),
                                new Card(Suit.Hearts, Rank.Jack),
                                new Card(Suit.Hearts, Rank.Queen),
                                new Card(Suit.Hearts, Rank.King),

                                new Card(Suit.Spades, Rank.Ace),
                                new Card(Suit.Spades, Rank.Two),
                                new Card(Suit.Spades, Rank.Three),
                                new Card(Suit.Spades, Rank.Four),
                                new Card(Suit.Spades, Rank.Five),
                                new Card(Suit.Spades, Rank.Six),
                                new Card(Suit.Spades, Rank.Seven),
                                new Card(Suit.Spades, Rank.Eight),
                                new Card(Suit.Spades, Rank.Nine),
                                new Card(Suit.Spades, Rank.Ten),
                                new Card(Suit.Spades, Rank.Jack),
                                new Card(Suit.Spades, Rank.Queen),
                                new Card(Suit.Spades, Rank.King)
                            });
        }
        
    }
}
