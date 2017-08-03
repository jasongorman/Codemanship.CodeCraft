namespace Codemanship.CodeCraft
{
    public interface ICodeRule
    {
        void Check(ICodeObject source);
        string Name { get; }
        string Advice { get; }
    }
}