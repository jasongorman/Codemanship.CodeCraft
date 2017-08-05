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

        public TypeWrapper(TypeDefinition type, ICodeObject parent, IWrapperFactory wrapperFactory) : base(parent, wrapperFactory)
        {
            _type = type;
            _methods = _type.Methods
                .Select(t => _wrapperFactory.CreateMethod(t, this))
                .Where(c => !c.Ignore)
                .ToList();
            _fields = _type.Fields
                .Select(t => _wrapperFactory.CreateField(t, this))
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
            CheckRule(rules, typeof(IType), this);

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
            get { return _methods.Count(m => !m.Ignore); }
        }
    }
}