class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое число:");
        string input1 = Console.ReadLine();

        Console.WriteLine("Введите второе число:");
        string input2 = Console.ReadLine();

        try
        {
            if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2))
            {
                throw new ArgumentException("Не введено число.");
            }

            if (input1.Length > 15 || input2.Length > 15)
            {
                throw new ArgumentException("Введено слишком длинное число.");
            }

            double number1 = Convert.ToDouble(input1);
            double number2 = Convert.ToDouble(input2);

            if (number2 == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }

            double result = number1 / number2;
            Console.WriteLine($"Результат деления: {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка преобразования.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception)
        {
            Console.WriteLine("Произошла неизвестная ошибка.");
        }
    }
}
//1. Проверка на пустой ввод:**Используется `string.IsNullOrWhiteSpace` для проверки, было ли введено число.
//2. Проверка длины числа:**Проверяется длина строки, чтобы убедиться, что число не слишком длинное.
//3. Преобразование и деление:**Используется `Convert.ToDouble` для преобразования строки в число. Если второе число равно нулю, выбрасывается исключение `DivideByZeroException`.
//4. Обработка исключений:**Используются различные блоки `catch` для обработки разных типов ошибок и вывода соответствующих сообщений.