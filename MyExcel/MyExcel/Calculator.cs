using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace MyExcel
{
    public static class Calculator
    {
        public static string Evaluate(string expression)
        {
            expression = ConvertReferences(expression);

            var lexer = new LabCalculatorLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new LabCalculatorParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new LabCalculatorVisitor();

            string result = Convert.ToString(visitor.Visit(tree));

            if (result == "∞" || result == "не число")
            {
                throw new DivideByZeroException();
            }

            return result;
        }

        private static string ConvertReferences(string expression)
        {
            Regex regex = new Regex("[A-Z]+[0-9]+");
            MatchEvaluator evaluator = new MatchEvaluator(ReferenceToValue);
            string newExpr = regex.Replace(expression, evaluator);
            return newExpr;
        }

        private static string ReferenceToValue(Match match)
        {
            if (Grid.dictionary.ContainsKey(match.Value))
            {
                if (Grid.dictionary[match.Value] == "")
                {
                    return "0";
                }
                else
                {
                    return Grid.dictionary[match.Value];
                }
            }
            throw new NonExistentCellException();
        }
    }
}
