using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.Rules;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
{
    [TestFixture]
    public class IdentifierLengthRuleTests
    {
        [Test]
        public void IdentifiersWithMoreThanTwentyCharsBreakRule()
        {
            CheckIfRuleBroken("012345678901234567890", Times.Once);
        }

        [Test]
        public void IdentifiersWithNoMoreThanTwentyCharsDoNotBreakRule()
        {
            CheckIfRuleBroken("01234567890123456789", Times.Never);
        }

        private void CheckIfRuleBroken(string identifier, Func<Times> ruleBrokenInvoked)
        {
            var listener = new Mock<ICodeListener>();
            ICodeRule rule
                = new IdentifierLengthRule(new List<ICodeListener>() {listener.Object});
            ICodeObject source = new CodeObjectStub(identifier);
            rule.Check(source);
            listener.Verify(x => x.RuleBroken(rule, source), ruleBrokenInvoked);
        }
    }

    public class CodeObjectStub : ICodeObject
    {
        public string Name { get; set; }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            
        }

        public CodeObjectStub(string name)
        {
            Name = name;
        }
    }
}
