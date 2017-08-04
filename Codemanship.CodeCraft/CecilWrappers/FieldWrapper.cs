using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class FieldWrapper : CodeWrapper, IField
    {
        private readonly FieldDefinition _field;

        public FieldWrapper(FieldDefinition field, ICodeObject parent) : base(parent)
        {
            _field = field;
        }

        public override string Name
        {
            get { return _field.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeObject), this);
        }

        public bool Ignore
        {
            get { return _field.Name.Contains("BackingField") || _field.Name.Contains("CachedAnonymousMethodDelegate"); } 
            
        }

        public string CodeObjectType
        {
            get { return "Field"; }
        }
    }
}