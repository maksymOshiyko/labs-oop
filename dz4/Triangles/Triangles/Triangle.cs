using System;
using System.Collections.Generic;
using System.Text;

namespace Triangles
{
    abstract class Triangle
    {
        protected double _firstSide;
        protected double _secondSide;
        protected double _thirdSide;

        public double FirstAngle { get; set; }
        public double SecondAngle { get; set; }
        public double ThirdAngle { get; set; }

        public virtual double GetPerimeter()
        {
            return this._firstSide + this._secondSide + this._thirdSide; 
        }

        public virtual double GetArea()
        { 
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Round(Math.Sqrt(halfPerimeter * (halfPerimeter - _firstSide)
                    * (halfPerimeter - _secondSide) * (halfPerimeter - _thirdSide)), 2);
        }

        public Triangle(double firstSide, double secondSide, double angle)
        {
            this._firstSide = firstSide;
            this._secondSide = secondSide;
            this._thirdSide = Math.Sqrt(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2) 
                - (2 * firstSide * secondSide * Math.Cos(angle * Math.PI / 180)));

            this.FirstAngle = Math.Round(Math.Acos((Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2)
                                        - Math.Pow(_thirdSide, 2))
                                        / (2 * firstSide * secondSide)) * 180 / Math.PI);

            this.SecondAngle = Math.Round(Math.Acos((Math.Pow(firstSide, 2) + Math.Pow(_thirdSide, 2)
                                        - Math.Pow(secondSide, 2))
                                        / (2 * firstSide * _thirdSide)) * 180 / Math.PI);

            this.ThirdAngle = Math.Round(Math.Acos((Math.Pow(_thirdSide, 2) + Math.Pow(secondSide, 2)
                                        - Math.Pow(firstSide, 2))
                                        / (2 * _thirdSide * secondSide)) * 180 / Math.PI);
        }
    }
}
