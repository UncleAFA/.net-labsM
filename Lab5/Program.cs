using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Путь к исходному файлу с заказами
        string inputFilePath = "F.txt";
        // Путь к новому файлу, в который будут записаны заказы с суммой больше указанной
        string outputFilePath = "FilteredOrders.txt";

        // Минимальная сумма для фильтрации заказов
        decimal minAmount = 1000; // Замените на необходимую сумму

        // Проверяем, существует ли исходный файл
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Файл с заказами не найден.");
            return;
        }

        // Открываем исходный файл для чтения
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            // Открываем или создаем новый файл для записи отфильтрованных заказов
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line;
                // Читаем файл построчно
                while ((line = reader.ReadLine()) != null)
                {
                    // Предполагаем, что каждая строка содержит данные в формате: "номер_заказа сумма"
                    string[] parts = line.Split(' ');

                    if (parts.Length == 2)
                    {
                        string orderNumber = parts[0]; // Номер заказа
                        decimal orderAmount;

                        // Проверяем, что вторая часть строки является числом (суммой)
                        if (decimal.TryParse(parts[1], out orderAmount))
                        {
                            // Если сумма больше минимальной, записываем заказ в новый файл
                            if (orderAmount > minAmount)
                            {
                                writer.WriteLine(line);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ошибка чтения суммы в строке: {line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Некорректный формат строки: {line}");
                    }
                }
            }
        }

        Console.WriteLine($"Заказы с суммой больше {minAmount} записаны в файл {outputFilePath}.");
    }
}
