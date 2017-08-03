using System.Collections.Generic;

namespace Codemanship.CodeCraft.CodeListeners
{
    public class DefaultCodeListener : ICodeListener
    {
        private readonly Dictionary<ICodeRule, List<IBrokenRule>> _brokenRulesByRule 
            = new Dictionary<ICodeRule, List<IBrokenRule>>();

        public void RuleBroken(ICodeRule rule, ICodeObject source)
        {
            if (!_brokenRulesByRule.ContainsKey(rule))
            {
                _brokenRulesByRule.Add(rule, new List<IBrokenRule>());
            }
            _brokenRulesByRule[rule].Add(new BrokenRule(rule, source));
        }

        public IEnumerable<IBrokenRule> GetBrokenRules(ICodeRule rule) 
        {
            if(_brokenRulesByRule.ContainsKey(rule))
                return _brokenRulesByRule[rule];
            return new List<IBrokenRule>();
        }
    }
}