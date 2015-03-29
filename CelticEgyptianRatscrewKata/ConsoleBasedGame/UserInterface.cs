using System;
using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.Tests;

namespace ConsoleBasedGame
{
    class UserInterface : IGameControllerListener
    {
        private Dictionary<Line,string> m_Lines;
        private bool m_GameOver;

        public IEnumerable<PlayerInfo> GetPlayerInfoFromUserLazily()
        {
            bool again;
            do
            {
                Console.Write("Enter player name: ");
                var playerName = Console.ReadLine();
                var playCardKey = AskForKey("Enter play card key: ");
                var snapKey = AskForKey("Enter snap key: ");
                yield return new PlayerInfo(playerName, playCardKey, snapKey);

                var createPlayerKey = AskForKey("Create another player? (y|n): ");
                again = createPlayerKey.Equals('y');
            } while (again);
            m_Lines = new Dictionary<Line, string>(Enum.GetValues(typeof(Line)).Length);
            m_GameOver = false;
            m_Lines[Line.Stack] = "Game Begins";
            Render();
        }

        private static char AskForKey(string prompt)
        {
            Console.Write(prompt);
            var response = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return response;
        }

        public bool TryReadUserInput(out char userInput)
        {
            ConsoleKeyInfo keyPress = Console.ReadKey();
            Console.WriteLine();
            userInput = keyPress.KeyChar;
            return keyPress.Key != ConsoleKey.Escape && !m_GameOver;
        }

        public void Notify(GameControllerUpdate update)
        {
            if (update.State != null)
            {
                int stackCount = update.State.Stack.Count();
                m_Lines[Line.Stack] = String.Format("Stack Size: {0}", stackCount);
                string line = stackCount > 0 ? update.State.Stack.CardAt(0).ToString() : "-";
                m_Lines[Line.TopCard] = String.Format("Top Card: {0}", line);
                m_Lines[Line.Hands] = String.Format("Hands: ");
                m_Lines[Line.Hands] += String.Join(",",
                    update.State.Decks.Select(x => String.Format("{0} ({1})", x.Key.Name, x.Value.Count())).ToArray());
                m_Lines[Line.NextPlayer] = String.Format("Next Player: {0}", update.NextPlayer.Name);
            }
            
            switch (update.Action)
            {
                case GameControllerAction.PlayCardSuccess:
                    if (update.State != null)
                        m_Lines[Line.Action] = String.Format("{0} Lays {1}", update.Player.Name, update.State.Stack.CardAt(0));
                    break;
                case GameControllerAction.PlayCardFail:
                    m_Lines[Line.Action] = String.Format("{0} Has No Cards", update.Player.Name);
                    break;
                case GameControllerAction.AttemptSnapSuccess:
                    m_Lines[Line.Action] = String.Format("{0} Wins Stack", update.Player.Name);
                    break;
                case GameControllerAction.AttemptSnapFail:
                    m_Lines[Line.Action] = String.Format("{0} Attempts Snap Incorrectly", update.Player.Name);
                    break;
                case GameControllerAction.WinGame:
                    m_Lines[Line.Action] = String.Format("{0} Wins Game! Press any key to exit.", update.Player.Name);
                    m_GameOver = true;
                    break;
            }
            Render();
        }
        
        private void Render()
        {
            Console.Clear();

            foreach (var line in m_Lines.OrderBy(i => i.Key))
            {
                Console.WriteLine(line.Value);
            }
        }

        private enum Line
        {
            Stack,
            TopCard,
            Hands,
            Action,
            NextPlayer
        }
    }
}