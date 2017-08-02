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
    public class AssemblyWrapperTests
    {
        [Test]
        public void AssemblyIsNamedCodeObject()
        {
            var assembly = AssemblyDefinition.CreateAssembly(
                new AssemblyNameDefinition("HelloWorld", new Version(1, 0, 0, 0)), 
                    "HelloWorld", 
                    ModuleKind.Dll);

            ICodeObject wrappedAssembly = new AssemblyWrapper(assembly);
            Assert.That(wrappedAssembly.Name, Is.EqualTo("HelloWorld"));
        }
    }
}
