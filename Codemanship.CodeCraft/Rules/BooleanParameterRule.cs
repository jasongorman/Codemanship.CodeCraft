using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codemanship.CodeCraft.Rules
{
    public class BooleanParameterRule : ICodeRule
    {
        private readonly List<ICodeListener> _codeListeners;

        public BooleanParameterRule(List<ICodeListener> codeListeners)
        {
            _codeListeners = codeListeners;
        }

        public void Check(ICodeObject source)
        {
            IParameter parameter = (IParameter) source;
            if (parameter.IsBoolean)
            {
                _codeListeners.ForEach(x => x.RuleBroken(this, source));
            }
        }

        public string Name
        {
            get { return "Boolean Parameters"; }
        }

        public string Advice
        {
            get { return "Method parameters must not be Boolean"; }
        }
    }
}
