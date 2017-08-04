using System;
using System.Collections.Generic;
using Codemanship.CodeCraft.Rules;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.Rules
{
    [TestFixture]
    public class BooleanParameterRuleTests
    {
        [Test]
        public void MethodWithBooleanParamBreaksRule()
        {
            CheckIfRuleBroken(true, Times.Once);
        }

        [Test]
        public void ThreeOrLessParamsDoesNotBreakRule()
        {
            CheckIfRuleBroken(false, Times.Never);
        }

        private void CheckIfRuleBroken(bool isBoolean, Func<Times> expectedInvocations)
        {
            var listener = new Mock<ICodeListener>();
            ICodeRule rule = new BooleanParameterRule(new List<ICodeListener>() { listener.Object });
            IParameter source = new ParameterStub(isBoolean);
            rule.Check(source);
            listener.Verify(x => x.RuleBroken(rule, source), expectedInvocations);
        }
    }

    internal class ParameterStub : IParameter
    {
        private readonly bool _isBoolean;

        public ParameterStub(bool isBoolean)
        {
            _isBoolean = isBoolean;
        }

        public string Name
        {
            get { return ""; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {

        }

        public string DisplayName
        {
            get { return ""; }
        }

        public string CodeObjectType
        {
            get { return ""; }
        }

        public bool Ignore
        {
            get { return false; }
        }

        public bool IsBoolean
        {
            get { return _isBoolean; }
        }
    }
}
