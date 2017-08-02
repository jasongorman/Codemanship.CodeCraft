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
            ICodeRule[] codeObjectRules = rules[typeof (ICodeObject)];
            Array.ForEach(codeObjectRules, rule => rule.Check(this));

            List<IType> types = _assembly.MainModule.Types.Select(t => (IType)new TypeWrapper(t)).ToList();
            types.ForEach(t => t.Walk(rules));
        }
    }
}