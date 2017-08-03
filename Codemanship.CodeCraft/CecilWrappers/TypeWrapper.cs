using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class TypeWrapper : CodeWrapper, IType
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
            CheckRule(rules, typeof(ICodeObject), this);

            List<IMethod> methods =
                _type.Methods
                    .Select(t => (IMethod) new MethodWrapper(t))
                    .Where(c => !c.Ignore)
                    .ToList();
            methods.ForEach(t => t.Walk(rules));

            List<IField> fields =
                _type.Fields
                    .Select(t => (IField) new FieldWrapper(t))
                    .Where(c => !c.Ignore)
                    .ToList();
            fields.ForEach(t => t.Walk(rules));
        }

        public string DisplayName
        {
            get { return _type.FullName; }
        }

        public string CodeObjectType
        {
            get { return "Type"; }
        }

        public bool Ignore
        {
            get { return _type.IsSpecialName; }
        }
    }
}