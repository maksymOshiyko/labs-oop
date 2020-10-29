using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
    {
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();

        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            //видобути значення змінної з таблиці
            if (tableIdentifier.TryGetValue(result.ToString(), out value))
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            string exp = context.GetText();
            if(exp[0] == '-')
            {
                return -Visit(context.expression());
            }
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(LabCalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            Debug.WriteLine($"{left} ^ {right}");

            return Math.Pow(left, right);
        }
        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine($"{left} + {right}");
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine($"{left} - {right}");
                return left - right;
            }
        }

        public override double VisitIncDecExpr(LabCalculatorParser.IncDecExprContext context)
        {
            var value = WalkLeft(context);

            if (context.operatorToken.Type == LabCalculatorLexer.DEC)
            {
                return --value;
            }
            else //LabCalculatorLexer.INC
            {
                return ++value;
            }
        }

        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return left / right;
            }
        }

        public override double VisitMminMmaxExpr(LabCalculatorParser.MminMmaxExprContext context)
        {
            var exp = context.GetText();
            List<string> parts = FindParts(exp);
           
            List<double> numbers = new List<double>();

            foreach (var part in parts)
            {
                double number = Convert.ToDouble(Calculator.Evaluate(part));
                numbers.Add(number);
            }

            double result;

            if (context.operatorToken.Type == LabCalculatorLexer.MMIN)
            {
                result = numbers.Min();
            }
            else //LabCalculatorLexer.MMAX
            {
                result = numbers.Max();

            }

            return result;
        }

        private List<int> FindDelimiterIndexes(string exp)
        {
            string str = exp.Substring(0, exp.Length);
            var list = new List<int>();

            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == ',')
                {
                    list.Add(i);
                }
            }

            return list;
        }

        private List<string> FindParts(string exp)
        {
            exp = exp.Substring(exp.IndexOf('(') + 1, exp.LastIndexOf(')') - exp.IndexOf('(') - 1);
            var indexesOfDelimiter = FindDelimiterIndexes(exp);

            var parts = new List<string>();

            if (indexesOfDelimiter.Count == 0)
            {
                parts.Add(exp);
                return parts;
            }

            for (int i = 0; i <= indexesOfDelimiter.Count; i++)
            {
                int indexOfDelimiter = indexesOfDelimiter[i == indexesOfDelimiter.Count ? 0 : i];
                string part;
                if (i == indexesOfDelimiter.Count)
                {
                    
                    part = exp.Substring(0, exp.Length);
                }
                else
                {
                    part = exp.Substring(0, indexOfDelimiter);
                }
                if (part.Count(x => x == '(') == part.Count(x => x == ')'))
                {
                    parts.Add(part);

                    if (i != indexesOfDelimiter.Count)
                    {
                        int lastLength = exp.Length;
                        exp = exp.Substring(indexOfDelimiter + 1, exp.Length - 1 - indexOfDelimiter);
                        for (int j = 0; j < indexesOfDelimiter.Count; j++)
                        {
                            indexesOfDelimiter[j] -= (lastLength - exp.Length);
                        }
                    }
                }
            }

            return parts;
        }

        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }
        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }
    }
}