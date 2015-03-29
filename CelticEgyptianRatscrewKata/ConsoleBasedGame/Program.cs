using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();

            GameController game = new GameFactory().Create(userInterface);

            var playerActions = new PlayerActions();
            
            IEnumerable<PlayerInfo> playerInfos = userInterface.GetPlayerInfoFromUserLazily();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                var player = new Player(playerInfo.PlayerName);
                game.AddPlayer(player);
                playerActions.Add(playerInfo.SnapKey, game.AttemptSnap, player);
                playerActions.Add(playerInfo.PlayCardKey, game.PlayCard, player);
            }

            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (userInterface.TryReadUserInput(out userInput))
            {
                playerActions.HandleKey(userInput);
                userInterface.Render();
            } 
        }
    }
}
