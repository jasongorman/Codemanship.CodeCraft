using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CodeListeners;
using Codemanship.CodeCraft.Tests.Doubles;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
{
    [TestFixture]
    public class TextResultFormatterTests
    {
        [Test]
        public void WritesBrokenRuleToText()
        {
            ICodeRule rule = new RuleStub(null);
            ICodeObject source = new CodeObjectStub("Foo");
            IBrokenRule brokenRule = new BrokenRule(rule, source);

            const string expectedText = "RULE: Stub Rule - Method: FullName.Foo\nADVICE: Buy low, sell high\n";

            IResultFormatter writer = new TextResultFormatter();

            Assert.That(writer.Format(brokenRule), Is.EqualTo(expectedText));
        }
    }
}
