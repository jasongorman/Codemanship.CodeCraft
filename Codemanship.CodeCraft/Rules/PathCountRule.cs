using System.Collections.Generic;

namespace Codemanship.CodeCraft.Rules
{
    public class PathCountRule : ICodeRule
    {
        private readonly List<ICodeListener> _listeners;

        public PathCountRule(List<ICodeListener> listeners)
        {
            _listeners = listeners;
        }

        public void Check(ICodeObject source)
        {
            IMethod method = (IMethod) source;

            if (method.PathCount > 3)
            {
                _listeners.ForEach(l => l.RuleBroken(this, source));
            }
        }

        public string Name
        {
            get { return "Path Count"; }
        }

        public string Advice
        {
            get { return "Methods must contain no more than 3 paths (i.e., 2 branches)"; }
        }
    }
}