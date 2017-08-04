using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class MethodWrapper : CodeWrapper, IMethod
    {
        private readonly MethodDefinition _method;

        public MethodWrapper(MethodDefinition method, ICodeObject parent) : base(parent)
        {
            _method = method;
        }

        public override string Name
        {
            get
            {
                var name = _method.Name;
                name = Regex.Replace(name, "get_", "");
                name = Regex.Replace(name, "set_", "");
                return name + "()";
            }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeObject), this);
            CheckRule(rules, typeof(IMethod), this);

            var parameterDefinitions = _method.Parameters;
            List<ICodeObject> parameters = parameterDefinitions.Select(t => (ICodeObject)new ParameterWrapper(t, this)).Where(p => !p.Ignore).ToList();
            parameters.ForEach(t => t.Walk(rules));

            if (_method.HasBody)
            {
                List<ICodeObject> variables =
                    _method.Body.Variables.Select(t => (ICodeObject) new VariableWrapper(t, this)).Where(v => !v.Ignore).ToList();
                variables.ForEach(t => t.Walk(rules));
            }

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