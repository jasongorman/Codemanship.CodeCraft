namespace Codemanship.CodeCraft.Tests
{
    public class RuleStub : ICodeRule
    {
        private readonly ICodeListener _listener;

        public RuleStub(ICodeListener listener)
        {
            _listener = listener;
        }

        public void Check(ICodeObject source)
        {
            _listener.RuleBroken(this, source);
        }

        public string Name
        {
            get { return "Stub Rule"; }
        }

        public string Advice
        {
            get { return "Buy low, sell high"; }
        }
    }
}