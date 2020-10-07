using System;

namespace Converter
{
    class Program
    {
        private class Converter
        {
            private double _usd;
            private double _eur;
            public Converter(double usd, double eur)
            {
                this._usd = usd;
                this._eur = eur;
            }

            public double UAHToUSD(double uah)
            {
                return uah / _usd;
            }
            public double UAHToEUR(double uah)
            {
                return uah / _eur;
            }
            public double USDToUAH(double usd)
            {
                return usd * _usd;
            }
            public double USDToEUR(double usd)
            {
                return usd * (_usd / _eur);
            }
            public double EURToUSD(double eur)
            {
                return eur * (_eur / _usd);
            }
            public double EURToUAH(double eur)
            {
                return eur * _eur;
            }

            public double Convert(string from, string to, double value) // -1 = не вірні вхідні дані
            {
                string[] currencies = { "usd", "uah", "eur" };
                bool checkFrom = false; // перевірка на вірність вводу from
                bool checkTo = false; // перевірка на вірність вводу to

                foreach(string currency in currencies)
                {
                    if(from == currency)
                    {
                        checkFrom = true;
                    }

                    if(to == currency)
                    {
                        checkTo = true;
                    }
                }

                if(checkTo == false || checkFrom == false)
                {
                    return -1;
                }


                if(from == to)
                {
                    return value;
                }

                if (from == "uah")
                {
                    if (to == "usd")
                    {
                        return this.UAHToUSD(value);
                    }
                    else
                    {
                        return this.UAHToEUR(value);
                    }
                }
                else if (from == "eur")
                {
                    if (to == "usd")
                    {
                        return this.EURToUSD(value);
                    }
                    else
                    {
                        return this.EURToUAH(value);
                    }
                }
                else if (from == "usd")
                {
                    if (to == "eur")
                    {
                        return this.USDToEUR(value);
                    }
                    else
                    {
                        return this.USDToUAH(value);
                    }
                }
                else
                {
                    return -1;
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Максим Ошийко К-24");

            Console.WriteLine("Введiть курс долара по вiдношенню до гривнi: ");
            double usd = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть курс євро по вiдношенню до гривнi: ");
            double eur = Double.Parse(Console.ReadLine());

            Converter conv = new Converter(usd, eur);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("З якоi валюти перевести?(uah, eur, usd) ");
                string from = Console.ReadLine();

                Console.WriteLine("В яку валюту переводити?(uah, eur, usd) ");
                string to = Console.ReadLine();

                Console.WriteLine("Введiть сумму: ");
                double value = Double.Parse(Console.ReadLine());

                double result = conv.Convert(from, to, value);

                if (result == -1) // не вірні дані
                {
                    Console.WriteLine("Не вiрнi вхiднi данi. Спробуйте ще раз.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"{value} {from} = {result} {to}");
                }

                Console.WriteLine("Продовжити конвертацiю?(Y,N) ");
                string s = Console.ReadLine();

                if(s == "N")
                {
                    Console.WriteLine("Роботу програми завершено.");
                    exit = true;
                }
            }
        }
    }
}
