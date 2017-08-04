using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CecilWrappers;
using Codemanship.CodeCraft.Rules;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
{
    [TestFixture]
    public class CodeWalkerTests
    {
        [Test]
        public void AppliesCodeObjectRuleToEveryCodeObject()
        {
            var assembly = AssemblyMother.BuildTestAssembly();

            IAssembly wrappedAssembly = new AssemblyWrapper(assembly);

            var mockListener = new Mock<ICodeListener>();
            var codeListeners = new List<ICodeListener>(){mockListener.Object};
            Dictionary<Type, ICodeRule[]> rules = new Dictionary<Type, ICodeRule[]>(){{typeof(ICodeObject), new ICodeRule[]{new IdentifierLengthRule(codeListeners)}}};
            wrappedAssembly.Walk(rules);
            mockListener.Verify(x => x.RuleBroken(It.IsAny<ICodeRule>(), It.IsAny<ICodeObject>()), Times.AtLeastOnce);
        }
    }
}
