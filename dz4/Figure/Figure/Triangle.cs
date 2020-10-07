using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    class Triangle : Figure
    {
        protected double _firstSide;
        protected double _secondSide;
        protected double _thirdSide;

        public double FirstAngle { get; set; }
        public double SecondAngle { get; set; }
        public double ThirdAngle { get; set; }

        public override double GetPerimeter()
        {
           return this._firstSide + this._secondSide + this._thirdSide; 
        }

        public override double GetArea()
        {
            double halfPerimeter = this.GetPerimeter() / 2;
            return Math.Round(Math.Sqrt(halfPerimeter * (halfPerimeter - this._firstSide)
                * (halfPerimeter - this._secondSide) * (halfPerimeter - this._thirdSide)), 2);
        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            this._firstSide = firstSide;
            this._secondSide = secondSide;
            this._thirdSide = thirdSide;

            this.FirstAngle = Math.Round(Math.Acos((Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2)
                                        - Math.Pow(thirdSide, 2))
                                        / (2 * firstSide * secondSide)) * 180 / Math.PI);

            this.SecondAngle = Math.Round(Math.Acos((Math.Pow(firstSide, 2) + Math.Pow(thirdSide, 2)
                                        - Math.Pow(secondSide, 2))
                                        / (2 * firstSide * thirdSide)) * 180 / Math.PI);

            this.ThirdAngle = Math.Round(Math.Acos((Math.Pow(thirdSide, 2) + Math.Pow(secondSide, 2)
                                        - Math.Pow(firstSide, 2))
                                        / (2 * thirdSide * secondSide)) * 180 / Math.PI);
        }
    }
}
