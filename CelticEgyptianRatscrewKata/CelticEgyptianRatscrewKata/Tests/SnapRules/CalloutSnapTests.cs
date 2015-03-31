using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    class CalloutSnapTests
    {
        [Test]
        public void ReturnsFalseOnEmptyStack()
        {
            var snapRule = new CallOutSnapRule();

            bool result = snapRule.IsValidSnap(Cards.Empty());

            Assert.IsFalse(result);
        }
    }

    public class CallOutSnapRule
    {
        public bool IsValidSnap(Cards cards)
        {
            return false;
        }
    }
}
