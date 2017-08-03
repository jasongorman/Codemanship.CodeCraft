using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class ParameterWrapper : CodeWrapper, IParameter
    {
        private readonly ParameterDefinition _parameter;
        private readonly IMethod _method;

        public ParameterWrapper(ParameterDefinition parameter, IMethod method)
        {
            _parameter = parameter;
            _method = method;
        }

        public string Name
        {
            get { return _parameter.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeRule), this);
            CheckRule(rules, typeof (IParameter), this);
        }

        public string FullName
        {
            get { return _method.FullName + "::" + _parameter.Name; }
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