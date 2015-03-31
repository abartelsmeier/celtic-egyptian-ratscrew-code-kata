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
    class CalloutTests
    {
        [Test]
        public void CreateCallout()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();

            var callout = new Callout(playerSequence);
        }

        [Test]
        public void CreateCalloutAndIncrementRank()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var callout = new Callout(playerSequence);

            callout.IncrementRank();

            Assert.That(callout.CurrentRank, Is.EqualTo(Rank.Two));
        }

        [Test]
        public void CreateCalloutAndIncrementRankFullCycle()
        {
            var playerSequence = Substitute.For<IPlayerSequence>();
            var callout = new Callout(playerSequence);

            foreach (var rank in Enum.GetNames(typeof (Rank)))
            {
                callout.IncrementRank();
            }

            Assert.That(callout.CurrentRank, Is.EqualTo(Rank.Ace));
        }
    }

    public class Callout
    {
        private readonly IPlayerSequence _playerSequence;
        public Rank CurrentRank { get; private set; }

        public Callout(IPlayerSequence playerSequence)
        {
            _playerSequence = playerSequence;
        }

        public void IncrementRank()
        {
            CurrentRank++;
            if (CurrentRank > Rank.King) ResetRank();
        }

        private void ResetRank()
        {
            CurrentRank = Rank.Ace;
        }
    }
}
