using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    class Rectangle : Figure
    {
        private double _firstSide;
        private double _secondSide;

        public Rectangle(double firstSide, double secondSide)
        {
            this._firstSide = firstSide;
            this._secondSide = secondSide;
        }

        public override double GetArea()
        {
            return this._firstSide * this._secondSide;
        }

        public override double GetPerimeter()
        {
            return 2 * (this._firstSide + this._secondSide);
        }
    }
}
