using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CecilWrappers;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.Integration
{
    [TestFixture]
    public class AssemblyLoaderTests
    {
        [Test]
        public void LoadsTestAssembly()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\SampleCode.dll";
            IAssembly assembly = new AssemblyLoader().Load(path);
            Assert.That(assembly.Name.Contains("SampleCode"));
        }
    }
}
