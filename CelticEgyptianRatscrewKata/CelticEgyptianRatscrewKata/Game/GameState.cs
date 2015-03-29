using System;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Represents the state of the game at any point.
    /// </summary>
    public class GameState : IGameState
    {
        private readonly Cards m_Stack;
        private readonly IDictionary<IPlayer, Cards> m_Decks;
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameState()
            : this(Cards.Empty(), new Dictionary<IPlayer, Cards>()) { }

        /// <summary>
        /// Constructor to allow setting the central stack.
        /// </summary>
        public GameState(Cards stack, IDictionary<IPlayer, Cards> decks)
        {
            m_Stack = stack;
            m_Decks = decks;
        }

        public Cards Stack { get {return new Cards(m_Stack);} }
        
        public void AddPlayer(IPlayer player, Cards deck)
        {
            if (m_Decks.ContainsKey(player)) throw new ArgumentException("Can't add the same player twice");
            m_Decks.Add(player, deck);
        }

        public GameStateUpdate PlayCard(IPlayer player)
        {
            if (!m_Decks.ContainsKey(player)) throw new ArgumentException("The selected player doesn't exist");
            if (!m_Decks[player].Any()) throw new ArgumentException("The selected player doesn't have any cards left");

            var topCard = m_Decks[player].Pop();
            m_Stack.AddToTop(topCard);

            return new GameStateUpdate(m_Stack, m_Decks);
        }

        public GameStateUpdate WinStack(IPlayer player)
        {
            if (!m_Decks.ContainsKey(player)) throw new ArgumentException("The selected player doesn't exist");

            foreach (var card in m_Stack.Reverse())
            {
                m_Decks[player].AddToBottom(card);
            }

            ClearStack();

            return new GameStateUpdate(m_Stack, m_Decks);
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
