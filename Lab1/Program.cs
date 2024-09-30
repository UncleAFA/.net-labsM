/// <summary>
/// Как работает программа:
/// Программа запрашивает у пользователя ввод чисел через пробел.
/// Введенные числа разбиваются на отдельные строки.
/// Каждая строка преобразуется в число, и для каждого числа проверяется, является ли оно простым.
/// Если число простое, оно засчитывается в общий счетчик простых чисел.
/// В конце программа выводит количество простых чисел.
/// </summary>


class Program
{
    // Метод для проверки, является ли число простым
    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        string[] inputNumbers;
        while (true)
        {
            Console.Write("Введите набор чисел через пробел:");
            string input = Console.ReadLine();

            // Разделяем введенные числа на массив строк
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Строка пустая. Повторите ввод.");
                continue;
            }
            inputNumbers = input.Split(' ');
            break;
        }


        int primeCount = 0;

        // Проходим по каждому числу
        foreach (string numStr in inputNumbers)
        {
            // Пытаемся преобразовать строку в число
            if (int.TryParse(numStr, out int number))
            {
                // Проверяем, является ли число простым
                if (IsPrime(number))
                {
                    primeCount++;
                }
            }
            else
            {
                Console.WriteLine($"'{numStr}' не является допустимым числом.");
            }
        }

        Console.WriteLine($"Количество простых чисел: {primeCount}");
    }
}
