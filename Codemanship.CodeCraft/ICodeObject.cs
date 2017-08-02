using System;
using System.Collections.Generic;

namespace Codemanship.CodeCraft
{
    public interface ICodeObject
    {
        string Name { get; }
        void Walk(Dictionary<Type, ICodeRule[]> rules);
    }
}