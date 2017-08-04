using System;
using System.Collections.Generic;

namespace Codemanship.CodeCraft
{
    public interface IAssembly
    {
        void Walk(Dictionary<Type, ICodeRule[]> rules);
        string Name { get; }
    }
}