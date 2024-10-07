using System;
using System.Collections.Generic;

namespace EvenMatrixElements
{
    // Определение делегата, который будет использоваться для фильтрации
    public delegate bool FilterDelegate(int number);

    class Program
    {
        static void Main(string[] args)
        {
            // Ввод размера матрицы от пользователя
            Console.Write("Введите количество строк матрицы: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы: ");
            int columns = int.Parse(Console.ReadLine());

            // Создание и заполнение матрицы случайными числами
            int[,] matrix = GenerateRandomMatrix(rows, columns);
            Console.WriteLine("Сгенерированная матрица:");
            PrintMatrix(matrix);

            // Получение четных элементов с помощью делегата
            List<int> evenNumbers = FilterMatrix(matrix, IsEven);
            Console.WriteLine("\nЧетные элементы матрицы:");
            foreach (var number in evenNumbers)
            {
                Console.Write(number + " ");
            }
        }

        // Метод для генерации матрицы случайных чисел
        static int[,] GenerateRandomMatrix(int rows, int columns)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(1, 100); // Генерация чисел от 1 до 99
                }
            }
            return matrix;
        }

        // Метод для печати матрицы
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Метод для фильтрации элементов матрицы с использованием делегата
        static List<int> FilterMatrix(int[,] matrix, FilterDelegate filter)
        {
            List<int> filteredNumbers = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (filter(matrix[i, j]))
                    {
                        filteredNumbers.Add(matrix[i, j]);
                    }
                }
            }
            return filteredNumbers;
        }

        // Метод для проверки, является ли число четным
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
