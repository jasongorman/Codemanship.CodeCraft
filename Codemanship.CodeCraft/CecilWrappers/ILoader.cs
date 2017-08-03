using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public interface ILoader
    {
        IAssembly Load(string assemblyPath);
    }
}