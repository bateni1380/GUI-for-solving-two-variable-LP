using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphOfFunction
{
    class MyChar
    {  
        public static bool IsBinaryOperation(char c)
        {
            if(c == '+' || c == '-' || c == '*' || c == '/' || c == '^') return true;
            return false;
        }
    }
}
