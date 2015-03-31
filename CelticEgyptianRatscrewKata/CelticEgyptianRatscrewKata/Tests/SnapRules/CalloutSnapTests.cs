using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    class CalloutSnapTests
    {
        [Test]
        public void ReturnsFalseOnEmptyStack()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();
            var callout = new LoggedCallout(playerSequence, log);
            var snapRule = new CallOutSnapRule(callout);

            bool result = snapRule.IsSnapValid(Cards.Empty());

            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueOnSingleCardStack()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();
            var callout = new LoggedCallout(playerSequence, log);
            var snapRule = new CallOutSnapRule(callout);
            callout.IncrementRank();//Increment Rank as in first player advance
            
            bool result = snapRule.IsSnapValid(SingleCardStack());

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueOnThreeCardStack()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();
            var callout = new LoggedCallout(playerSequence, log);
            var snapRule = new CallOutSnapRule(callout);
            callout.IncrementRank();//Increment Rank as in first player advance
            
            bool result = snapRule.IsSnapValid(ThreeCardStack());

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsFalseOnThreeCardStackWithIncrementedCalloutRank()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();
            var callout = new LoggedCallout(playerSequence, log);
            var snapRule = new CallOutSnapRule(callout);
            callout.IncrementRank();//Increment Rank as in first player advance

            callout.IncrementRank();
            bool result = snapRule.IsSnapValid(ThreeCardStack());
            
            Assert.IsFalse(result);
        }

        public static Cards SingleCardStack()
        {
            return new Cards(new List<Card>
                             {
                                 new Card(Suit.Clubs, Rank.Ace)
                             });
        }

        public static Cards ThreeCardStack()
        {
            return new Cards(new List<Card>
                             {
                                 new Card(Suit.Clubs, Rank.Ace),
                                 new Card(Suit.Clubs, Rank.Two),
                                 new Card(Suit.Clubs, Rank.Three)
                             });
        }
    }
}
