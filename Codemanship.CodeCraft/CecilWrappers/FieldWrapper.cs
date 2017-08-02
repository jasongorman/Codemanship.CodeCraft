using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class FieldWrapper : IField
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
            ICodeRule[] codeObjectRules = rules[typeof(ICodeObject)];
            Array.ForEach(codeObjectRules, rule => rule.Check(this));
        }
    }
}