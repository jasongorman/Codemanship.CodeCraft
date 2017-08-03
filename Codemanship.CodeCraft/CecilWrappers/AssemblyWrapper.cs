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
            get { return _assembly.Name.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            // No rules checks for assemblies

            List<IType> types =
                _assembly.MainModule.Types.Select(t => (IType) new TypeWrapper(t))
                    .Where(c => !c.Ignore)
                    .ToList();
            types.ForEach(t => t.Walk(rules));
        }

        public string DisplayName
        {
            get { return _assembly.FullName; }
        }

        public string CodeObjectType
        {
            get { return "Assembly"; }
        }

        public bool Ignore
        {
            get { return false; }
        }
    }
}