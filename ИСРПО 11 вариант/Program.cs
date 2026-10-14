using System;

namespace MatrixTask
{
    class Program
    {
        static double[,] CreateMatrix(int n, int m)
        {
            double[,] matrix = new double[n, m];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(-50, 51) / 10.0;
                }
            }
            matrix[0, 0] = 0.0;

            return matrix;
        }

        static void Main()
        {
            int n;
            while (true)
            {
                Console.Write("Введите количество строк n: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;
                Console.WriteLine("Ошибка: введите целое ЧИСЛО больше 0.");
            }

            int m;
            while (true)
            {
                Console.Write("Введите количество столбцов m: ");
                if (int.TryParse(Console.ReadLine(), out m) && m > 0)
                    break;
                Console.WriteLine("Ошибка: введите целое ЧИСЛО больше 0.");
            }

            double[,] matrix = CreateMatrix(n, m);

            Console.WriteLine("\nСозданная матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],8:F1}");
                }
                Console.WriteLine();
            }

            double totalSum = 0;
            int columnsWithZeroCount = 0;

            for (int j = 0; j < m; j++)
            {
                bool hasZero = false;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break; 
                    }
                }
                if (hasZero)
                {
                    columnsWithZeroCount++;
                    for (int i = 0; i < n; i++)
                    {
                        totalSum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"\nКоличество столбцов с нулевым элементом: {columnsWithZeroCount}");
            Console.WriteLine($"Общая сумма элементов этих столбцов: {totalSum:F4}");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}