using System.Collections.Generic;

namespace Codemanship.CodeCraft.Rules
{
    public class MethodCountRule : ICodeRule
    {
        private readonly List<ICodeListener> _codeListeners;

        public MethodCountRule(List<ICodeListener> codeListeners)
        {
            _codeListeners = codeListeners;
        }

        public void Check(ICodeObject source)
        {
            var type = (IType) source;
            if (type.MethodCount > 6)
            {
                _codeListeners.ForEach(l => l.RuleBroken(this, source));
            }
        }

        public string Name
        {
            get { return "Method Count"; }
        }

        public string Advice
        {
            get { return "Classes must have no more than 10 methods"; }
        }
    }
}