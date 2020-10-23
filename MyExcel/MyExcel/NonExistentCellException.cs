using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel
{
    class NonExistentCellException : Exception
    {
        public NonExistentCellException() : base("Non-existent cell in expression") { }
    }
}
