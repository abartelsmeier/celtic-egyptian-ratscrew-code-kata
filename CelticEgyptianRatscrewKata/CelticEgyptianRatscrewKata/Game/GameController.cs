using System;
using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;
using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Controls a game of Celtic Egyptian Ratscrew.
    /// </summary>
    public class GameController
    {
        private readonly ISnapValidator m_SnapValidator;
        private readonly IDealer m_Dealer;
        private readonly IShuffler m_Shuffler;
        private readonly IList<IPlayer> m_Players;
        private readonly IGameState m_GameState;
        private readonly IGameControllerListener m_Listener;
        private int m_NextPlayer;

        public GameController(IGameState gameState, ISnapValidator snapValidator, IDealer dealer, IShuffler shuffler)
            : this(gameState,snapValidator,dealer,shuffler,null)
        {
        }

        public GameController(IGameState gameState, ISnapValidator snapValidator, IDealer dealer, IShuffler shuffler, IGameControllerListener listener)
        {
            m_Players = new List<IPlayer>();
            m_GameState = gameState;
            m_SnapValidator = snapValidator;
            m_Dealer = dealer;
            m_Shuffler = shuffler;
            m_Listener = listener;
        }

        public bool AddPlayer(IPlayer player)
        {
            if (m_Players.Any(x => x == player)) return false;

            m_Players.Add(player);
            m_GameState.AddPlayer(player, Cards.Empty());
            return true;
        }

        public void PlayCard(IPlayer player)
        {
            var action = GameControllerAction.PlayCardFail;
            GameStateUpdate state = null;

            if (m_GameState.HasCards(player))
            {
                state = m_GameState.PlayCard(player);
                IncrementNextPlayer();

                action = GameControllerAction.PlayCardSuccess;
            }

            if (m_Listener == null) return;
            m_Listener.Notify(PackageUpdate(action, player, state));
        }

        private void IncrementNextPlayer()
        {
            m_NextPlayer++;
            if (m_NextPlayer >= m_Players.Count) m_NextPlayer = 0;
        }

        public void AttemptSnap(IPlayer player)
        {
            AddPlayer(player);

            var action = GameControllerAction.AttemptSnapFail;
            GameStateUpdate state = null;

            if (m_SnapValidator.CanSnap(m_GameState.Stack))
            {
                state = m_GameState.WinStack(player);
                action = GameControllerAction.AttemptSnapSuccess;
                IPlayer testPlayer = player;
                if (TryGetWinner(out testPlayer))
                    action = GameControllerAction.WinGame;
            }

            if (m_Listener == null) return;
            m_Listener.Notify(PackageUpdate(action, player, state));
        }

        private GameControllerUpdate PackageUpdate(GameControllerAction action, IPlayer player, GameStateUpdate state)
        {
            return new GameControllerUpdate(state,player,m_Players.ElementAt(m_NextPlayer),action);
        }
        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        public void StartGame(Cards deck)
        {
            m_GameState.Clear();

            var shuffledDeck = m_Shuffler.Shuffle(deck);
            var decks = m_Dealer.Deal(m_Players.Count, shuffledDeck);
            for (var i = 0; i < decks.Count; i++)
            {
                m_GameState.AddPlayer(m_Players[i], decks[i]);
            }
            m_NextPlayer = 0;
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            var playersWithCards = m_Players.Where(p => m_GameState.HasCards(p)).ToList();

            if (!m_GameState.Stack.Any() && playersWithCards.Count() == 1)
            {
                winner = playersWithCards.Single();
                return true;
            }

            winner = null;
            return false;
        }
    }
}
