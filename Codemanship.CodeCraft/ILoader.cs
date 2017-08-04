namespace Codemanship.CodeCraft
{
    public interface ILoader
    {
        IAssembly Load(string assemblyPath);
    }
}