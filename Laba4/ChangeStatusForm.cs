using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TaskManager
{
    public partial class ChangeStatusForm : Form
    {
        private Task task;
        private Form1 mainForm;

        public ChangeStatusForm(Task selectedTask, Form1 form)
        {
            InitializeComponent();
            task = selectedTask;
            mainForm = form;

            // Устанавливаем текущее значение статуса
            comboBoxStatus.SelectedItem = task.Status;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Обновляем статус задачи
            task.Status = comboBoxStatus.SelectedItem.ToString();
            mainForm.UpdateTaskStatus(task);
            this.Close();
        }
    }
}
