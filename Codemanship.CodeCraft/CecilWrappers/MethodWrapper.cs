using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class MethodWrapper : IMethod
    {
        private readonly MethodDefinition _method;

        public MethodWrapper(MethodDefinition method)
        {
            _method = method;
        }

        public string Name
        {
            get { return _method.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            ICodeRule[] codeObjectRules = rules[typeof(ICodeObject)];
            Array.ForEach(codeObjectRules, rule => rule.Check(this));

            List<IParameter> parameters = _method.Parameters.Select(t => (IParameter)new ParameterWrapper(t)).ToList();
            parameters.ForEach(t => t.Walk(rules));

            if (_method.Body != null)
            {
                List<IVariable> variables =
                    _method.Body.Variables.Select(t => (IVariable) new VariableWrapper(t)).ToList();
                parameters.ForEach(t => t.Walk(rules));
            }

        }
    }
}