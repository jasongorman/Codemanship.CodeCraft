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
    public class FieldWrapperTests
    {
        [Test]
        public void FieldIsNamedCodeObject()
        {
            FieldDefinition field = new FieldDefinition("_bar", FieldAttributes.Private, ModuleMother.TypeSystem.String);
            ICodeObject wrappedField = new FieldWrapper(field);
            Assert.That(wrappedField.Name, Is.EqualTo("_bar"));
        }
    }
}
