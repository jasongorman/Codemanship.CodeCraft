using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Codemanship.CodeCraft.Rules;
using Mono.Cecil;
using Mono.CompilerServices.SymbolWriter;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class AssemblyWrapper : IAssembly
    {
        private readonly AssemblyDefinition _assembly;

        public AssemblyWrapper(AssemblyDefinition assembly)
        {
            _assembly = assembly;
        }

        public string Name
        {
            get { return _assembly.Name.Name.Split(',')[0]; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            // No rules checks for assemblies

            List<IType> types =
                _assembly.MainModule.Types.Select(t => (IType) new TypeWrapper(t, null))
                    .Where(c => !c.Ignore)
                    .ToList();
            types.ForEach(t => t.Walk(rules));
        }
    }
}