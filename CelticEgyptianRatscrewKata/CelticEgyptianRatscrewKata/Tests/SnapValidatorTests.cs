using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapValidatorTests
    {
        [Test]
        public void SnapValidatorReturnsFalseWithNoSnapRules()
        {
            List<ISnapRule> rules = new List<ISnapRule>();
            var snapValidator = new SnapValidator(rules);
            
            IEnumerable<Card> cards = new List<Card>();
            Stack stack = new Stack(cards);
            var result = snapValidator.IsSnap(stack);

            Assert.IsFalse(result);
        }
    }
}