using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matr
{
    public class MyMatrix
    {
        private double[,] tabl;
        private int n;
        private int k;

        public int N
        {
            get => n;
        }

        public int K
        {
            get => k;
        }

        public MyMatrix(int nn, int kk)
        {
            if (nn < 0 && kk < 0)
            {
                throw new ApplicationException("Некорректный размер матрицы");
            }
            else
            {
                n = nn;
                k = kk;
                tabl = new double[nn, kk];
            }
        }
        public MyMatrix Transposose()
        {
            MyMatrix TransopeMatrix= new MyMatrix(this.N, this.K);
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.K; j++)
                {
                    TransopeMatrix[i,j] = this[j,i];
                }
            }
            return TransopeMatrix;
        }

        private MyMatrix CalculateMinor(MyMatrix M, int i, int j)
        {
            MyMatrix result = new MyMatrix(M.N-1, M.K-1);
            for (int k = 0; k < M.K; k++)
            {
                for (int l =0 ; l < M.N; l++)
                {
                    if (k!=i && l != j)
                    {
                        if (k > i && l > j)
                            result[k-1,l-1] = M[k,l];
                        else if (k < i && l > j)
                            result[k, l - 1] = M[k, l];
                        else if (k > i && l < j)
                            result[k-1, l] = M[k, l];
                        else
                            result[k, l] = M[k, l];
                    }
                        
                }
            }
            return result;
        }

        public double CalculateDet()
        {
            if (this.N != this.K)
            {
                throw new ApplicationException("Матрица не квадратная!");
                return 0;
            }
            if (this.N == 1)
                return this[0, 0];
            int signum = 1;
            double summ = 0;
            for (int j = 0;j < this.K; j++)
            {
                summ += this[0, j] * signum * CalculateMinor(this, 0, j).CalculateDet();
                signum *= -1;
            }
            return summ;
        }

        public MyMatrix ReverseMatrix()
        {
            var det = this.CalculateDet();
            if (det == 0)
                throw new DivideByZeroException("Деление на ноль!");
            MyMatrix result = new MyMatrix(N, K);
            for (int i = 0; i < result.N; i++)
            {
                for (int j = 0; j < result.K; j++)
                {
                    result[i, j] = ((i + j) % 2 == 1 ? -1 : 1) *
                   (CalculateMinor(this, i, j)).CalculateDet();
                }
            }
            result = (1/det)*result.Transposose();
            return result;
        }
        public static MyMatrix operator *(MyMatrix matrix, MyMatrix matrix2)
        {
            if (matrix.N != matrix2.K)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            var result = new MyMatrix(matrix.N, matrix2.K);
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix2.K; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matrix2.N; k++)
                    {
                        temp += matrix[i, k]*matrix2[k,j];
                    }
                    result[i, j] = temp;
                }
            }
            return result;
        }
        public static MyMatrix operator *(MyMatrix matrix, double k)
        {
            var result = new MyMatrix(matrix.N, matrix.K);
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix.K; j++)
                {
                    result[i, j] = matrix[i, j]*k;
                }
            }
            return result;
        }
        public static MyMatrix operator *(double k, MyMatrix matrix)
        {
            var result = new MyMatrix(matrix.N, matrix.K);
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix.K; j++)
                {
                    result[i, j] = matrix[i, j] * k;
                }
            }
            return result;
        }
        public static MyMatrix operator +(MyMatrix matrix, MyMatrix matrix2)
        {
            if (matrix.N != matrix2.N || matrix.K != matrix2.K)
            {
                throw new ArgumentException("Не сложить матрицы");
            }
            var result = new MyMatrix(matrix.N, matrix2.K);
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix2.K; j++)
                {
                    result[i, j] = matrix[i, j] + matrix2[i, j];
                }
            }
            return result;
        }
        public static MyMatrix operator -(MyMatrix matrix, MyMatrix matrix2)
        {
            if (matrix.N != matrix2.N || matrix.K != matrix2.K)
            {
                throw new ArgumentException("Не сложить матрицы");
            }
            var result = new MyMatrix(matrix.N, matrix2.K);
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix2.K; j++)
                {
                    result[i, j] = matrix[i,j]-matrix2[i,j];
                }
            }
            return result;
        }
        public double this[int i, int j]
        {
            get
            {
                if ((i < 0) || (i >= n) || (j < 0) || (j > k))
                {
                    throw new ApplicationException("Некорректный индекс(ы)!");
                }
                return tabl[i, j];
            }

            set
            {
                if ((i < 0) || (i >= n) || (j < 0) || (j > k))
                {
                    throw new ApplicationException("Некорректный индекс(ы)!");
                }
                tabl[i, j] = value;
            }
        }
        public void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(tabl[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
