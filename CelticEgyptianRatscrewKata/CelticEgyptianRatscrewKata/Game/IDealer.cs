using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    interface IDealer
    {
        IEnumerable<Cards> Deal(int numberOfHands, Cards deck);
    }
}
