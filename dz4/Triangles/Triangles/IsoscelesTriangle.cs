using System;
using System.Collections.Generic;
using System.Text;

namespace Triangles
{
    class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double firstSide, double secondSide, double angle)
            : base(firstSide, firstSide, angle) { }

        public override double GetArea()
        {
            return (this._firstSide * this._secondSide * Math.Sin(this.FirstAngle * Math.PI / 180)) / 2;
        }

        public override double GetPerimeter()
        {
            return base.GetPerimeter();
        }
    }
}
