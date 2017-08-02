namespace Codemanship.CodeCraft.CodeListeners
{
    public class BrokenRule : IBrokenRule
    {
        private readonly ICodeRule _rule;
        private readonly ICodeObject _source;

        public BrokenRule(ICodeRule rule, ICodeObject source)
        {
            _rule = rule;
            _source = source;
        }

        public ICodeObject Source
        {
            get { return _source; }
        }

        public ICodeRule Rule
        {
            get { return _rule; }
        }
    }
}