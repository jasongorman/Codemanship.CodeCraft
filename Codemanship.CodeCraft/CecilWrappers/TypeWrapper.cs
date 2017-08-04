using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class TypeWrapper : CodeWrapper, IType
    {
        private readonly TypeDefinition _type;

        public TypeWrapper(TypeDefinition type, ICodeObject parent) : base(parent)
        {
            _type = type;
        }

        public override string Name
        {
            get { return _type.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof(ICodeObject), this);

            List<ICodeObject> methods =
                _type.Methods
                    .Select(t => (ICodeObject) new MethodWrapper(t, this))
                    .Where(c => !c.Ignore)
                    .ToList();
            methods.ForEach(t => t.Walk(rules));

            List<ICodeObject> fields =
                _type.Fields
                    .Select(t => (ICodeObject) new FieldWrapper(t, this))
                    .Where(c => !c.Ignore)
                    .ToList();
            fields.ForEach(t => t.Walk(rules));
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