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
            TextWriter output = System.Console.Out;
            output.Write(
                @"Codemanship Code Craft 0.1
                  Written by Jason Gorman (Copyright 2017)
                  ");
            output.WriteLine("Analyzing assemblies...");
            Array.ForEach(args, arg => output.WriteLine(arg));
            new CecilAnalyzer(output, new AssemblyLoader()).Analyze(args);
        }
    }
}
