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
        Console.Write("Введите набор чисел через пробел:");
        string input = Console.ReadLine();

        // Разделяем введенные числа на массив строк
        string[] inputNumbers = input.Split(' ');

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
