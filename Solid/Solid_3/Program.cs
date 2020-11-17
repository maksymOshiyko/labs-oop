using System;






class Program
{
    abstract class Figure
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public virtual int GetArea()
        {
            return Width * Height;
        } 
    }     

    class Rectangle : Figure
    {
        public override int GetArea()
        {
            return base.GetArea();
        }
    }

    //квадрат наслідується від прямокутника!!!
    class Square : Figure
    {
        public override int Width
        {
            get { return base.Width; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
        public override int Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }

        public override int GetArea()
        {
            return base.GetArea();
        }

    }

    static void Main(string[] args)
    {
        Figure square = new Square();
        square.Width = 5;
        square.Height = 10;

        Console.WriteLine(square.GetArea());
        //Відповідь 100? Що не так???
        Console.ReadKey();
    }
}