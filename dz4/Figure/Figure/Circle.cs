using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    class Circle : Figure
    {
        private double _radius;

        public Circle(double radius)
        {
            this._radius = radius;
        }

        public override double GetPerimeter()
        {
            return this._radius * Math.PI * 2;
        }

        public override double GetArea()
        {
            return Math.PI * this._radius * this._radius;
        }
    }
}
