using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    public class SnapValidator : ISnapValidator
    {
        public bool CanSnap(Cards stack, IEnumerable<IRule> rules)
        {
            return rules.Any(rule => rule.CanSnap(stack));
        }
    }
}