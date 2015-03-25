using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    interface ISnapValidator
    {
        bool CanSnap(Cards stack, IEnumerable<IRule> rules);
    }
}
