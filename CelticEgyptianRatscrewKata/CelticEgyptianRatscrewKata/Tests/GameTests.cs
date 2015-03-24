﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameTests
    {
        [Test]
        public void GameWithEmptyCardsAndPlayers()
        {
            Cards deck = new Cards(new List<Card>());
            List<Player> players = new List<Player>();

            Game game = new Game(players, deck);
        }

        [Test]
        public void GameWithSingleCardsAndSinglePlayer()
        {
            Cards deck = new Cards(new List<Card> { GameTestVariables.AceOfClubs() });
            List<Player> players = new List<Player> { new Player("Player 1") };

            Game game = new Game(players, deck);
        }

        [Test]
        public void GameWithMultipleCardsAndMultiplePlayers()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.TwoOfClubs(),
                                GameTestVariables.ThreeOfClubs()
                            });
            List<Player> players = new List<Player>
                            {
                                new Player("Player 1"),
                                new Player("Player 2"),
                                new Player("Player 3")
                            };

            Game game = new Game(players, deck);
        }

        [Test]
        public void GameStartShufflesDeck()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.TwoOfClubs(),
                                GameTestVariables.ThreeOfClubs()
                            });
            List<Player> players = new List<Player>
                            {
                                new Player("Player 1"),
                                new Player("Player 2"),
                                new Player("Player 3")
                            };
            Game game = new Game(players, deck);

            game.Start();
        }

        [Test]
        public void GameStartDealsDeck()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.TwoOfClubs(),
                                GameTestVariables.ThreeOfClubs()
                            });
            List<Player> players = new List<Player>
                            {
                                new Player("Player 1"),
                                new Player("Player 2"),
                                new Player("Player 3")
                            };
            Game game = new Game(players, deck);

            game.Start();

            Assert.IsTrue(game.DeckContainsAllCardsIn(deck));
        }

        [Test]
        public void GamePlayOneCard()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs()
                            });
            var player1 = new Player("Player 1");
            List<Player> players = new List<Player>
                            {
                                player1
                            };
            Game game = new Game(players, deck);
            game.Start();

            game.PlayCard(player1);

            Assert.That(game.Stack, Is.EqualTo(deck));
        }

        [Test]
        public void GameAttemptInvalidSnap()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs()
                            });
            var player1 = new Player("Player 1");
            List<Player> players = new List<Player>
                            {
                                player1
                            };
            Game game = new Game(players, deck);
            game.Start();
            game.PlayCard(player1);

            bool result = game.AttemptSnap(player1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GameAttemptValidSnap()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.AceOfDiamonds()
                            });
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            List<Player> players = new List<Player>
                            {
                                player1,
                                player2
                            };
            Game game = new Game(players, deck);
            game.Start();
            game.PlayCard(player1);
            game.PlayCard(player2);
            
            bool result = game.AttemptSnap(player1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GameCheckIfThereIsAWinner()
        {
            Cards deck = new Cards(new List<Card> 
                            {
                                GameTestVariables.AceOfClubs(),
                                GameTestVariables.AceOfDiamonds()
                            });
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            List<Player> players = new List<Player>
                            {
                                player1,
                                player2
                            };
            Game game = new Game(players, deck);
            game.Start();
            game.PlayCard(player1);
            game.PlayCard(player2);
            game.AttemptSnap(player1);

            IPlayer winner = game.IsWinner();

            Assert.That(winner, Is.Not.EqualTo(null));
        }
    }
}
