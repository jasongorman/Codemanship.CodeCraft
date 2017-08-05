using System;
using Codemanship.CodeCraft.CecilWrappers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests.CecilWrappers
{
    [TestFixture]
    public class MethodWrapperTests
    {
        [Test]
        public void MethodIsNamedCodeObject()
        {
            var method = new MethodDefinition("DoFoo", MethodAttributes.Public, ModuleMother.TypeSystem.Void);
            ICodeObject wrappedMethod = new MethodWrapper(method, null, new CecilWrapperFactory());
            Assert.That(wrappedMethod.Name, Is.EqualTo("DoFoo()"));
        }

        [Test]
        public void MethodWithNoBranchesHasSinglePath()
        {
            CheckPathCount(Instruction.Create(OpCodes.Ldstr, "Hello!"), 1);
        }

        [Test]
        public void MethodWithOneBranchHasTwoPaths()
        {
            CheckPathCount(Instruction.Create(OpCodes.Br, Instruction.Create(OpCodes.Ldstr, "")), 2);
        }

        private void CheckPathCount(Instruction instruction, int expectedPathCount)
        {
            var methodDef = BuildMethodWithInstruction(instruction);
            IMethod method = new MethodWrapper(methodDef, null, new CecilWrapperFactory());
            Assert.That(method.PathCount, Is.EqualTo(expectedPathCount));
        }

        private MethodDefinition BuildMethodWithInstruction(Instruction instruction)
        {
            var module = BuildModule();
            var methodDef = new MethodDefinition("Foo", MethodAttributes.Public, module.TypeSystem.Void);
            methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Ldstr, "")); // default first instruction
            methodDef.Body.Instructions.Insert(1, instruction);
            return methodDef;
        }

        private ModuleDefinition BuildModule()
        {
            var assembly =
                AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("XXX", new Version(1, 0, 0)), "XXX",
                    ModuleKind.Dll);
            var module = assembly.MainModule;
            return module;
        }
    }
}
