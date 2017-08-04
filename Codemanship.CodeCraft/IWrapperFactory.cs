using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Codemanship.CodeCraft
{
    public interface IWrapperFactory
    {
        ICodeObject CreateType(TypeDefinition typeDefinition);
        ICodeObject CreateMethod(MethodDefinition t, ICodeObject parent);
        ICodeObject CreateField(FieldDefinition fieldDef, ICodeObject parent);
        ICodeObject CreateParameter(ParameterDefinition parameterDef, ICodeObject parent);
        ICodeObject CreateVariable(VariableDefinition variableDef, ICodeObject parent);
    }
}