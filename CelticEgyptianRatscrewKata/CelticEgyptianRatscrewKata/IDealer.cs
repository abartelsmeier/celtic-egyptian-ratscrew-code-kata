using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata
{
    interface IDealer
    {
        IEnumerable<Cards> Deal(int numberOfHands, Cards deck);
    }
}
