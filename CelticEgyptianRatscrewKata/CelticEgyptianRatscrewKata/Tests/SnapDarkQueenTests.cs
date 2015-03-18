using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapDarkQueenTests
    {
        [Test]
        public void EmptyStackIsNotAValidSnap()
        {
            var snapRule = new DarkQueenSnap();
            var cards = new List<Card>();
            Stack emptyStack = new Stack(cards);

            var result = snapRule.IsSnap(emptyStack);

            Assert.IsFalse(result);
        }

        [Test]
        public void SingleDarkQueenIsValidSnap()
        {
            var snapRule = new DarkQueenSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Spades, Rank.Queen)

                        };
            Stack snapStack = new Stack(cards);

            var result = snapRule.IsSnap(snapStack);

            Assert.IsTrue(result);

        }
    }
}