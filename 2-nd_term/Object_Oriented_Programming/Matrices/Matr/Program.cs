using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matr
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix m1;

            try
            {
                m1 = new MyMatrix(3, 3);
                m1[0, 0] = 2;
                m1[0, 1] = 5;
                m1[0, 2] = 7;
                m1[1, 0] = 6;
                m1[1, 1] = 3;
                m1[1, 2] = 4;
                m1[2, 0] = 5;
                m1[2, 1] = -2;
                m1[2, 2] = -3;
                Console.WriteLine(m1.CalculateDet());
                m1.ReverseMatrix().Print();
                (m1.ReverseMatrix() * m1).Print();


            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}
