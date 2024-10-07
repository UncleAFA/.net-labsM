namespace AnimalReflectionExample
{
    public class Animal
    {
        // Свойство с атрибутом
        [MyCustomAttribute]
        public string Species { get; set; }

        // Свойство без атрибута
        public int Age { get; set; }

        // Конструктор по умолчанию
        public Animal() { }

        // Конструктор с параметрами
        public Animal(string species, int age)
        {
            Species = species;
            Age = age;
        }

        // Метод для вывода информации о животном
        public void DisplayInfo()
        {
            Console.WriteLine($"Species: {Species}, Age: {Age}");
        }
    }

    // Определение атрибута
    [AttributeUsage(AttributeTargets.Property)]
    public class MyCustomAttribute : Attribute
    {
        // Дополнительные параметры атрибута можно добавить здесь
    }
}
