using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frac
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fr1 = new Fraction(-4, -6);
            Fraction fr2 = new Fraction(5, 6);
            Fraction fr3 = fr1 + fr2;
            Console.WriteLine(fr1);
            Console.WriteLine(fr2);
            Console.WriteLine(fr3);
            Console.WriteLine(new Fraction(3, 5) * new Fraction(5, 3));
            Console.WriteLine(new Fraction(-3, 5) * new Fraction(5, 3));
            Console.WriteLine(new Fraction(2, 5) * new Fraction(5, 3));
            Console.WriteLine(new Fraction(2, 5) > new Fraction(5, 3));
            Console.WriteLine(new Fraction(2, 5) <= new Fraction(5, 3));

            Console.ReadLine();
        }
    }
}