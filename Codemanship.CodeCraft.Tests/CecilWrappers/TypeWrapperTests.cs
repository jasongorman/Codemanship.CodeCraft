using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
{
    [TestFixture]
    public class TypeWrapperTests
    {
        [Test]
        public void TypeIsNamedCodeObject()
        {
            TypeDefinition type = new TypeDefinition("XXX", "Foo", TypeAttributes.Class);
            ICodeObject wrappedType = new TypeWrapper(type, null, new CecilWrapperFactory());
            Assert.That(wrappedType.Name, Is.EqualTo("Foo"));
        }
    }
}
