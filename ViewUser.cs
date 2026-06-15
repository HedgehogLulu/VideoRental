using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class ViewUser : Form
    {
        private AdminPanel adminPanel;
        private DataTable dataTable;

        public ViewUser(AdminPanel admin)
        {
            InitializeComponent();
            adminPanel = admin;
            this.FormClosing += ViewUser_FormClosing;

            // Настройка событий для ADGV
            advancedDataGridView1.SortStringChanged += advancedDataGridView1_SortStringChanged;
            advancedDataGridView1.FilterStringChanged += advancedDataGridView1_FilterStringChanged;

        }

        private void Back_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            this.Close();
        }

        private void ViewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminPanel.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                AddUserForm addForm = new AddUserForm(connection);
                addForm.ShowDialog();
            }
            // Обновляем данные после закрытия формы редактирования
            LoadUsers();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования!");
                return;
            }

            // Получаем ID выбранного клиента
            int clientId = Convert.ToInt32(advancedDataGridView1.SelectedRows[0].Cells["id_client"].Value);

            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                // Передаем ID в конструктор для режима редактирования
                AddUserForm addForm = new AddUserForm(connection, clientId);
                addForm.ShowDialog();

                // Обновляем данные после закрытия формы редактирования
                LoadUsers();
            }
        }
        private void ViewUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
            // Настройка сортировки для всех столбцов
            foreach (DataGridViewColumn column in advancedDataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        private void LoadUsers()
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query = "SELECT * FROM Client";
                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        advancedDataGridView1.DataSource = dataTable;
                        advancedDataGridView1.AutoResizeColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиентов для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    foreach (DataGridViewRow row in advancedDataGridView1.SelectedRows)
                    {
                        var clientId = row.Cells["id_client"].Value;
                        if (clientId == null) continue;

                        string deleteQuery = "DELETE FROM Client WHERE id_client = @id";
                        using (var cmd = new SQLiteCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", clientId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadUsers(); // Обновляем DataGridView
                    MessageBox.Show("Клиент(ы) удален(ы)!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Source_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadUsers(); // Если строка поиска пуста, показываем всех пользователей
                return;
            }

            try
            {
                
                if (dataTable == null)
                {
                    LoadUsers();
                }

                // Если введены только цифры - ищем в ID и телефоне
                if (searchText.All(char.IsDigit))
                {
                    if (int.TryParse(searchText, out int searchId))
                    {
                        string query = @"SELECT id_client, Фамилия, Имя, Отчество, Моб_телефон 
                                FROM Client 
                                WHERE id_client = @id OR Моб_телефон LIKE @phone
                                ORDER BY 
                                    CASE WHEN id_client = @id THEN 0 ELSE 1 END,
                                    id_client";

                        using (var connection = DbConnection.GetConnection())
                        {
                            using (var cmd = new SQLiteCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@id", searchId);
                                cmd.Parameters.AddWithValue("@phone", $"%{searchText}%");
                                var adapter = new SQLiteDataAdapter(cmd);
                                var searchTable = new DataTable();
                                adapter.Fill(searchTable);
                                advancedDataGridView1.DataSource = searchTable;
                            }
                        }
                    }
                    else
                    {
                        string query = @"SELECT id_client, Фамилия, Имя, Отчество, Моб_телефон 
                                FROM Client 
                                WHERE Моб_телефон LIKE @phone
                                ORDER BY id_client";

                        using (var connection = DbConnection.GetConnection())
                        {
                            using (var cmd = new SQLiteCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@phone", $"%{searchText}%");
                                var adapter = new SQLiteDataAdapter(cmd);
                                var searchTable = new DataTable();
                                adapter.Fill(searchTable);
                                advancedDataGridView1.DataSource = searchTable;
                            }
                        }
                    }
                }
                else // Если введен текст с буквами -  RowFilter
                {
                    dataTable.DefaultView.RowFilter = $@"[Фамилия] LIKE '%{searchText}%' OR 
                                                [Имя] LIKE '%{searchText}%' OR 
                                                [Отчество] LIKE '%{searchText}%'";

                    if (dataTable.DefaultView.Count == 0)
                    {
                        MessageBox.Show("Клиенты не найдены", "Результат поиска",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataTable.DefaultView.RowFilter = string.Empty; // Сбрасываем фильтр
                        return;
                    }

                    advancedDataGridView1.DataSource = dataTable.DefaultView;
                }

                // Подсветка найденных результатов
                foreach (DataGridViewRow row in advancedDataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null &&
                            cell.Value.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            cell.Style.BackColor = Color.LightYellow;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadUsers();
            }
        }

        private void ResetSearch_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = string.Empty; // Сбрасываем фильтр
            }
            LoadUsers();
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            // Применяем фильтр к текущим данным
            if (advancedDataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = advancedDataGridView1.FilterString;
            }
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            // Применяем сортировку к текущей таблице данных
            if (advancedDataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.Sort = advancedDataGridView1.SortString;
            }
        }
    }
}
