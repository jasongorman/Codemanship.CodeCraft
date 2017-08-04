using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class TypeWrapper : CodeWrapper, IType
    {
        private readonly TypeDefinition _type;
        private readonly List<ICodeObject> _methods;
        private readonly List<ICodeObject> _fields;

        public TypeWrapper(TypeDefinition type, ICodeObject parent) : base(parent)
        {
            _type = type;
            _methods = _type.Methods
                .Select(t => (ICodeObject) new MethodWrapper(t, this))
                .Where(c => !c.Ignore)
                .ToList();
            _fields = _type.Fields
                .Select(t => (ICodeObject) new FieldWrapper(t, this))
                .Where(c => !c.Ignore)
                .ToList();
        }

        public override string Name
        {
            get { return _type.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof(ICodeObject), this);

            _methods.ForEach(t => t.Walk(rules));
            _fields.ForEach(t => t.Walk(rules));
        }

        public string CodeObjectType
        {
            get { return "Type"; }
        }

        public bool Ignore
        {
            get { return _type.IsSpecialName; }
        }

        public int MethodCount
        {
            get { return _methods.Count; }
        }
    }
}