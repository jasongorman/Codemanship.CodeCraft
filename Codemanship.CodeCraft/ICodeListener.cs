using System.Collections.Generic;

namespace Codemanship.CodeCraft
{
    public interface ICodeListener
    {
        void RuleBroken(ICodeRule rule, ICodeObject source);
        IEnumerable<IBrokenRule> GetBrokenRules(ICodeRule rule);
    }
}