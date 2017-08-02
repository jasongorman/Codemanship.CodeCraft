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
    public class TypeWrapperTests
    {
        [Test]
        public void TypeIsNamedCodeObject()
        {
            TypeDefinition type = new TypeDefinition("XXX", "Foo", TypeAttributes.Class);
            ICodeObject wrappedType = new TypeWrapper(type);
            Assert.That(wrappedType.Name, Is.EqualTo("Foo"));
        }
    }
}
