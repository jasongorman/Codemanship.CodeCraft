using System.Collections.Generic;
using System.Linq;
using Codemanship.CodeCraft.CodeListeners;
using Codemanship.CodeCraft.Tests.Doubles;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CodeListeners
{
    [TestFixture]
    public class DefaultCodeListenerTests
    {
        [Test]
        public void BrokenRulesAreRecordedByRuleType()
        {
            ICodeListener listener = new DefaultCodeListener();
            ICodeObject source = new CodeObjectStub("Foo");
            var rule = ((ICodeRule) new RuleStub(listener));
            rule.Check(source);
            IEnumerable<IBrokenRule> brokenRules = listener.GetBrokenRules(rule);
            Assert.That(brokenRules.Count(r => r.Source == source), Is.EqualTo(1));
        }

        [Test]
        public void WhenNoBrokenRulesForRuleThenReturnsEmptyList()
        {
            ICodeListener listener = new DefaultCodeListener();
            var rule = ((ICodeRule)new RuleStub(listener));
            Assert.That(listener.GetBrokenRules(rule), Is.Empty);
        }
    }
}
