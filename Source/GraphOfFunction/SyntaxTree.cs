using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphOfFunction.SyntaxNodes;


namespace GraphOfFunction
{
    class SyntaxTree
    {
        static List<string> listOperations = new List<string>(new string[] { "+", "-", "*", "/", "--", "^", "sin", "cos", "tan", "ctg", "log", "abs"});
        static List<string> listBinaryOperations = new List<string>(new string[] { "+", "-", "*", "/", "^"});
        static List<string> listUnaryOperations = new List<string>(new string[] {"--" });
        static List<string> listFunctions = new List<string>(new string[] { "sin", "cos", "tan", "ctg", "log", "abs" });

        private ISyntaxNode root;

        public SyntaxTree(string function)
        {
            List<ISyntaxNode> listNode = BuildListSyntaxNode(function);
            root = BuildSyntaxTree(listNode);
        }

        public ISyntaxNode ReadVar(string function, int first, out int index)
        {
            string var = "";
            for (int i = first; 
                i < function.Length && (Char.IsNumber(function[i]) || function[i] == '.') ; i++)
            {
                if (function[i] == '.') var += ',';
                else var += function[i];
            }
            index = first + var.Length - 1;
            return new Var(Convert.ToDouble(var));    
            
        }

        public ISyntaxNode ReadOperation(string function, int first, out int index)
        {
            index = first;
            if (function[first] == '+') return new Add();
            if (function[first] == '-') return new Sub();
            if (function[first] == '*') return new Mul();
            if (function[first] == '/') return new Div();
            if (function[first] == '^') return new Pow();
            return null;
        }

        public ISyntaxNode ReadFunction(string function, int first, out int index)
        {            
            index = first;
            if (function.Substring(first, 3) == "sin")
            {
                index = first + 2;
                return new Sin();
            }

            if (function.Substring(first, 3) == "cos")
            {
                index = first + 2;
                return new Cos();
            }

            if (function.Substring(first, 3) == "tan")
            {
                index = first + 2;
                return new Tan();
            }

            if (function.Substring(first, 3) == "ctg")
            {
                index = first + 2;
                return new Ctg();
            }

            if (function.Substring(first, 3) == "log")
            {
                index = first + 2;
                return new Log();
            }

            if (function.Substring(first, 3) == "abs")
            {
                index = first + 2;
                return new Abs();
            }

            return null;
        }

        private int CompareOperations(ISyntaxNode a, ISyntaxNode b, int aCountBracket, int bCountBracket)
        {
            if (aCountBracket < bCountBracket) return 1;
            if (aCountBracket > bCountBracket) return -1;
            if (listOperations.IndexOf(a.ToStringValue()) < listOperations.IndexOf(b.ToStringValue())) return 1;
            if (listOperations.IndexOf(a.ToStringValue()) > listOperations.IndexOf(b.ToStringValue())) return -1;
            return 0;
        }

        private ISyntaxNode FindMinPrioritiOperation(List<ISyntaxNode> listNode, out int position)
        {
            ISyntaxNode min = null;
            int countMinOperationBrachet = 0;
            int countBracketOpening = 0;
            int countBracketClosing = 0;
            position = 0;
            for (int i = 0; i < listNode.Count; i++)
            {
                if (listNode[i].ToStringValue() == "(") countBracketOpening++;
                if (listNode[i].ToStringValue() == ")") countBracketClosing++;
                if (listOperations.IndexOf(listNode[i].ToStringValue()) != -1)
                {
                    if (min == null)
                    {
                        min = listNode[i];
                        position = i;
                        countMinOperationBrachet = countBracketOpening - countBracketClosing;
                        continue;
                    }
                    
                    if (CompareOperations(min, listNode[i], countMinOperationBrachet, countBracketOpening - countBracketClosing) == -1)
                    {
                        min = listNode[i];
                        position = i;
                        countMinOperationBrachet = countBracketOpening - countBracketClosing;
                    }
                }
            }
            return min;
        }

