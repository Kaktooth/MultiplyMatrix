
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp54
{
    public class Program
    {


        static void Main(string[] args)
        {

            double[,] matrix = CreateMatrix();
            double[,] matrix2 = CreateMatrix();
            MyMatrix mymatrix = new MyMatrix(matrix);
            
            ShowOneMatrix( mymatrix.GetMatrix());
            MyMatrix mymatrix2 = new MyMatrix(matrix2);
            ShowMatrix(mymatrix2.GetMatrix());
            MyMatrix mat = mymatrix * mymatrix2;
            ShowOneMatrix(mat.GetMatrix());
        }
        public static void ShowMatrix(double[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    Console.Write(matrix[i, j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void ShowOneMatrix(double[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    Console.WriteLine(matrix[i, j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void ShowMatrixJagged(double[][] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {

                    Console.Write(matrix[i][j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public static double[,] CreateMatrix()
        {
            Console.WriteLine("Enter length of matrix");


            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter numbers for matrix");
            double[,] matrix = new double[n, m];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    matrix[i, j] = int.Parse(Console.ReadLine());

                }

            }
            Console.WriteLine();
            return matrix;
        }
        public static string CreateString()
        {

            Console.WriteLine("Enter string for matrix");
            string matrix = "";


            matrix = Convert.ToString(Console.ReadLine());

            Console.WriteLine();
            return matrix;
        }
        public static string[] CreateMatrixString()
        {
            Console.WriteLine("Enter length of matrix");


            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter numbers for matrix");
            string[] matrix = new string[n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {


                matrix[i] = Convert.ToString(Console.ReadLine());



            }
            Console.WriteLine();
            return matrix;
        }
        public static double[][] CreateMatrixJagged()
        {
            Console.WriteLine("Enter length of matrix");


            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter numbers for matrix");
            double[][] matrix = new double[n][];
            for (int i = 0; i <= n - 1; i++)
            {
                matrix[i] = new double[m];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < m; j++)
                {

                    matrix[i][j] = int.Parse(Console.ReadLine());

                }

            }
            Console.WriteLine();
            return matrix;
        }

    }
    class MyMatrix
    {
        private double[,] Matrix;
        public MyMatrix(MyMatrix mymatrix)
        {
            MyMatrix matrix = mymatrix;


        }
        public MyMatrix(double[,] matrix)
        {
            Matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            Matrix = matrix;
        }
        public MyMatrix(double[][] matrix)
        {
            Matrix = JaggedToMulti(matrix);
        }
        public MyMatrix(string[] matrix)
        {
            Matrix = StringArrayToMulti(matrix);

        }
        public MyMatrix(string matrix)
        {
            Matrix = StringToMulti(matrix);

        }
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.GetHeight() != b.GetHeight() || a.GetWidth() != b.GetWidth())
            {
                Console.WriteLine("Error: length of matrix not same");
                
            }
            double[,] array = new double[a.GetHeight(), a.GetWidth()];
            Parallel.For(0, a.GetHeight(), i =>
            {

                Parallel.For(0, a.GetWidth(), j =>
                {
                    array[i, j] = a[i, j] + b[i, j];

                });
                Console.WriteLine();
            });
            
            MyMatrix matrix = new MyMatrix(array);
            return matrix;
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            //if (a.GetHeight() != b.GetHeight() || a.GetWidth() != b.GetWidth())
            //{
            //    Console.WriteLine("Error: length of matrix not same");
               
            //}
            double[,] array = new double[b.GetHeight(), b.GetWidth()];
            double[,] resarray = new double[a.GetHeight(), a.GetWidth()];

            for (int i = 0; i < b.GetHeight(); i++)
            {
               
                for (int j = 0; j < b.GetWidth(); j++)
                {
                    array[i,j]= a[0, i] * b[i, j];
                   
                }
              
            }
            for (int i = 0; i < b.GetHeight(); i++)
            {
                double sum = 0;
                for (int j = 0; j < b.GetWidth(); j++)
                {
                    sum += array[j, i];

                }
                resarray[0, i] = sum;
            }
            //resarray[0, resarray.GetLength(1)] = 1;
            MyMatrix matrix = new MyMatrix(resarray);
            return matrix;
        }
        public string Height => $"{GetHeight()}";
        public string Width => $"{GetWidth()}";
        public int GetHeight()
        {
            return Matrix.GetLength(0);
        }
        public int GetWidth()
        {
            return Matrix.GetLength(1);
        }
        public double this[int index1, int index2]
        {
            get { return Matrix[index1, index2]; }
            set { Matrix[index1, index2] = value; }
        }
        public double GetValue(int index1, int index2)
        {
            return Matrix[index1, index2];
        }
        public void SetValue(int index1, int index2, double value)
        {
            Matrix[index1, index2] = value;
        }
        override public String ToString()
        {
            string str = "";

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {

                for (int j = 0; j < Matrix.GetLength(1); j++)
                {

                    str += Matrix[i, j];
                    str += " ";
                }
                str += Environment.NewLine;
            }
            return str;

        }

        protected double[,] GetTransponedArray()
        {
            double[,] mat = new double[Matrix.GetLength(1), Matrix.GetLength(0)];
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                for (int j = 0; j < Matrix.GetLength(0); j++)
                {

                    mat[i, j] = Matrix[j, i];
                }
            }

            return mat;
        }

        public MyMatrix GetTransponedCopy()
        {
            MyMatrix mymatrix = new MyMatrix(GetTransponedArray());
            return mymatrix;
        }

        public void TransponeMe()
        {
            MyMatrix mymatrix = new MyMatrix(GetTransponedArray());
            Matrix = mymatrix.GetMatrix();

        }
        public double[,] GetMatrix()
        {
            // for check
            return Matrix;
        }
        public static double[,] JaggedToMulti(double[][] matrix)
        {
            double[,] array2d = new double[matrix.Length, matrix[0].Length];
            for (int i = 0; i < array2d.GetLength(0); i++)
            {

                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = (double)matrix[i][j];
                }
            }
            return array2d;
        }
        public static double[,] StringToMulti(string str)
        {
            //1_ 2_3/4_ 5_6

            int n = 0;
            int m = 0;
            char[] chararray;
            string[,] array = new string[str.Length, str.Length];
            chararray = str.ToArray();
            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (chararray[i] == ' ' || chararray[i] == (char)0009)
                {
                    m++;
                }

                else if (chararray[i] == '/' || chararray[i] == 0x000A)
                {
                    n++;

                    if (index != m)
                    {
                        if (index == 0) { index = m; m = 0; continue; }
                        Console.WriteLine("Error: The quantity of numbers is not the same.");

                        break;


                    }
                    else
                    {

                        index = m;
                        m = 0;
                    }



                }
                else if (Char.IsDigit(chararray[i]))
                {
                    array[n, m] = Convert.ToString(chararray[i]);
                }
                else
                {
                    Console.WriteLine("Error: unspecified character");
                    break;
                }


            }

            double[,] array2d = new double[n + 1, index + 1];

            for (int i = 0; i < array2d.GetLength(0); i++)
            {

                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = Convert.ToInt32(array[i, j]);
                }
            }
            return array2d;
        }
        public static double[,] StringArrayToMulti(string[] matrix)
        {

            char[] s;
            string[,] array = new string[matrix.Length, matrix[0].Length];
            int c = 0;
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                s = matrix[i].ToArray();
                c = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {


                    if (Char.IsDigit(s[j]))
                    {
                        array[i, c] = Convert.ToString(s[j]);
                        c++;
                    }

                }

                if (index != c)
                {
                    if (index == 0) { index = c; continue; }
                    Console.WriteLine("Error: The quantity of numbers is not the same.");

                    break;


                }
                index = c;

            }
            double[,] array2d = new double[matrix.Length, c];


            for (int i = 0; i < array2d.GetLength(0); i++)
            {

                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = Convert.ToDouble(array[i, j]);
                }
            }
            return array2d;

        }

    }
}
