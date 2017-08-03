using System;
using System.Collections.Generic;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class CodeWrapper
    {
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