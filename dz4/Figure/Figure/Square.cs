using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    class Square : Figure
    {
        private double _side;

        public Square(double side)
        {
            this._side = side;
        }
        public override double GetArea()
        {
            return this._side * this._side;
        }

        public override double GetPerimeter()
        {
            return 4 * this._side;
        }
    }
}
