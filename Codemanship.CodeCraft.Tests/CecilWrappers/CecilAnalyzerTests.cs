using System.IO;
using System.Reflection;
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
            ILoader loader = new AssemblyLoader();
            StringWriter output = new StringWriter();
            CecilAnalyzer analyzer = new CecilAnalyzer(output, loader);
            analyzer.Analyze(new string[] { Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\SampleCode.dll" });
            Assert.That(output.ToString().Contains("RULE"));
        }
    }
}
