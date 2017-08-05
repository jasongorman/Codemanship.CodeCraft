using System;
using System.Collections.Generic;
using Codemanship.CodeCraft.Rules;
using Codemanship.CodeCraft.Tests.Doubles;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.Rules
{
    [TestFixture]
    public class ParameterCountRuleTests
    {
        [Test]
        public void MoreThanThreeParamsBreaksRule()
        {
            CheckIfRuleBroken(4, Times.Once);
        }

        [Test]
        public void ThreeOrLessParamsDoesNotBreakRule()
        {
            CheckIfRuleBroken(3, Times.Never);
        }

        private void CheckIfRuleBroken(int parameterCount, Func<Times> expectedInvocations)
        {
            var listener = new Mock<ICodeListener>();
            ICodeRule rule = new ParameterCountRule(new List<ICodeListener>() {listener.Object});
            ICodeObject source = new MethodStub(1, parameterCount);
            rule.Check(source);
            listener.Verify(x => x.RuleBroken(rule, source), expectedInvocations);
        }
    }
}
