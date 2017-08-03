namespace Codemanship.CodeCraft
{
    public class TextResultFormatter : IResultFormatter
    {
        public string Format(IBrokenRule brokenRule)
        {
            ICodeRule rule = brokenRule.Rule;
            ICodeObject source = brokenRule.Source;

            return "RULE: " + rule.Name + " - " + source.CodeObjectType + ": " + source.DisplayName
                   + "\nADVICE: " + rule.Advice + "\n";
        }
    }
}