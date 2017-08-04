using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
{
    [TestFixture]
    public class MethodWrapperTests
    {
        [Test]
        public void MethodIsNamedCodeObject()
        {
            MethodDefinition method = new MethodDefinition("DoFoo", MethodAttributes.Public, ModuleMother.TypeSystem.Void);
            ICodeObject wrappedMethod = new MethodWrapper(method, null, new CecilWrapperFactory());
            Assert.That(wrappedMethod.Name, Is.EqualTo("DoFoo()"));
        }
    }
}
