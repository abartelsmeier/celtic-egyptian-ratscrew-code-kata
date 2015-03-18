using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SandwichSnapTests
    {
        [Test]
        public void EmptyStackIsNotAValidSnap()
        {
            var sandwichSnap = new SandwichSnap();
            var cards = new List<Card>();
            Stack emptyStack = new Stack(cards);

            var result = sandwichSnap.IsSnap(emptyStack);

            Assert.IsFalse(result);
        } 
    }
}