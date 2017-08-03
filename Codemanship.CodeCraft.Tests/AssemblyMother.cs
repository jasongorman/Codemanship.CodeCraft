using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Codemanship.CodeCraft.Tests
{
    public class AssemblyMother
    {
        public static AssemblyDefinition BuildTestAssembly()
        {
            AssemblyDefinition assembly =
                AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("X", new Version(1, 0, 0)), "X", ModuleKind.Dll);
            TypeDefinition type = new TypeDefinition("XXXXXXXXXXXXXXXXXXXXX", "YYYYYYYYYYYYYYYYYYYYY", TypeAttributes.Class);
            assembly.MainModule.Types.Add(type);
            FieldDefinition field = new FieldDefinition("_xxxxxxxxxxxxxxxxxxxx", FieldAttributes.Private,
                ModuleMother.TypeSystem.String);
            type.Fields.Add(field);
            MethodDefinition method = new MethodDefinition("Xxxxxxxxxxxxxxxxxxxxx", MethodAttributes.Public,
                ModuleMother.TypeSystem.Void);
            type.Methods.Add(method);
            ParameterDefinition parameter = new ParameterDefinition("xxxxxxxxxxxxxxxxxxxxx", ParameterAttributes.In,
                ModuleMother.TypeSystem.Int32);
            method.Parameters.Add(parameter);
            VariableDefinition variable = new VariableDefinition("yyyyyyyyyyyyyyyyyyyyy", ModuleMother.TypeSystem.Int32);
            method.Body.Variables.Add(variable);
            return assembly;
        }
    }
}