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

        public void MethodWithTooManyBranches()
        {
            int x = 0;
            if (x > -1)
            {
                if(x + 2 == 2)
                {
                    if (x - 1 == -1)
                    {
                        if (x * x == x)
                        {
                            x = 1;
                        }
                    }
                }
            }
        }

        public void ForEachOnListCountsAsBranch()
        {
            List<string> strings = new List<string>(){"x","y","z"};
            strings.ForEach(s => s.ToUpper());
            strings.ForEach(s => s.Reverse());
            strings.ForEach(s => s.ToCharArray());
        }

        public void DoesThisNewMethodShowUpInBrokenRules()
        {
            
        }

        public int PropertyNameTooManyCharacters { get; set; }
    }
}
