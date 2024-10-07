using System.Reflection;

namespace AnimalReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Type animalType = typeof(Animal);

            // Вывод информации о конструкторах
            Console.WriteLine("Constructors:");
            ConstructorInfo[] constructors = animalType.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor);
            }

            // Вывод информации о свойствах
            Console.WriteLine("\nProperties:");
            PropertyInfo[] properties = animalType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property);
            }

            // Вывод информации о методах
            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = animalType.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method);
            }

            // Вывод только тех свойств, которым назначен атрибут
            Console.WriteLine("\nProperties with MyCustomAttribute:");
            foreach (PropertyInfo property in properties)
            {
                if (Attribute.IsDefined(property, typeof(MyCustomAttribute)))
                {
                    Console.WriteLine(property);
                }
            }

            // Вызов метода DisplayInfo с использованием рефлексии
            Console.WriteLine("\nInvoking DisplayInfo method:");
            Animal animal = (Animal)Activator.CreateInstance(animalType, "Elephant", 10);
            MethodInfo displayInfoMethod = animalType.GetMethod("DisplayInfo");
            displayInfoMethod.Invoke(animal, null);

            Console.ReadLine();
        }
    }
}
//Класс Animal:
//Содержит два свойства: Species и Age. У свойства Species есть пользовательский атрибут MyCustomAttribute.
//Два конструктора: по умолчанию и с параметрами.
//Метод DisplayInfo выводит информацию о животном.
//Класс MyCustomAttribute:
//Наследуется от System.Attribute и используется для аннотирования свойств.
//Класс Program:
//Получает тип Animal и выводит информацию о конструкторах, свойствах и методах с помощью рефлексии.
//Использует Attribute.IsDefined для проверки наличия атрибута у свойств.
//Создает экземпляр Animal с помощью Activator.CreateInstance и вызывает метод DisplayInfo с помощью рефлексии.