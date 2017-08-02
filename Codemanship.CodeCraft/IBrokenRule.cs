namespace Codemanship.CodeCraft
{
    public interface IBrokenRule
    {
        ICodeObject Source { get; }
        ICodeRule Rule { get; }
    }
}