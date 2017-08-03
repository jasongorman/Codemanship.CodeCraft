using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class MethodWrapper : CodeWrapper, IMethod
    {
        private readonly MethodDefinition _method;

        public MethodWrapper(MethodDefinition method)
        {
            _method = method;
        }

        public string Name
        {
            get
            {
                var name = _method.Name;
                name = Regex.Replace(name, "get_", "");
                name = Regex.Replace(name, "set_", "");
                return name;
            }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeObject), this);
            CheckRule(rules, typeof(IMethod), this);

            List<IParameter> parameters = _method.Parameters.Select(t => (IParameter)new ParameterWrapper(t, this)).ToList();
            parameters.ForEach(t => t.Walk(rules));

            if (_method.HasBody)
            {
                List<IVariable> variables =
                    _method.Body.Variables.Select(t => (IVariable) new VariableWrapper(t, this)).Where(v => !v.Ignore).ToList();
                variables.ForEach(t => t.Walk(rules));
            }

        }

        public string DisplayName
        {
            get { return _method.FullName; }
        }

        public string CodeObjectType
        {
            get { return "Method"; }
        }

        public bool Ignore
        {
            get { return false; }
        }

        public int ParameterCount
        {
            get { return _method.Parameters.Count; }
        }
    }
}