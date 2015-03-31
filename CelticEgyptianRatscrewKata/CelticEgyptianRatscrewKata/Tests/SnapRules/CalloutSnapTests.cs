using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.SnapRules;
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

            bool result = snapRule.IsSnapValid(Cards.Empty());

            Assert.IsFalse(result);
        }
    }

    public class CallOutSnapRule : ISnapRule
    {
        public bool IsSnapValid(Cards cardStack)
        {
            return false;
        }
    }
}
