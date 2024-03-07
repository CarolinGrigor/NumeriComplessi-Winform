using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NumeriComplessi
{
    struct Complex
    {
        private readonly double _a;
        private readonly double _b;

        public Complex(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public static bool TryParse(string real, string immaginary, out Complex nC)
        {
            if(double.TryParse(real, out double r) && double.TryParse(immaginary, out double i))
            {
                nC = new Complex(r, i);
                return true;
            } else
            {
                nC = default;
                return false;
            }
        }

        public static Complex Parse(string real, string immaginary)
        {
            if(double.TryParse(real, out double r) && double.TryParse(immaginary, out double i))
            {
                return new Complex(r, i);
            } else
            {
                throw new ArgumentException("Formato non valido");
            }
        }

        public static Complex operator +(Complex actual, Complex other)
        {
            return new Complex(actual._a + other._a, other._b + other._b);
        }

        public static Complex operator -(Complex actual, Complex other)
        {
            return new Complex(actual._a - other._a, other._b - other._b);
        }

        public static Complex operator *(Complex actual, Complex other)
        {
            // (a + bi) * (c + di) => (ac - bd) + (ad + bc)i 
            return new Complex(actual._a * other._a - actual._b * other._b, actual._a * other._b + actual._b * other._a);
        }

        public static Complex operator /(Complex actual, Complex other)
        {
            // (a + bi) / (c + di) => ((ac + bd) / (c^2 + d^2)) + ((bc - ad) / (c^2 + d^2))i
            double modulo2 = other._a * other._a + other._b * other._b;
            double a = (actual._a * other._a + actual._b * other._b) / modulo2;
            double b = (actual._b * other._a - actual._a * other._b) / modulo2;
            return new Complex(a, b);
        }
        public double Modulo()
        {
            return Math.Sqrt(_a * _a + _b * _b);
        }

        public double Angolo()
        {
            return (Math.Atan2(_b, _a) * 180) / Math.PI;
        }

        public override string ToString()
        {
            return $"{_a} + {_b}i";
        }
    }
}
