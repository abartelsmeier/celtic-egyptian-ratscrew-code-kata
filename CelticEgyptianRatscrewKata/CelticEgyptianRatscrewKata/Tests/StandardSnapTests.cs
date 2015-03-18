using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class StandardSnapTests
    {
        [Test]
        public void EmptyStackIsNotAValidSnap()
        {
            var standardSnap = new StandardSnap();
            var cards = new List<Card>();
            Stack emptyStack = new Stack(cards);

            var result = standardSnap.IsSnap(emptyStack);

            Assert.IsFalse(result);
        }
    }
}