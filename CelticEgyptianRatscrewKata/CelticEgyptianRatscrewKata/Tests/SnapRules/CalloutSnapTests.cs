using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
