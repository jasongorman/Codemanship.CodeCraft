using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codemanship.CodeCraft.Rules
{
    public class ParameterCountRule : ICodeRule
    {
        private readonly List<ICodeListener> _listeners;

        public ParameterCountRule(List<ICodeListener> listeners)
        {
            _listeners = listeners;
        }

        public void Check(ICodeObject source)
        {
            IMethod method = (IMethod) source;

            if (method.ParameterCount > 3)
            {
                _listeners.ForEach(x => x.RuleBroken(this, source));
            }
        }

        public string Name
        {
            get { return "Parameter Count"; }
        }

        public string Advice
        {
            get { return "Methods must not have > 3 parameters"; }
        }
    }
}
