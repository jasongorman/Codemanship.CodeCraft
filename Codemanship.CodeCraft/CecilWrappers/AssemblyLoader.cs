using Mono.Cecil;
using Mono.Cecil.Pdb;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class AssemblyLoader : ILoader
    {

        public IAssembly Load(string assemblyPath)
        {
            AssemblyDefinition assembly
                = AssemblyDefinition.ReadAssembly((string) assemblyPath,
                    new ReaderParameters() {ReadSymbols = true, SymbolReaderProvider = new PdbReaderProvider()});
            return new AssemblyWrapper(assembly, new CecilWrapperFactory());
        }
    }
}