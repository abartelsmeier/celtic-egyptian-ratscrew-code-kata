using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameControllerTests
    {
        [Test]
        public void GameWithEmptyCardsAndPlayers()
        {
            Cards deck = new Cards(new List<Card>());
            List<Player> players = new List<Player>();

            GameController game = new GameController(players, deck, Rules());
        }

        [Test]
        public void GameWithSingleCardsAndSinglePlayer()
        {
            Cards deck = new Cards(new List<Card> { new Card(Suit.Clubs, Rank.Ace) });
            List<Player> players = new List<Player> { new Player("Player 1") };

            GameController game = new GameController(players, deck, Rules());
        }

        [Test]
        public void GameWithMultipleCardsAndMultiplePlayers()
        {
            Cards deck = DeckWithoutSnap();
            List<Player> players = Players();

            GameController game = new GameController(players, deck, Rules());
        }

        [Test]
        public void GameAttemptInvalidSnap()
        {
            Cards deck = new Cards(new List<Card>{ new Card(Suit.Clubs, Rank.Ace) });
            var player = new Player("Player 1");
            List<Player> players = new List<Player>{ player };
            GameController game = new GameController(players, deck, Rules());
            game.Start();
            game.PlayCard(player);

            bool result = game.AttemptSnap(player);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GameAttemptValidSnap()
        {
            Cards deck = DeckWithSnap();
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            List<Player> players = new List<Player>
                                   {
                                       player1,
                                       player2
                                   };
            GameController game = new GameController(players, deck, Rules());
            game.Start();
            game.PlayCard(player1);
            game.PlayCard(player2);
            
            bool result = game.AttemptSnap(player1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GameCheckIfThereIsAWinner()
        {
            Cards deck = DeckWithSnap();
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            List<Player> players = new List<Player>
                                   {
                                       player1,
                                       player2
                                   };
            GameController game = new GameController(players, deck, Rules());
            game.Start();
            game.PlayCard(player1);
            game.PlayCard(player2);
            game.AttemptSnap(player1);

            IPlayer winner = game.Winner();

            Assert.That(winner, Is.EqualTo(player1));
        }

        public static List<IRule> Rules()
        {
            return new List<IRule>
                   {
                       new StandardSnapRule(),
                       new SandwichSnapRule(),
                       new DarkQueenSnapRule()
                   };
        }

        public static Cards DeckWithoutSnap()
        {
            return new Cards(new List<Card>
                             {
                                 new Card(Suit.Clubs, Rank.Ace),
                                 new Card(Suit.Clubs, Rank.Two),
                                 new Card(Suit.Clubs, Rank.Three)
                             });
        }

        public static Cards DeckWithSnap()
        {
            return new Cards(new List<Card>
                             {
                                 new Card(Suit.Clubs, Rank.Ace),
                                 new Card(Suit.Diamonds, Rank.Ace),
                                 new Card(Suit.Hearts, Rank.Ace)
                             });
        }

        public static List<Player> Players()
        {
            return new List<Player>
                   {
                       new Player("Player 1"),
                       new Player("Player 2")
                   };
        }

        public static Cards WholeDeck()
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
