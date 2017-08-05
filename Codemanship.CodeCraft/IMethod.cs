namespace Codemanship.CodeCraft
{
    public interface IMethod : ICodeObject
    {
        int ParameterCount { get; }
        int PathCount { get; }
    }
}