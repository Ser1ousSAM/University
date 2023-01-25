using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frac
{
    public class Fraction
    {
        private int num, den;

        public int Num
        {
            get => num;
        }

        public int Den
        {
            get => den;
        }

        public Fraction(int n, int d)
        {
            num = n;
            try {
                den = d;
                Correct();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division of {0} by zero.", num);
            }
        }

        public Fraction()
            : this(1, 1)
        { }

        private int GCD(int a, int b)
        {
            if (a == 0 || b == 0)
                return a + b;
            else 
                return GCD(b, a % b);
        }
        private void Correct()
        {
            int gcd = GCD(num, den);
            num /= gcd;
            den /= gcd;
        }
        public override string ToString()
        {
            string ans = "";
            if (num == 0)
                return "0";
            if (num > 0 && den < 0 || num < 0 && den > 0)
                ans += "-";
            try
            {
                int k = Math.Abs(num / den);
                if (k != 0)
                {
                    ans += k.ToString();
                    num -= den * k;
                }
                if (num % den != 0)
                {
                    Correct();
                    ans += "(" + Math.Abs(num).ToString() + "/" + Math.Abs(den).ToString() + ")";
                }
                return ans;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division of {0} by zero.", num);
            }
            return "Дробь не существует";
        }
        public double ToDec()
        {
            return 1.0 * num / den;
        }

        public static Fraction operator *(Fraction d1, Fraction d2)
        {
            return new Fraction(d1.num*d2.num, d1.den*d2.den);
        }

        public static double operator *(Fraction d1, double n)
        {
            return d1.ToDec() * n;
        }

        public static double operator *(double n, Fraction d1)
        {
            return d1.ToDec() * n;
        }

        public static Fraction operator /(Fraction d1, Fraction d2)
        {
            try
            {
                return new Fraction(d1.num * d2.den, d1.den * d2.num);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division of {0} by zero.", d1);
            }
            return null;
        }

        public static Fraction operator +(Fraction d1, Fraction d2)
        {
            return new Fraction(d1.num * d2.den + d1.den * d2.num, d1.den * d2.den);
        }

        public static Fraction operator -(Fraction d1, Fraction d2)
        {
            return new Fraction(d1.num * d2.den - d1.den * d2.num, d1.den * d2.den);
        }

        public static bool operator !=(Fraction fr1, Fraction fr2)
        {
            return fr1.ToDec() != fr2.ToDec(); ;
        }

        public static bool operator ==(Fraction fr1, Fraction fr2)
        {
            return fr1.ToDec() == fr2.ToDec();
        }

        public static bool operator >(Fraction fr1, Fraction fr2)
        {
            return fr1.ToDec() > fr2.ToDec();
        }

        public static bool operator <(Fraction fr1, Fraction fr2)
        {
            return fr1.ToDec() < fr2.ToDec();
        }

        public static bool operator >=(Fraction fr1, Fraction fr2)
        {
            return fr1.ToDec() >= fr2.ToDec();
        }

        public static bool operator <=(Fraction fr1, Fraction fr2)
        {
            return fr1.ToDec() <= fr2.ToDec();
        }

    }
}
