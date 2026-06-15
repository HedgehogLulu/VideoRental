using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class GenreForm : Form
    {
        private AdminPanel adminPanel;
        private DataTable dataTable;

        public GenreForm(AdminPanel admin)
        {
            InitializeComponent();
            adminPanel = admin;
            this.FormClosing += GenreForm_FormClosing;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            this.Close();
        }

        private void GenreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminPanel.Show();
        }

        private void GenreForm_Load(object sender, EventArgs e)
        {
            LoadGenres();
        }
        private void LoadGenres()
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query = "SELECT id_genre, Название FROM Genre";
                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["id_genre"].Visible = false;
                        dataGridView1.AutoResizeColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddGenre_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                bool hasErrors = false;
                List<string> addedGenres = new List<string>();

                using (var connection = DbConnection.GetConnection())
                {
                    // Сначала проверяем все данные
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.RowState == DataRowState.Added && row["Название"] != DBNull.Value)
                        {
                            string genreName = row["Название"].ToString();

                            if (string.IsNullOrWhiteSpace(genreName))
                            {
                                MessageBox.Show("Название жанра не может быть пустым!");
                                hasErrors = true;
                                continue;
                            }

                            if (genreName.Length > 0 && !char.IsUpper(genreName[0]))
                            {
                                MessageBox.Show("Название жанра должно начинаться с заглавной буквы!");
                                hasErrors = true;
                                continue;
                            }

                            addedGenres.Add(genreName);
                        }
                    }

                    // Если есть ошибки валидации - очищаем
                    if (hasErrors)
                    {
                        dataTable.RejectChanges();
                        LoadGenres();
                        return;
                    }

                    // Пытаемся добавить жанры
                    foreach (string genreName in addedGenres)
                    {
                        string insertQuery = "INSERT INTO Genre (Название) VALUES (@name)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", genreName);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены!");
                    LoadGenres(); // Обновляем данные после успешного добавления
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataTable.RejectChanges();
            }
        }

        private void UpdateGenre_Click(object sender, EventArgs e)
        {
            // Проверяем выделенную строку
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Выберите жанр для обновления");
                return;
            }

            // Получаем данные из выделенной строки
            var row = dataGridView1.CurrentRow;
            var genreId = row.Cells["id_genre"].Value;
            var newName = row.Cells["Название"].Value?.ToString().Trim();

            // Проверяем название
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Введите название жанра");
                return;
            }

            try
            {
                using (var connection = DbConnection.GetConnection())
                { 
                  // Проверка на дубликат
                    string checkQuery = "SELECT COUNT(*) FROM Genre WHERE Название = @name AND id_genre != @id";
                    using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@name", newName);
                        checkCmd.Parameters.AddWithValue("@id", genreId);

                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Жанр с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataTable.RejectChanges();
                        }
                    }

                    // Обновляем запись (используем новое соединение, т.к. предыдущее закрылось)
                    string updateQuery = "UPDATE Genre SET Название = @name WHERE id_genre = @id";
                    using (var updateCmd = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@name", newName);
                        updateCmd.Parameters.AddWithValue("@id", genreId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно обновлены!");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить данные. Возможно, запись не найдена.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        private void DeleteGenre_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите жанры для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        var genreId = row.Cells["id_genre"].Value;
                        if (genreId == null) continue;

                        string deleteQuery = "DELETE FROM Genre WHERE id_genre = @id";
                        using (var cmd = new SQLiteCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", genreId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                LoadGenres(); // Обновляем DataGridView
                MessageBox.Show("Жанр(ы) успешно удален(ы)!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
