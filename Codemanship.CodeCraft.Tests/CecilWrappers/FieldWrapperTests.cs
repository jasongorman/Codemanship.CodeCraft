using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
{
    [TestFixture]
    public class FieldWrapperTests
    {
        [Test]
        public void FieldIsNamedCodeObject()
        {
            FieldDefinition field = new FieldDefinition("_bar", FieldAttributes.Private, ModuleMother.TypeSystem.String);
            ICodeObject wrappedField = new FieldWrapper(field, null);
            Assert.That(wrappedField.Name, Is.EqualTo("_bar"));
        }
    }
}
