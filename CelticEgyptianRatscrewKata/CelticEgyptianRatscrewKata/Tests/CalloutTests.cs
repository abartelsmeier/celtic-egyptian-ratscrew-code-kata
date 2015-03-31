using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class CalloutTests
    {
        [Test]
        public void CreateCalloutInstance()
        {
            var callout = new Callout();
        }

        [Test]
        public void CreateCalloutInstanceAndIncrementRank()
        {
            var callout = new Callout();

            callout.IncrementRank();

            Assert.That(callout.CurrentRank, Is.EqualTo(Rank.Two));
        }
    }

    public class Callout
    {
        public Rank CurrentRank { get; private set; }

        public void IncrementRank()
        {
            CurrentRank++;
        }
    }
}
