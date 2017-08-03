using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public class ClassNameWithTooManyParameters
    {
        private int _fieldNameTooManyChars;

        public ClassNameWithTooManyParameters()
        {
            _fieldNameTooManyChars = 0;
        }

        public void MethodNameTooManyChars(int parameterNameTooManyChars)
        {
            int variableNameTooManyChars = 0;
        }

        public void TooManyParams(int i, int j, int k, int z)
        {
        }

        public void BooleanParam(bool x)
        {
            
        }

        public int PropertyNameTooManyCharacters { get; set; }
    }
}
