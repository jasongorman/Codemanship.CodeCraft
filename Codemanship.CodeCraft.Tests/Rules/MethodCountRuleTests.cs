using System;
using System.Collections.Generic;
using Codemanship.CodeCraft.CecilWrappers;
using Codemanship.CodeCraft.Rules;
using Mono.Cecil;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.Rules
{
    [TestFixture]
    public class MethodCountRuleTests
    {
        [Test]
        public void TypeWithMoreThanTenMethodsBreaksRule()
        {
            CheckIfRuleBroken(11, Times.Once);
        }

        [Test]
        public void TypeWithNoMoreThanTenMethodsDoesNotBreakRule()
        {
            CheckIfRuleBroken(10, Times.Never);
        }

        private void CheckIfRuleBroken(int numberOfMethods, Func<Times> expectedInvocations)
        {
            var listener = new Mock<ICodeListener>();
            ICodeRule rule = new MethodCountRule(new List<ICodeListener> {listener.Object});
            var type = BuildClassWithMethods(numberOfMethods);
            ICodeObject source = new TypeWrapper(type, null);
            rule.Check(source);
            listener.Verify(x => x.RuleBroken(rule, source), expectedInvocations);
        }

        private TypeDefinition BuildClassWithMethods(int numberOfMethods)
        {
            var assembly =
                AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("XXX", new Version(1, 0, 0)), "XXX",
                    ModuleKind.Dll);
            var type = new TypeDefinition("XXX", "Foo", TypeAttributes.Class);
            assembly.MainModule.Types.Add(type);
            for (var i = 0; i < numberOfMethods; i++)
            {
                var method = new MethodDefinition("Bar" + i, MethodAttributes.Public, type.Module.TypeSystem.Void);
                type.Methods.Add(method);
            }
            return type;
        }
    }
}
