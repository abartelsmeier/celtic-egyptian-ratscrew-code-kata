using NUnit.Framework;
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
    }
}
