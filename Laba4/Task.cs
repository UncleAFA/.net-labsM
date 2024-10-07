using System;

public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Tester { get; set; }
    public DateTime DueDate { get; set; }

    public Task(string title, string description, string status, string tester, DateTime dueDate)
    {
        Title = title;
        Description = description;
        Status = status;
        Tester = tester;
        DueDate = dueDate;
    }

    public override string ToString()
    {
        return $"Задача: {Title}, Тестировщик: {Tester}, Статус: {Status}, Дедлайн: {DueDate.ToShortDateString()}";
    }
}
