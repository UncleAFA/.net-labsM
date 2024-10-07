using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        private List<Task> tasks = new List<Task>();

        public Form1()
        {
            InitializeComponent();
            UpdateTaskList();
        }

        private void UpdateTaskList()
        {
            listBoxTasks.Items.Clear();
            foreach (var task in tasks)
            {
                listBoxTasks.Items.Add(task);
            }
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            // Открываем форму добавления новой задачи
            var addTaskForm = new AddTaskForm(this);
            addTaskForm.ShowDialog();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
            UpdateTaskList();
        }

        private void buttonFilterByTester_Click(object sender, EventArgs e)
        {
            string tester = textBoxFilterTester.Text;
            var filteredTasks = tasks.FindAll(t => t.Tester == tester);
            listBoxTasks.Items.Clear();
            foreach (var task in filteredTasks)
            {
                listBoxTasks.Items.Add(task);
            }
        }

        private void buttonChangeStatus_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedItem is Task selectedTask)
            {
                // Меняем статус задачи
                var changeStatusForm = new ChangeStatusForm(selectedTask, this);
                changeStatusForm.ShowDialog();
            }
        }

        public void UpdateTaskStatus(Task task)
        {
            UpdateTaskList();
        }
    }
}
