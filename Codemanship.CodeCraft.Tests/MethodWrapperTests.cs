using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
{
    [TestFixture]
    public class MethodWrapperTests
    {
        [Test]
        public void MethodIsNamedCodeObject()
        {
            MethodDefinition method = new MethodDefinition("DoFoo", MethodAttributes.Public, ModuleMother.TypeSystem.Void);
            ICodeObject wrappedMethod = new MethodWrapper(method);
            Assert.That(wrappedMethod.Name, Is.EqualTo("DoFoo"));
        }
    }
}
