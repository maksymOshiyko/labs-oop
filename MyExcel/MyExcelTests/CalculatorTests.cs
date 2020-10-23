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
            string actual = "MMAX(1,2,MMIN(4,8),DEC(9)) + 1^2";
            string expected = "9";
            Assert.AreEqual(expected, Calculator.Evaluate(actual));
        }
    }
}