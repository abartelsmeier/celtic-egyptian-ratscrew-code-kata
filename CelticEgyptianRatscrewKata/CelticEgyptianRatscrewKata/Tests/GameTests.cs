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
    }
}
