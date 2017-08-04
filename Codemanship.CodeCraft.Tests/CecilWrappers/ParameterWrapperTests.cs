using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
{
    [TestFixture]
    public class ParameterWrapperTests
    {
        [Test]
        public void ParameterIsNamedCodeObject()
        {
            ParameterDefinition parameter = new ParameterDefinition("x", ParameterAttributes.In, ModuleMother.TypeSystem.Int32);
            ICodeObject wrappedParameter = new ParameterWrapper(parameter, null);
            Assert.That(wrappedParameter.Name, Is.EqualTo("x"));
        }
    }
}
