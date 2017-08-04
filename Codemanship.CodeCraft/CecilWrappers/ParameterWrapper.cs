using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class ParameterWrapper : CodeWrapper, IParameter
    {
        private readonly ParameterDefinition _parameter;

        public ParameterWrapper(ParameterDefinition parameter, ICodeObject parent): base(parent)
        {
            _parameter = parameter;
        }

        public override string Name
        {
            get { return _parameter.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeRule), this);
            CheckRule(rules, typeof (IParameter), this);
        }

        public string CodeObjectType
        {
            get { return "Parameter"; }
        }

        public bool Ignore
        {
            get { return false; }
        }

        public bool IsBoolean
        {
            get
            {
                TypeReference paramType = _parameter.ParameterType;
                TypeReference boolean = paramType.Module.TypeSystem.Boolean;
                return paramType == boolean;
            }
        }
    }
}