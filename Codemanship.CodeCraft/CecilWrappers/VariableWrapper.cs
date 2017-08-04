using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class VariableWrapper : CodeWrapper, IVariable
    {
        private readonly VariableDefinition _variable;

        public VariableWrapper(VariableDefinition variable, ICodeObject parent) : base(parent)
        {
            _variable = variable;
        }

        public override string Name
        {
            get { return _variable.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof(ICodeObject), this);
        }

        public string CodeObjectType
        {
            get { return "Variable"; }
        }

        public bool Ignore
        {
            get { return _variable.Name.Contains("CachedAnonymousMethodDelegate"); }
        }
    }
}