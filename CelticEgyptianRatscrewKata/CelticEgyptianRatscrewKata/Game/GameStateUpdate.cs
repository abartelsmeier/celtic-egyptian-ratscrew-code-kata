using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public class GameStateUpdate
    {
        public Cards Stack { get; private set; }
        public IDictionary<IPlayer, Cards> Decks { get; private set; }

        public GameStateUpdate(Cards stack, IDictionary<IPlayer, Cards> decks)
        {
            Stack = stack;
            Decks = decks;
        }
    }
}