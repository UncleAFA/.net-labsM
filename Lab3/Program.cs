/// <summary>
//Добавление новой задачи — позволяет ввести название задачи, описание, тестировщика и срок выполнения.
//Назначение тестировщика — возможность изменить ответственного тестировщика для существующей задачи.
//Изменение статуса задачи — изменяет статус задачи на "Не начато", "В процессе" или "Завершено".
//Отображение задач по тестировщику — выводит список задач, назначенных на конкретного тестировщика.
//Выход — завершает работу программы.
/// </summary>
class Program
{
    // Класс Task представляет задачу по тестированию
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Tester { get; set; }
        public DateTime Deadline { get; set; }

        public Task(string title, string description, string tester, DateTime deadline)
        {
            Title = title;
            Description = description;
            Status = "Не начато";  // Начальный статус
            Tester = tester;
            Deadline = deadline;
        }

        // Отображение информации о задаче
        public void DisplayTask()
        {
            Console.WriteLine($"Название задачи: {Title}");
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine($"Ответственный тестировщик: {Tester}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine($"Срок выполнения: {Deadline.ToShortDateString()}\n");
        }
    }

    // Список для хранения всех задач
    static List<Task> taskList = new List<Task>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить новую задачу");
            Console.WriteLine("2. Назначить тестировщика");
            Console.WriteLine("3. Изменить статус задачи");
            Console.WriteLine("4. Отобразить задачи по тестировщику");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    AssignTester();
                    break;
                case "3":
                    ChangeStatus();
                    break;
                case "4":
                    DisplayTasksByTester();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.\n");
                    break;
            }
        }
    }

    // Метод для добавления новой задачи
    static void AddTask()
    {
        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine();

        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        Console.Write("Введите имя тестировщика: ");
        string tester = Console.ReadLine();

        Console.Write("Введите срок выполнения (ГГГГ-ММ-ДД): ");
        DateTime deadline;
        if (DateTime.TryParse(Console.ReadLine(), out deadline))
        {
            taskList.Add(new Task(title, description, tester, deadline));
            Console.WriteLine("Задача добавлена.\n");
        }
        else
        {
            Console.WriteLine("Некорректный формат даты. Задача не добавлена.\n");
        }
    }

    // Метод для назначения тестировщика для задачи
    static void AssignTester()
    {
        if (!taskList.Any())
        {
            Console.WriteLine("Список задач пуст.\n");
            return;
        }

        Console.Write("Введите название задачи для назначения тестировщика: ");
        string title = Console.ReadLine();

        Task task = taskList.FirstOrDefault(t => t.Title == title);

        if (task != null)
        {
            Console.Write("Введите имя нового тестировщика: ");
            task.Tester = Console.ReadLine();
            Console.WriteLine("Тестировщик назначен.\n");
        }
        else
        {
            Console.WriteLine("Задача не найдена.\n");
        }
    }

    // Метод для изменения статуса задачи
    static void ChangeStatus()
    {
        if (!taskList.Any())
        {
            Console.WriteLine("Список задач пуст.\n");
            return;
        }

        Console.Write("Введите название задачи для изменения статуса: ");
        string title = Console.ReadLine();

        Task task = taskList.FirstOrDefault(t => t.Title == title);

        if (task != null)
        {
            Console.WriteLine("Выберите новый статус задачи:");
            Console.WriteLine("1. Не начато");
            Console.WriteLine("2. В процессе");
            Console.WriteLine("3. Завершено");
            string statusChoice = Console.ReadLine();

            switch (statusChoice)
            {
                case "1":
                    task.Status = "Не начато";
                    break;
                case "2":
                    task.Status = "В процессе";
                    break;
                case "3":
                    task.Status = "Завершено";
                    break;
                default:
                    Console.WriteLine("Некорректный выбор статуса.\n");
                    return;
            }

            Console.WriteLine("Статус задачи обновлен.\n");
        }
        else
        {
            Console.WriteLine("Задача не найдена.\n");
        }
    }

    // Метод для отображения задач по тестировщику
    static void DisplayTasksByTester()
    {
        if (!taskList.Any())
        {
            Console.WriteLine("Список задач пуст.\n");
            return;
        }

        Console.Write("Введите имя тестировщика для отображения его задач: ");
        string tester = Console.ReadLine();

        var tasksByTester = taskList.Where(t => t.Tester == tester);

        if (tasksByTester.Any())
        {
            foreach (var task in tasksByTester)
            {
                task.DisplayTask();
            }
        }
        else
        {
            Console.WriteLine("У данного тестировщика нет задач.\n");
        }
    }
}
