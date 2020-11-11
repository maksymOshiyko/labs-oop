using System;

namespace Decorator
{
    abstract class SpruceDecorator : Spruce
    {
        protected Spruce _spruce;

        public SpruceDecorator(Spruce spruce)
        {
            this._spruce = spruce;
        }
    }

    class DecorationSpruce : SpruceDecorator
    {
        public DecorationSpruce(Spruce spruce) : base(spruce)
        {
            _spruce.HasDecoration = true;
        }
    }

    class GarlandSpruce : SpruceDecorator
    {
        public GarlandSpruce(Spruce spruce) : base(spruce)
        {
            _spruce.CanBright = true;
        }
    }
    class Spruce
    {
        public bool CanBright { get; set; }
        public bool HasDecoration { get; set; }
        public bool IsBright { get; set; }

        public Spruce()
        {
            
        }

        public void SwitchBrightness()
        {
            this.IsBright = this.IsBright ? false : true;
            
            if (CanBright)
            {
                if (IsBright)
                {
                    Console.WriteLine("Spruce is brightening.");
                }
                else
                {
                    Console.WriteLine("Spruce is not brightening.");
                }
            }
            else
            {
                Console.WriteLine("Spruce dont have garland.");
            }
        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}