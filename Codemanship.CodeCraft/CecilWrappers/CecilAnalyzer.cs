using System;
using System.Collections.Generic;
using System.IO;
using Codemanship.CodeCraft.CodeListeners;
using Codemanship.CodeCraft.Rules;
using Mono.Cecil;
using Mono.Cecil.Pdb;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class CecilAnalyzer
    {
        private readonly TextWriter _output;
        private readonly List<ICodeListener> _codeListeners;
        private readonly Dictionary<Type, ICodeRule[]> _rulesByCodeObjectType;
        private readonly List<ICodeRule> _rules;
        private readonly ILoader _assemblyLoader;

        public CecilAnalyzer(TextWriter output, ILoader assemblyLoader)
        {
            _output = output;
            _assemblyLoader = assemblyLoader;

            _codeListeners = new List<ICodeListener>() {new DefaultCodeListener()};

            var identifierLengthRule = new IdentifierLengthRule(_codeListeners);
            var parameterCountRule = new ParameterCountRule(_codeListeners);
            var booleanParamsRule = new BooleanParameterRule(_codeListeners);

            _rules = new List<ICodeRule>() {identifierLengthRule, parameterCountRule, booleanParamsRule};

            _rulesByCodeObjectType = new Dictionary<Type, ICodeRule[]>
            {
                {typeof (ICodeObject), new ICodeRule[] {identifierLengthRule}},
                {typeof (IMethod), new ICodeRule[]{parameterCountRule} },
                {typeof (IParameter), new ICodeRule[]{booleanParamsRule}}
            };
        }

        public void Analyze(string[] args)
        {
            WalkAssemblies(args, _rulesByCodeObjectType);
            WriteResults(_codeListeners);
        }

        private void WriteResults(List<ICodeListener> codeListeners)
        {
            foreach (ICodeListener listener in codeListeners)
            {
                WriteResults(listener);
            }
        }

        private void WriteResults(ICodeListener codeListener)
        {
            IResultFormatter formatter = new TextResultFormatter();

            foreach (ICodeRule rule in _rules)
            {
                foreach (IBrokenRule brokenRule in codeListener.GetBrokenRules(rule))
                {
                    _output.WriteLine(formatter.Format(brokenRule));
                }
            }
        }

        private void WalkAssemblies(string[] args, Dictionary<Type, ICodeRule[]> rules)
        {
            foreach (string arg in args)
            {
                try
                {
                    if (Path.GetDirectoryName(arg) != null)
                    {
                        var assembly = _assemblyLoader.Load(arg);
                        assembly.Walk(rules);
                    }
                }
                catch (Exception e)
                {
                    _output.WriteLine(e.Message);
                }
            }
        }
    }
}