namespace TaskManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonFilterByTester;
        private System.Windows.Forms.TextBox textBoxFilterTester;
        private System.Windows.Forms.Button buttonChangeStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonFilterByTester = new System.Windows.Forms.Button();
            this.textBoxFilterTester = new System.Windows.Forms.TextBox();
            this.buttonChangeStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(12, 12);
            this.listBoxTasks.MaximumSize = new System.Drawing.Size(1027, 225);
            this.listBoxTasks.MinimumSize = new System.Drawing.Size(1027, 225);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(1027, 225);
            this.listBoxTasks.TabIndex = 0;
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(12, 255);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "Добавить";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // buttonFilterByTester
            // 
            this.buttonFilterByTester.Location = new System.Drawing.Point(964, 257);
            this.buttonFilterByTester.Name = "buttonFilterByTester";
            this.buttonFilterByTester.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterByTester.TabIndex = 2;
            this.buttonFilterByTester.Text = "Фильтр";
            this.buttonFilterByTester.UseVisualStyleBackColor = true;
            this.buttonFilterByTester.Click += new System.EventHandler(this.buttonFilterByTester_Click);
            // 
            // textBoxFilterTester
            // 
            this.textBoxFilterTester.Location = new System.Drawing.Point(817, 257);
            this.textBoxFilterTester.Name = "textBoxFilterTester";
            this.textBoxFilterTester.Size = new System.Drawing.Size(141, 20);
            this.textBoxFilterTester.TabIndex = 3;
            // 
            // buttonChangeStatus
            // 
            this.buttonChangeStatus.Location = new System.Drawing.Point(93, 255);
            this.buttonChangeStatus.Name = "buttonChangeStatus";
            this.buttonChangeStatus.Size = new System.Drawing.Size(51, 23);
            this.buttonChangeStatus.TabIndex = 4;
            this.buttonChangeStatus.Text = "Статус";
            this.buttonChangeStatus.UseVisualStyleBackColor = true;
            this.buttonChangeStatus.Click += new System.EventHandler(this.buttonChangeStatus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 287);
            this.Controls.Add(this.buttonChangeStatus);
            this.Controls.Add(this.textBoxFilterTester);
            this.Controls.Add(this.buttonFilterByTester);
            this.Controls.Add(this.buttonAddTask);
            this.Controls.Add(this.listBoxTasks);
            this.MaximumSize = new System.Drawing.Size(1073, 343);
            this.MinimumSize = new System.Drawing.Size(1073, 343);
            this.Name = "Form1";
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
