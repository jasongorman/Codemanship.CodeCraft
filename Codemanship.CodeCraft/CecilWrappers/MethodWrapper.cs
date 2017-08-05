using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class MethodWrapper : CodeWrapper, IMethod
    {
        private readonly MethodDefinition _method;

        public MethodWrapper(MethodDefinition method, ICodeObject parent, IWrapperFactory wrapperFactory) : base(parent, wrapperFactory)
        {
            _method = method;
        }

        public override string Name
        {
            get
            {
                var name = _method.Name;
                name = Regex.Replace(name, "get_", "");
                name = Regex.Replace(name, "set_", "");
                return name + "()";
            }
        }

        public void Walk(Dictionary<Type, ICodeRule[]> rules)
        {
            CheckRule(rules, typeof (ICodeObject), this);
            CheckRule(rules, typeof(IMethod), this);

            var parameterDefinitions = _method.Parameters;

            List<ICodeObject> parameters = parameterDefinitions
                .Select(t => _wrapperFactory.CreateParameter(t, this))
                .Where(p => !p.Ignore)
                .ToList();

            parameters.ForEach(t => t.Walk(rules));

            if (_method.HasBody)
            {
                List<ICodeObject> variables =
                    _method.Body.Variables
                    .Select(t => _wrapperFactory.CreateVariable(t, this))
                    .Where(v => !v.Ignore)
                    .ToList();

                variables.ForEach(t => t.Walk(rules));
            }

        }

        public int PathCount
        {
            get
            {
                if (!_method.HasBody)
                    return 0;

                int paths = 1;

                paths = CountPaths(paths);

                return paths - ForEachCalls();


            }
        }

        private int CountPaths(int paths)
        {
            foreach (Instruction i in _method.Body.Instructions)
            {
                paths = CountBranches(paths, i);
                if (IsConditionalBranch(i))
                {
                    continue;
                }
                paths = CountSwitchCases(paths, i);
            }
            return paths;
        }

        private int ForEachCalls()
        {
            return 0;
        }

        private int CountSwitchCases(int paths, Instruction i)
        {
            if (i.OpCode.Code == Code.Switch)
            {
                paths += GetNumberOfSwitchTargets(i);
            }
            else //'normal' conditional branch
            {
                paths++;
            }
            return paths;
        }

        private static bool IsConditionalBranch(Instruction i)
        {
            return FlowControl.Cond_Branch != i.OpCode.FlowControl;
        }

        private int CountBranches(int paths, Instruction i)
        {
            if (FlowControl.Branch == i.OpCode.FlowControl)
            {
                if (i.Previous != null && i.Previous.OpCode.Name.StartsWith("ld", StringComparison.Ordinal))
                    paths++;
            }
            return paths;
        }

        private int GetNumberOfSwitchTargets(Instruction inst)
        {
            List<Instruction> targets = new List<Instruction>();

            FindTargets(inst, targets);
            var targetCount = CountTargets(inst, targets);
            return targetCount;
        }

        private int CountTargets(Instruction inst, List<Instruction> targets)
        {
            int targetCount = targets.Count;
            //detect 'default' branch
            if (FlowControl.Branch == inst.Next.OpCode.FlowControl)
            {
                if (inst.Next.Operand != FindFirstUnconditionalBranchTarget(targets[0]))
                {
                    targetCount++;
                }
            }
            return targetCount;
        }

        private void FindTargets(Instruction inst, List<Instruction> targets)
        {
            foreach (Instruction target in ((Instruction[]) inst.Operand))
            {
                if (!targets.Contains(target))
                {
                    targets.Add(target);
                }
            }
        }

        private static Instruction FindFirstUnconditionalBranchTarget(Instruction inst)
        {
            while (null != inst)
            {
                if (FlowControl.Branch == inst.OpCode.FlowControl)
                {
                    return ((Instruction)inst.Operand);
                }
                inst = inst.Next;
            }
            return null;
        }

        private bool IsNewPath(Instruction i)
        {
            return i.OpCode.FlowControl == FlowControl.Branch || i.OpCode.FlowControl == FlowControl.Cond_Branch;
        }

        public string CodeObjectType
        {
            get { return "Method"; }
        }

        public bool Ignore
        {
            get { return _method.IsSpecialName; }
        }

        public int ParameterCount
        {
            get { return _method.Parameters.Count; }
        }
    }
}