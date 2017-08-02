using Mono.Cecil;

namespace Codemanship.CodeCraft.Tests
{
    public class ModuleMother
    {
        public static TypeSystem TypeSystem
        {
            get { return ModuleDefinition.CreateModule("XXX", ModuleKind.Dll).TypeSystem;  }
        }
    }
}