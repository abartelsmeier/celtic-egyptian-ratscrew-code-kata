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

        [Test]
        public void TwoCardsSameRankIsValidSnap()
        {
            var standardSnap = new StandardSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Clubs, Rank.Two),
                            new Card(Suit.Diamonds, Rank.Two)

                        };
            Stack snapStack = new Stack(cards);
            
            var result = standardSnap.IsSnap(snapStack);

            Assert.IsTrue(result);

        }

        [Test]
        public void TwoCardsSameRankInMiddleOfStackIsValidSnap()
        {
            var standardSnap = new StandardSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Clubs, Rank.Ace),
                            new Card(Suit.Clubs, Rank.Two),
                            new Card(Suit.Diamonds, Rank.Two),
                            new Card(Suit.Clubs, Rank.Three),

                        };
            Stack snapStack = new Stack(cards);

            var result = standardSnap.IsSnap(snapStack);

            Assert.IsTrue(result);
        }

        [Test]
        public void OneCardInStackIsNotValidSnap()
        {
            var standardSnap = new StandardSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Clubs, Rank.Ace)
                        };
            Stack snapStack = new Stack(cards);

            var result = standardSnap.IsSnap(snapStack);

            Assert.IsFalse(result);
        }
    }
}