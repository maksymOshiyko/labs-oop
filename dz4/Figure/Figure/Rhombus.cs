using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    class Rhombus : Figure
    {
        private double _d1;
        private double _d2;

        public double Side { get; set; }

        public Rhombus(double d1, double d2)
        {
            this._d1 = d1;
            this._d2 = d2;
            this.Side = Math.Sqrt(Math.Pow(d1 / 2, 2) + Math.Pow(d2 / 2, 2));
        }

        public override double GetPerimeter()
        {
            return this.Side * 4;
        }

        public override double GetArea()
        {
            return this._d1 * this._d2 / 2; 
        }
    }
}
