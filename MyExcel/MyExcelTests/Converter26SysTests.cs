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
    public class Converter26SysTests
    {
        [TestMethod()]
        public void To26SysTest()
        {
            {
                int actual = 148;
                string expected = "ES";
                Assert.AreEqual(expected, Converter26Sys.To26Sys(actual));
            }

            {
                int actual = 255;
                string expected = "IV";
                Assert.AreEqual(expected, Converter26Sys.To26Sys(actual));
            }

            {
                int actual = 1;
                string expected = "B";
                Assert.AreEqual(expected, Converter26Sys.To26Sys(actual));
            }

            {
                int actual = 633;
                string expected = "XJ";
                Assert.AreEqual(expected, Converter26Sys.To26Sys(actual));
            }
        }

        [TestMethod()]
        public void From26SysTest()
        {
            {
                string actual = "J";
                Index expected = new Index { column = 9, row = 0 };
                Assert.AreEqual(expected, Converter26Sys.From26Sys(actual));
            }

            {
                string actual = "AA5";
                Index expected = new Index { column = 26, row = 5 };
                Assert.AreEqual(expected, Converter26Sys.From26Sys(actual));
            }

            {
                string actual = "XZ12";
                Index expected = new Index { column = 649, row = 12 };
                Assert.AreEqual(expected, Converter26Sys.From26Sys(actual));
            }

            {
                string actual = "AAA5";
                Index expected = new Index { column = 702, row = 5 };
                Assert.AreEqual(expected, Converter26Sys.From26Sys(actual));
            }
        }
    }
}