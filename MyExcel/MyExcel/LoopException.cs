using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel
{
    class LoopException : Exception
    {
        public LoopException() : base("You have a loop in your expression") { }
    }
}
