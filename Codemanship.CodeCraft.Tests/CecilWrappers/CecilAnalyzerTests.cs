using System.IO;
using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
{
    [TestFixture]
    public class CecilAnalyzerTests
    {
        [Test]
        public void WalksStubAssembly()
        {
            ILoader loader = new AssemblyLoaderStub(AssemblyMother.BuildTestAssembly());
            StringWriter output = new StringWriter();
            CecilAnalyzer analyzer = new CecilAnalyzer(output, loader);
            analyzer.Analyze(new string[]{@"C:\MyProject\MyDll.dll"});
            Assert.That(output.ToString().Contains("RULE"));
        }
    }

    public class AssemblyLoaderStub : ILoader
    {
        private readonly AssemblyDefinition _testAssembly;

        public AssemblyLoaderStub(AssemblyDefinition testAssembly)
        {
            _testAssembly = testAssembly;
        }

        public IAssembly Load(string assemblyPath)
        {
            return new AssemblyWrapper(_testAssembly);
        }
    }
}
