using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
{
    [TestFixture]
    public class VariableWrapperTests
    {
        [Test]
        public void VariableIsNamedCodeObject()
        {
            VariableDefinition variable = new VariableDefinition("y", ModuleMother.TypeSystem.Int32);
            ICodeObject wrappedVariable = new VariableWrapper(variable, null);
            Assert.That(wrappedVariable.Name, Is.EqualTo("y"));
        }
    }
}
