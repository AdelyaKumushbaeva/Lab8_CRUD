using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Lab8_CRUD
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=ADELLE\MSSQLSERVERR;Database=StudentDB;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }


        // 1. ЗАГРУЗКА ДАННЫХ И СЧЕТЧИК

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Students";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewStudents.DataSource = table;

                    // Счётчик студентов в статус-баре
                    labelStatus.Text = "Всего студентов: " + table.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        // Выбор строки (подстановка данных в текстовые поля)
        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow != null && dataGridViewStudents.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dataGridViewStudents.CurrentRow;

                textBoxName.Text = row.Cells["FullName"].Value?.ToString();

                if (row.Cells["Age"].Value != DBNull.Value && row.Cells["Age"].Value != null)
                    numericAge.Value = Convert.ToDecimal(row.Cells["Age"].Value);

                textBoxGroup.Text = row.Cells["GroupName"].Value?.ToString();

                if (row.Cells["AverageGrade"].Value != DBNull.Value && row.Cells["AverageGrade"].Value != null)
                    numericGrade.Value = Convert.ToDecimal(row.Cells["AverageGrade"].Value);
            }
        }


        // 2. ДОБАВЛЕНИЕ (CREATE)

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите ФИО студента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkSql = "SELECT COUNT(*) FROM Students WHERE FullName = @name";
                    SqlCommand checkCmd = new SqlCommand(checkSql, connection);
                    checkCmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Студент с таким ФИО уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string sql = "INSERT INTO Students (FullName, Age, GroupName, AverageGrade) VALUES (@name, @age, @group, @grade)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text);
                    cmd.Parameters.AddWithValue("@grade", numericGrade.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Студент успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }


        // 3. ОБНОВЛЕНИЕ (UPDATE) 

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента из таблицы для обновления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int id = Convert.ToInt32(dataGridViewStudents.CurrentRow.Cells["Id"].Value);

                    string sql = "UPDATE Students SET FullName = @name, Age = @age, GroupName = @group, AverageGrade = @grade WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text);
                    cmd.Parameters.AddWithValue("@grade", numericGrade.Value);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }


        // 4. УДАЛЕНИЕ (DELETE)

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этого студента?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        int id = Convert.ToInt32(dataGridViewStudents.CurrentRow.Cells["Id"].Value);

                        string sql = "DELETE FROM Students WHERE Id = @id";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Студент удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }


        // 5. ОЧИСТКА ПОЛЕЙ

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            textBoxName.Clear();
            numericAge.Value = 15;
            textBoxGroup.Clear();
            numericGrade.Value = 0;
        }


        // 6. САМОСТОЯТЕЛЬНАЯ РАБОТА: ЭКСПОРТ В CSV

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV файл (разделитель - точка с запятой)|*.csv";
            sfd.FileName = "Студенты.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        for (int i = 0; i < dataGridViewStudents.Columns.Count; i++)
                        {
                            sw.Write(dataGridViewStudents.Columns[i].HeaderText);
                            if (i < dataGridViewStudents.Columns.Count - 1) sw.Write(";");
                        }
                        sw.WriteLine();

                        for (int i = 0; i < dataGridViewStudents.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridViewStudents.Columns.Count; j++)
                            {
                                sw.Write(dataGridViewStudents.Rows[i].Cells[j].Value?.ToString());
                                if (j < dataGridViewStudents.Columns.Count - 1) sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Экспорт в CSV успешно завершен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте: " + ex.Message);
                }
            }
        }


        // 7. САМОСТОЯТЕЛЬНАЯ РАБОТА: ОТМЕНА (ПЕРЕЗАГРУЗКА)
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
            MessageBox.Show("Действие отменено, данные обновлены.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                LoadData(); // Если поле пустое, показываем всех
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Students WHERE FullName LIKE @search";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewStudents.DataSource = table;
                    labelStatus.Text = "Найдено студентов: " + table.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message);
            }
        }
    }
}