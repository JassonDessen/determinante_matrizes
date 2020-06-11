using System;
using System.Globalization;

namespace DeterminanteDeMatrizes
{
    class Program
    {
        static void Main(string[] args)
        {
            int linha, coluna;
            double[,] matriz;

            Console.WriteLine("Calculador de determinante de matriz.");
            Console.WriteLine("Obs.: A calculadora de determinante só calcula os determinantes " +
                "de matrizes até ordem 3x3.");
            Console.WriteLine("A matriz deve ser quadrada!");

            Console.WriteLine();

            do
            {
                Console.Write("Informe a quantidade de linhas da matriz: ");
                linha = int.Parse(Console.ReadLine());
                Console.Write("Informe a quantidade de colunas da matriz: ");
                coluna = int.Parse(Console.ReadLine());
            } while ((linha != coluna) || (linha > 3) || (coluna > 3));

            // Instanciando a matriz
            matriz = new double[linha, coluna];

            Console.WriteLine();

            // Preenchendo a matriz
            for (int i = 0; i <= matriz.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matriz.GetUpperBound(1); j++)
                {
                    Console.Write($"Informe um valor para a posição [{i + 1}, {j + 1}]: ");
                    matriz[i, j] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Matriz {linha}x{coluna}");
            // Printando a matriz
            PrintMat(matriz);
            Console.WriteLine($"E o seu determinante é: {Determinante(matriz)}");
        }

        static double Determinante(double[,] mat)
        {
            double matrix = 0;
            
            if (mat.GetUpperBound(0) == 0 && mat.GetUpperBound(1) == 0)
            {
                matrix = mat[0, 0];
            }
            else if (mat.GetUpperBound(0) == 1 && mat.GetUpperBound(1) == 1)
            {
                matrix = (mat[0, 0] * mat[1, 1]) - (mat[0, 1] * mat[1, 0]);
            }
            else if (mat.GetUpperBound(0) == 2 && mat.GetUpperBound(1) == 2)
            {
                matrix = (mat[0, 0] * mat[1, 1] * mat[2, 2]) + (mat[0, 1] * mat[1, 2] * mat[2, 0]) +
                    (mat[0, 2] * mat[1, 0] * mat[2, 1]) - (mat[0, 1] * mat[1, 0] * mat[2, 2]) -
                    (mat[0, 0] * mat[1, 2] * mat[2, 1]) - (mat[0, 2] * mat[1, 1] * mat[2, 0]);
            }

            return matrix;
        }

        static void PrintMat(double[,] mat)
        {
            for (int i = 0; i <= mat.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= mat.GetUpperBound(1); j++)
                {
                    Console.Write($"\t{mat[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
