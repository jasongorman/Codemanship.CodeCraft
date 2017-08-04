using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Codemanship.CodeCraft.CecilWrappers
{
    public class CecilWrapperFactory : IWrapperFactory
    {
        public ICodeObject CreateType(TypeDefinition typeDefinition)
        {
            return (IType) new TypeWrapper(typeDefinition, null, this);
        }

        public ICodeObject CreateMethod(MethodDefinition t, ICodeObject parent)
        {
            return (ICodeObject) new MethodWrapper(t, parent, this);
        }

        public ICodeObject CreateField(FieldDefinition fieldDef, ICodeObject parent)
        {
            return (ICodeObject) new FieldWrapper(fieldDef, parent);
        }

        public ICodeObject CreateParameter(ParameterDefinition parameterDef, ICodeObject parent)
        {
            return (ICodeObject)new ParameterWrapper(parameterDef, parent);
        }

        public ICodeObject CreateVariable(VariableDefinition variableDef, ICodeObject parent)
        {
            return (ICodeObject) new VariableWrapper(variableDef, parent);
        }
    }
}