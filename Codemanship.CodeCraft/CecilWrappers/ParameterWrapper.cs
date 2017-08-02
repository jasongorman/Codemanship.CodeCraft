using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class ParameterWrapper : IParameter
    {
        private readonly ParameterDefinition _parameter;

        public ParameterWrapper(ParameterDefinition parameter)
        {
            _parameter = parameter;
        }

        public string Name
        {
            get { return _parameter.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            ICodeRule[] codeObjectRules = rules[typeof(ICodeObject)];
            Array.ForEach(codeObjectRules, rule => rule.Check(this));
        }
    }
}