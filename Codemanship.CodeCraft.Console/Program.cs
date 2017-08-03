using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CecilWrappers;
using Codemanship.CodeCraft.CodeListeners;
using Codemanship.CodeCraft.Rules;
using Mono.Cecil;

namespace Codemanship.CodeCraft.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new CecilAnalyzer(System.Console.Out).Analyze(args);
        }
    }
}
