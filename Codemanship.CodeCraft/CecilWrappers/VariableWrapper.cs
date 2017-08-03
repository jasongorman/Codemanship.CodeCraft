using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class VariableWrapper : CodeWrapper, IVariable
    {
        private readonly VariableDefinition _variable;
        private readonly IMethod _method;

        public VariableWrapper(VariableDefinition variable, IMethod method)
        {
            _variable = variable;
            _method = method;
        }

        public string Name
        {
            get { return _variable.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof(ICodeObject), this);
        }

        public string DisplayName
        {
            get { return _method.DisplayName + "::" + _variable.Name; }
        }

        public string CodeObjectType
        {
            get { return "Variable"; }
        }

        public bool Ignore
        {
            get { return false; }
        }
    }
}