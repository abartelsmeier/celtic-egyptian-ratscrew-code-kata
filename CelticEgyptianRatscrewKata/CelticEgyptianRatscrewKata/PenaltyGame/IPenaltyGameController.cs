using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.PenaltyGame
{
    public interface IPenaltyGameController
    {
        bool AddPlayer(IPlayer player);
        Card PlayCard(IPlayer player);
        bool AttemptSnap(IPlayer player);

        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        void StartGame(Cards deck);

        bool TryGetWinner(out IPlayer winner);
        IEnumerable<IPlayer> Players { get; }
        int StackSize { get; }
        Card TopOfStack { get; }
        int NumberOfCards(IPlayer player);

        Card PlayCardOutOfTurn(IPlayer player);
    }
}