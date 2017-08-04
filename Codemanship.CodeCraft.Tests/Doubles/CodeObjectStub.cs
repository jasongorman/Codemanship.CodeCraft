using System;
using System.Collections.Generic;

namespace Codemanship.CodeCraft.Tests.Doubles
{
    public class CodeObjectStub : ICodeObject
    {
        public string Name { get; set; }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            
        }

        public string DisplayName
        {
            get { return "FullName.Foo"; }
        }

        public string CodeObjectType
        {
            get { return "Method"; }
        }

        public bool Ignore
        {
            get { return false; }
        }

        public CodeObjectStub(string name)
        {
            Name = name;
        }
    }
}