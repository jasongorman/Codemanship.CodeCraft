using System.Collections.Generic;

namespace Codemanship.CodeCraft.Rules
{
    public class IdentifierLengthRule : ICodeRule
    {
        private readonly List<ICodeListener> _codeListeners;

        public IdentifierLengthRule(List<ICodeListener> codeListeners)
        {
            _codeListeners = codeListeners;
        }

        public void Check(ICodeObject source)
        {
            if(source.Name.Length > 20)
                _codeListeners.ForEach(x => x.RuleBroken(this, source));

        }
    }
}