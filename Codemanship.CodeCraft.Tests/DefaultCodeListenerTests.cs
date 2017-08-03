using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CodeListeners;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
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
    }
}
