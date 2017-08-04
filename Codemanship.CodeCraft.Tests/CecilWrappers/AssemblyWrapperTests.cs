using System;
using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
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

            IAssembly wrappedAssembly = new AssemblyWrapper(assembly, new CecilWrapperFactory());
            Assert.That(wrappedAssembly.Name, Is.EqualTo("HelloWorld"));
        }
    }
}
