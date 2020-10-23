using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void EvaluateTest()
        {
            {
                string actual = "MMAX(1,2,MMIN(4,8),DEC(9)) + 1^2";
                string expected = "9";
                Assert.AreEqual(expected, Calculator.Evaluate(actual));
            }

            {
                string actual = "DEC(5 + 4 / 2)";
                string expected = "6";
                Assert.AreEqual(expected, Calculator.Evaluate(actual));
            }

            {
                string actual = "-(-1)";
                string expected = "1";
                Assert.AreEqual(expected, Calculator.Evaluate(actual));
            }

            {
                string actual = "2^(2^3)";
                string expected = "256";
                Assert.AreEqual(expected, Calculator.Evaluate(actual));
            }
        }

        [TestMethod()]
        public void EvaluateExceptionTest()
        {
            bool error = false;

            try
            {
                string actual = "5 + 2 / 0";
                string expected = Calculator.Evaluate(actual);
            }
            catch (DivideByZeroException)
            {
                error = true;
            }

            if (!error)
            {
                Assert.Fail();
            }
        }

    }
}