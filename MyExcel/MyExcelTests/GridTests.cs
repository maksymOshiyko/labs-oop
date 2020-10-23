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
    public class GridTests
    {
        [TestMethod()]
        public void setGridExceptionTest()
        {
            bool error = false;
            try
            {
                int cols = 5;
                int rows = -1;
                Grid.setGrid(cols, rows);
            }
            catch(ArgumentException)
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