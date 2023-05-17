using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphOfFunction.SyntaxNodes;

namespace GraphOfFunction
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SyntaxTree syntaxTree = new SyntaxTree("-(x+(-2))-2*(9-3)");

            //Console.WriteLine(" result = " + syntaxTree.Calculate(4));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMy());
        }
    }
}
