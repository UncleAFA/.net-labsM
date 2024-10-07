using System;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class AddTaskForm : Form
    {
        private Form1 mainForm;

        public AddTaskForm(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Считываем данные из полей ввода
            string title = textBoxTitle.Text;
            string description = textBoxDescription.Text;
            string status = "Не начато";
            string tester = textBoxTester.Text;
            DateTime dueDate = dateTimePickerDueDate.Value;

            // Создаем новую задачу
            Task newTask = new Task(title, description, status, tester, dueDate);
            mainForm.AddTask(newTask);
            this.Close();
        }
    }
}
