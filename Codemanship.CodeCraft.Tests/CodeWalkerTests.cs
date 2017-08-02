using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codemanship.CodeCraft.CecilWrappers;
using Codemanship.CodeCraft.Rules;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Moq;
using NUnit.Framework;

namespace Codemanship.CodeCraft.Tests
{
    [TestFixture]
    public class CodeWalkerTests
    {
        [Test]
        public void AppliesCodeObjectRuleToEveryCodeObject()
        {
            AssemblyDefinition assembly = AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("XXXXXXXXXXXXXXXXXXXXX", new Version(1,0,0)), "XXX", ModuleKind.Dll );
            TypeDefinition type = new TypeDefinition("XXXXXXXXXXXXXXXXXXXXX", "YYYYYYYYYYYYYYYYYYYYY", TypeAttributes.Class);
            assembly.MainModule.Types.Add(type);
            FieldDefinition field = new FieldDefinition("_xxxxxxxxxxxxxxxxxxxx", FieldAttributes.Private, ModuleMother.TypeSystem.String);
            type.Fields.Add(field);
            MethodDefinition method = new MethodDefinition("Xxxxxxxxxxxxxxxxxxxxx", MethodAttributes.Public, ModuleMother.TypeSystem.Void);
            type.Methods.Add(method);
            ParameterDefinition parameter = new ParameterDefinition("xxxxxxxxxxxxxxxxxxxxx", ParameterAttributes.In, ModuleMother.TypeSystem.Int32);
            method.Parameters.Add(parameter);
            VariableDefinition variable = new VariableDefinition("yyyyyyyyyyyyyyyyyyyyy", ModuleMother.TypeSystem.Int32);
            method.Body.Variables.Add(variable);

            ICodeObject wrappedAssembly = new AssemblyWrapper(assembly);

            var mockListener = new Mock<ICodeListener>();
            var codeListeners = new List<ICodeListener>(){mockListener.Object};
            Dictionary<Type, ICodeRule[]> rules = new Dictionary<Type, ICodeRule[]>(){{typeof(ICodeObject), new ICodeRule[]{new IdentifierLengthRule(codeListeners)}}};
            wrappedAssembly.Walk(rules);
            mockListener.Verify(x => x.RuleBroken(It.IsAny<ICodeRule>(), It.IsAny<ICodeObject>()), Times.Exactly(6));
        }
    }
}
