using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Represents the state of the game at any point.
    /// </summary>
    public class GameState : IGameState
    {
        private readonly Cards m_Stack;
        private readonly IDictionary<IPlayer, Cards> m_Decks;
        private readonly IGameStateListener m_Listener;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameState()
            : this(Cards.Empty(), new Dictionary<IPlayer, Cards>(), null) { }

        public GameState(IGameStateListener listener)
            : this(Cards.Empty(), new Dictionary<IPlayer, Cards>(), listener) { }

        /// <summary>
        /// Constructor to allow setting the central stack.
        /// </summary>
        public GameState(Cards stack, IDictionary<IPlayer, Cards> decks, IGameStateListener listener)
        {
            m_Stack = stack;
            m_Decks = decks;
            m_Listener = listener;
        }

        public Cards Stack { get {return new Cards(m_Stack);} }

        public void AddPlayer(IPlayer player, Cards deck)
        {
            if (m_Decks.ContainsKey(player)) throw new ArgumentException("Can't add the same player twice");
            m_Decks.Add(player, deck);
        }

        public void PlayCard(IPlayer player)
        {
            if (!m_Decks.ContainsKey(player)) throw new ArgumentException("The selected player doesn't exist");
            if (!m_Decks[player].Any()) throw new ArgumentException("The selected player doesn't have any cards left");

            var topCard = m_Decks[player].Pop();
            m_Stack.AddToTop(topCard);

            if (m_Listener != null) m_Listener.Notify(new GameStateUpdate(m_Stack, player, null, m_Decks));
        }
        
        public void WinStack(IPlayer player)
        {
            if (!m_Decks.ContainsKey(player)) throw new ArgumentException("The selected player doesn't exist");

            foreach (var card in m_Stack.Reverse())
            {
                m_Decks[player].AddToBottom(card);
            }

            ClearStack();
        }

        private void ClearStack()
        {
            while (m_Stack.HasCards)
            {
                m_Stack.RemoveCardAt(0);
            }
        }

        public bool HasCards(IPlayer player)
        {
            if (!m_Decks.ContainsKey(player)) throw new ArgumentException("The selected player doesn't exist");
            return m_Decks[player].Any();
        }

        public void Clear()
        {
            ClearStack();
            m_Decks.Clear();
        }
    }
}