        public void DeleteExcessiveBrackets(List<ISyntaxNode> listNode)
        {
            if (listNode.Count == 1) return;
            int countMinBracket = listNode.Count;
            int countBracketOpening = 0;
            int countBracketClosing = 0;
            for (int i = 0; i < listNode.Count; i++)
            {
                if (listNode[i].ToStringValue() != "(" && listNode[i].ToStringValue() != ")")
                {
                    countBracketOpening = 0;
                    countBracketClosing = 0;
                    for (int k = i + 1; k < listNode.Count; k++)
                    {
                        if (listNode[k].ToStringValue() == "(") countBracketOpening++;
                        if (listNode[k].ToStringValue() == ")") countBracketClosing++;
                    }
                    int countBracket = Math.Abs(countBracketOpening - countBracketClosing);
                    if (countBracket < countMinBracket) countMinBracket = countBracket;
                }
            }
            listNode.RemoveRange(0, countMinBracket);
            listNode.RemoveRange(listNode.Count - countMinBracket, countMinBracket);
        }

        private ISyntaxNode BuildSyntaxTree(List<ISyntaxNode> listNode)
        {
            DeleteExcessiveBrackets(listNode);
            if (listNode.Count == 1)  return listNode[0];

            int position;
            ISyntaxNode  min = FindMinPrioritiOperation(listNode, out position);
            if (listBinaryOperations.IndexOf(min.ToStringValue()) != -1)
            {
                BinaryOperation operation = min as BinaryOperation;
                operation.SetA(BuildSyntaxTree(listNode.GetRange(0, position)));
                operation.SetB(BuildSyntaxTree(listNode.GetRange(position + 1,listNode.Count - (position +1))));
            }
            if (listUnaryOperations.IndexOf(min.ToStringValue()) != -1)
            {
                UnaryOperation operation = min as UnaryOperation;
                operation.SetA(BuildSyntaxTree(listNode.GetRange(position + 1, listNode.Count - (position + 1))));
            }
            if (listFunctions.IndexOf(min.ToStringValue()) != -1)
            {
                Function function = min as Function;
                function.SetX(BuildSyntaxTree(listNode.GetRange(position + 1, listNode.Count - (position + 1))));
            }
            return min;
        }

        private List<ISyntaxNode> BuildListSyntaxNode(string function)
        {
            List<ISyntaxNode> listNode = new List<ISyntaxNode>();
            for (int i = 0; i < function.Length; i++)
            {
                if (function[i] == 'p')
                {
                    ISyntaxNode pi = new Var(Math.PI);
                    listNode.Add(pi);
                    i++;
                }

                if (function[i] == 'e')
                {
                    ISyntaxNode e = new Var(Math.E);
                    listNode.Add(e);
                }

                if (function[i] == 'x')
                {
                    ISyntaxNode x = new X();
                    listNode.Add(x);
                }
                if (Char.IsNumber(function[i]))
                {
                    ISyntaxNode var = ReadVar(function, i, out i);
                    listNode.Add(var);
                }
                if (function[i] == '-')
                {
                    if (i == 0 || function[i - 1] == '(' || function[i + 1] == '(')
                    {
                        ISyntaxNode op = new Neg();
                        listNode.Add(op);
                        continue;
                    }
                }
                if (MyChar.IsBinaryOperation(function[i]))
                {
                    ISyntaxNode op = ReadOperation(function, i, out i);
                    listNode.Add(op);
                }
                if (function[i] == '(')
                {
                    ISyntaxNode op = new BracketOpening();
                    listNode.Add(op);
                }
                if (function[i] == ')')
                {
                    ISyntaxNode op = new BracketClosing();
                    listNode.Add(op);
                }
                if (function[i] == 's' || function[i] == 'c' || function[i] == 't' ||
                    function[i] == 'l' || function[i] == 'a')
                {
                    ISyntaxNode func = ReadFunction(function, i, out i);
                    listNode.Add(func);
                }
            }
            return listNode;
        }

        public double Calculate(double x, out bool isDomainOfFunction)
        {
            if (root.IsDomainOfFunction(x))
            {
                isDomainOfFunction = true;
                return root.GetResult(x);
            }
            isDomainOfFunction = false;
            return 0;
        }

    }
}
