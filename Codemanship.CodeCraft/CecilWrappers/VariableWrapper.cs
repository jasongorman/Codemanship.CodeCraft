using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class VariableWrapper : IVariable
    {
        private readonly VariableDefinition _variable;

        public VariableWrapper(VariableDefinition variable)
        {
            _variable = variable;
        }

        public string Name
        {
            get { return _variable.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            ICodeRule[] codeObjectRules = rules[typeof(ICodeObject)];
            Array.ForEach(codeObjectRules, rule => rule.Check(this));
        }
    }
}