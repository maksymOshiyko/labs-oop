﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AbstractFactory
{
    public class AbstractFactory
    {
// AbstractProductA
        abstract class Car
        {
            public abstract void Info();
        }
// ConcreteProductA1
        class Ford : Car
        {
            public override void Info()
            {
                Console.WriteLine("Ford");
            }
        }
//ConcreteProductA2
        class Toyota : Car
        {
            public override void Info()
            {
                Console.WriteLine("Toyota");
            }
        }
// AbstractProductB
        abstract class Engine
        {
            public virtual void GetPower()
            {
            }
        }
// ConcreteProductB1
        class FordEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Ford Engine 4.4");
            }
        }
//ConcreteProductB2
        class ToyotaEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Toyota Engine 3.2");
            }
        }
// AbstractFactory
        interface ICarFactory
        {
            Car CreateCar();
            Engine CreateEngine();
        }
// ConcreteFactory1
        class FordFactory : ICarFactory
        {
// from CarFactory
            Car ICarFactory.CreateCar()
            {
                return new Ford();
            }
            Engine ICarFactory.CreateEngine()
            {
                return new FordEngine();
            }
        }
// ConcreteFactory2
        class ToyotaFactory : ICarFactory
        {
// from CarFactory
            Car ICarFactory.CreateCar()
            {
                return new Toyota();
            }
            Engine ICarFactory.CreateEngine()
            {
                return new ToyotaEngine();
            }
        }

        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();
            carFactory = new FordFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();
            Console.ReadKey();
        }
    }
}