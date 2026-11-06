namespace Lab8_CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            labelName = new Label();
            textBoxName = new TextBox();
            labelAge = new Label();
            numericAge = new NumericUpDown();
            labelGroup = new Label();
            textBoxGroup = new TextBox();
            labelGrade = new Label();
            numericGrade = new NumericUpDown();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            labelStatus = new Label();
            buttonExport = new Button();
            buttonCancel = new Button();
            textBox1 = new TextBox();
            textBoxSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(27, 24);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.RowHeadersWidth = 51;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(750, 196);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(31, 243);
            labelName.Name = "labelName";
            labelName.Size = new Size(45, 20);
            labelName.TabIndex = 1;
            labelName.Text = "ФИО:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(157, 243);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(173, 27);
            textBoxName.TabIndex = 2;
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(31, 284);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(67, 20);
            labelAge.TabIndex = 3;
            labelAge.Text = "Возраст:";
            // 
            // numericAge
            // 
            numericAge.Location = new Point(157, 282);
            numericAge.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numericAge.Name = "numericAge";
            numericAge.Size = new Size(173, 27);
            numericAge.TabIndex = 4;
            numericAge.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(31, 330);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(61, 20);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Группа:";
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(157, 323);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(173, 27);
            textBoxGroup.TabIndex = 6;
            // 
            // labelGrade
            // 
            labelGrade.AutoSize = true;
            labelGrade.Location = new Point(31, 366);
            labelGrade.Name = "labelGrade";
            labelGrade.Size = new Size(110, 20);
            labelGrade.TabIndex = 7;
            labelGrade.Text = "Средний балл:";
            // 
            // numericGrade
            // 
            numericGrade.DecimalPlaces = 2;
            numericGrade.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericGrade.Location = new Point(157, 359);
            numericGrade.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericGrade.Name = "numericGrade";
            numericGrade.Size = new Size(173, 27);
            numericGrade.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(27, 423);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(236, 423);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(94, 29);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(683, 248);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(683, 298);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 12;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(432, 482);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(57, 20);
            labelStatus.TabIndex = 13;
            labelStatus.Text = "Готово";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(683, 344);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(94, 29);
            buttonExport.TabIndex = 14;
            buttonExport.Text = "Экспорт";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(683, 392);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(376, 243);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 16;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(507, 241);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(94, 29);
            textBoxSearch.TabIndex = 17;
            textBoxSearch.Text = "Поиск";
            textBoxSearch.UseVisualStyleBackColor = true;
            textBoxSearch.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(textBoxSearch);
            Controls.Add(textBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonExport);
            Controls.Add(labelStatus);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(numericGrade);
            Controls.Add(labelGrade);
            Controls.Add(textBoxGroup);
            Controls.Add(labelGroup);
            Controls.Add(numericAge);
            Controls.Add(labelAge);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа №8 — CRUD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelAge;
        private NumericUpDown numericAge;
        private Label labelGroup;
        private TextBox textBoxGroup;
        private Label labelGrade;
        private NumericUpDown numericGrade;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
        private Label labelStatus;
        private Button buttonExport;
        private Button buttonCancel;
        private TextBox textBox1;
        private Button textBoxSearch;
    }
}
