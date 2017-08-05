using System;
using System.Collections.Generic;

namespace Codemanship.CodeCraft.Tests.Doubles
{
    public class MethodStub : IMethod
    {
        private readonly int _pathCount;
        private readonly int _parameterCount;

        public MethodStub(int pathCount, int parameterCount)
        {
            _pathCount = pathCount;
            _parameterCount = parameterCount;
        }

        public string Name
        {
            get { return ""; }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            
        }

        public string DisplayName
        {
            get { return ""; }
        }

        public string CodeObjectType
        {
            get { return ""; }
        }

        public bool Ignore
        {
            get { return false; }
        }

        public int ParameterCount
        {
            get { return _parameterCount; }
        }

        public int PathCount
        {
            get { return _pathCount; }
        }
    }
}