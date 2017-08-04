using System;
using System.Collections.Generic;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public abstract class CodeWrapper
    {
        protected ICodeObject _parent;

        protected CodeWrapper(ICodeObject parent)
        {
            _parent = parent;
        }

        public abstract string Name { get; }

        public string DisplayName
        {
            get { return (_parent != null ? _parent.DisplayName + "::" : "") + Name; }
        }

        protected void CheckRule(Dictionary<Type, ICodeRule[]> rules, Type ruleType, ICodeObject source)
        {
            if (rules.ContainsKey(ruleType))
            {
                ICodeRule[] rulesForType = rules[ruleType];
                Array.ForEach(rulesForType, rule => rule.Check(source));
            }
        }
    }
}