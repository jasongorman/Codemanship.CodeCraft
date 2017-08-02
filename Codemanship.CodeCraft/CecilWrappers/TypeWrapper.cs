using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class TypeWrapper : IType
    {
        private readonly TypeDefinition _type;

        public TypeWrapper(TypeDefinition type)
        {
            _type = type;
        }

        public string Name
        {
            get { return _type.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            ICodeRule[] codeObjectRules = rules[typeof(ICodeObject)];
            Array.ForEach(codeObjectRules, rule => rule.Check(this));

            List<IMethod> methods = _type.Methods.Select(t => (IMethod)new MethodWrapper(t)).ToList();
            methods.ForEach(t => t.Walk(rules));

            List<IField> fields = _type.Fields.Select(t => (IField)new FieldWrapper(t)).ToList();
            fields.ForEach(t => t.Walk(rules));
        }
    }
}