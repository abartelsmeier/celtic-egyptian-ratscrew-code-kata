using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class LoggedCalloutTests
    {
        [Test]
        public void CreateCallout()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();

            var callout = new LoggedCallout(playerSequence, log);
        }

        [Test]
        public void CreateCalloutAndIncrementRank()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();
            var callout = new LoggedCallout(playerSequence, log);
            callout.IncrementRank();//Increment Rank as in first player advance

            callout.IncrementRank();

            Assert.That(callout.CurrentRank, Is.EqualTo(Rank.Two));
        }

        [Test]
        public void CreateCalloutAndIncrementRankFullCycle()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var log = Substitute.For<ILog>();
            var callout = new LoggedCallout(playerSequence, log);
            callout.IncrementRank();//Increment Rank as in first player advance

            foreach (var rank in Enum.GetNames(typeof (Rank)))
            {
                callout.IncrementRank();
            }

            Assert.That(callout.CurrentRank, Is.EqualTo(Rank.Ace));
        }
    }
}
