/// <summary>
/// Пользователь вводит размеры матрицы (n строк и m столбцов).
/// Пользователь вводит элементы матрицы.
/// Программа находит максимальное значение среди всех элементов.
/// Все элементы, равные максимальному значению, заменяются на нули.
/// Программа выводит обновленную матрицу.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Ввод размеров матрицы
        int n;
        while (true)
        {
            Console.Write("Введите количество строк (n): ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                n = result;
                break;
            }
            Console.WriteLine("Это не число. Повторите ввод.");
        }
        int m;
        while (true)
        {
            Console.Write("Введите количество столбцов (m):");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                m = result;
                break;
            }
            Console.WriteLine("Это не число. Повторите ввод.");
        }

        // Инициализация матрицы
        int[,] matrix = new int[n, m];

        // Ввод элементов матрицы
        Console.WriteLine("Введите элементы матрицы:");
        int maxValue = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {

                while (true)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        matrix[i, j] = result;
                        maxValue = Math.Max(maxValue, result);
                        break;
                    }
                    Console.WriteLine("Это не число. Повторите ввод.");
                }
            }
        }

        // Замена всех максимальных значений на нули
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] == maxValue)
                    matrix[i, j] = 0;
            }
        }

        // Вывод итоговой матрицы
        Console.WriteLine("Матрица после замены максимальных значений на нули:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
