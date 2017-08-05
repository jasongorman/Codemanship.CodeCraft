using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.Rules;
using Codemanship.CodeCraft.Tests.Doubles;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.Rules
{
    [TestFixture]
    public class PathCountRuleTests
    {
        [Test]
        public void MethodWithMoreThanThreePathsBreaksRule()
        {
            CheckIfRuleBroken(pathCount:4, expectedInvocations: Times.Once);
        }

        [Test]
        public void MethodWithNoMoreThanThreePathsDoesNotBreakRule()
        {
            CheckIfRuleBroken(pathCount:3, expectedInvocations: Times.Never);
        }

        private void CheckIfRuleBroken(int pathCount, Func<Times> expectedInvocations)
        {
            IMethod source = new MethodStub(pathCount, 0);
            var listener = new Mock<ICodeListener>();
            List<ICodeListener> listeners = new List<ICodeListener>() {listener.Object};
            ICodeRule rule = new PathCountRule(listeners);
            rule.Check(source);
            listener.Verify(x => x.RuleBroken(rule, source), expectedInvocations);
        }
    }
}
