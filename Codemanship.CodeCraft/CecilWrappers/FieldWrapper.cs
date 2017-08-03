using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class FieldWrapper : CodeWrapper, IField
    {
        private readonly FieldDefinition _field;

        public FieldWrapper(FieldDefinition field)
        {
            _field = field;
        }

        public string Name
        {
            get { return _field.Name; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeObject), this);
        }

        public bool Ignore
        {
            get { return _field.Name.Contains("BackingField"); } 
            
        }

        public string FullName
        {
            get { return _field.FullName.Split(' ')[1]; }
        }

        public string CodeObjectType
        {
            get { return "Field"; }
        }
    }
}