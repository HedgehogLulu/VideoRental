using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace CourseWork
{
    public partial class FilmForm : Form
    {
        private AdminPanel adminPanel;
        private DataTable dataTable;

        public FilmForm(AdminPanel admin)
        {
            InitializeComponent();
            adminPanel = admin;
            this.FormClosing += FilmForm_FormClosing;
            // Настройка событий для ADGV
            advancedDataGridView1.SortStringChanged += advancedDataGridView1_SortStringChanged;
            advancedDataGridView1.FilterStringChanged += advancedDataGridView1_FilterStringChanged;
        }

        private void FilmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminPanel.Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            this.Close();
        }

        private void AddFilm_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                FilmEditForm filmEdit = new FilmEditForm(connection);
                filmEdit.ShowDialog();
            }
            LoadFilm();
        }

        private void UpdateFilm_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите фильм для редактирования!");
                return;
            }
            int filmId = Convert.ToInt32(advancedDataGridView1.SelectedRows[0].Cells["id_kino"].Value);
            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                FilmEditForm filmEdit = new FilmEditForm(connection, filmId);
                filmEdit.ShowDialog();
            }
            LoadFilm();
        }

        private void FilmForm_Load(object sender, EventArgs e)
        {
            LoadFilm();
            // Настройка сортировки для всех столбцов
            foreach (DataGridViewColumn column in advancedDataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        private void LoadFilm()
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    // Измененный запрос с добавлением информации о жанрах
                    string query = @"SELECT Movie.id_kino, Movie.Название, Movie.Режиссёр, Movie.Год_выпуска, 
                           GROUP_CONCAT(Genre.Название, ', ') AS Жанры
                           FROM Movie 
                           LEFT JOIN MovieGenre ON Movie.id_kino = MovieGenre.Gkino
                           LEFT JOIN Genre ON MovieGenre.Mgenre = Genre.id_genre
                           GROUP BY Movie.id_kino, Movie.Название, Movie.Режиссёр, Movie.Год_выпуска";
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

        private void DeleteFilm_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите фильм(ы) для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    foreach (DataGridViewRow row in advancedDataGridView1.SelectedRows)
                    {
                        var clientId = row.Cells["id_kino"].Value;
                        if (clientId == null) continue;

                        string deleteQuery = "DELETE FROM  Movie WHERE id_kino = @id";
                        using (var cmd = new SQLiteCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", clientId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadFilm(); // Обновляем DataGridView
                    MessageBox.Show("Фильм(ы) удален(ы)!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSearch_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = string.Empty; // Сбрасываем фильтр
            }
            LoadFilm();
        }

        private void Source_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadFilm(); // Если строка поиска пуста, показываем все фильмы
                return;
            }

            try
            {
                if (dataTable == null)
                {
                    LoadFilm();
                }

                // Если введены только цифры - ищем в ID и годе выпуска
                if (searchText.All(char.IsDigit))
                {
                    if (int.TryParse(searchText, out int searchId))
                    {
                        string query = @"SELECT Movie.id_kino, Movie.Название, Movie.Режиссёр, Movie.Год_выпуска, 
                                GROUP_CONCAT(Genre.Название, ', ') AS Жанры
                                FROM Movie 
                                LEFT JOIN MovieGenre ON Movie.id_kino = MovieGenre.Gkino
                                LEFT JOIN Genre ON MovieGenre.Mgenre = Genre.id_genre
                                WHERE Movie.id_kino = @id OR CAST(Movie.Год_выпуска AS TEXT) LIKE @year
                                GROUP BY Movie.id_kino, Movie.Название, Movie.Режиссёр, Movie.Год_выпуска
                                ORDER BY 
                                    CASE WHEN Movie.id_kino = @id THEN 0 ELSE 1 END,
                                    Movie.Название";

                        using (var connection = DbConnection.GetConnection())
                        {
                            using (var cmd = new SQLiteCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@id", searchId);
                                cmd.Parameters.AddWithValue("@year", $"%{searchText}%");
                                var adapter = new SQLiteDataAdapter(cmd);
                                var searchTable = new DataTable();
                                adapter.Fill(searchTable);
                                advancedDataGridView1.DataSource = searchTable;
                            }
                        }
                    }
                    else
                    {
                        string query = @"SELECT Movie.id_kino, Movie.Название, Movie.Режиссёр, Movie.Год_выпуска, 
                                GROUP_CONCAT(Genre.Название, ', ') AS Жанры
                                FROM Movie 
                                LEFT JOIN MovieGenre ON Movie.id_kino = MovieGenre.Gkino
                                LEFT JOIN Genre ON MovieGenre.Mgenre = Genre.id_genre
                                WHERE CAST(Movie.Год_выпуска AS TEXT) LIKE @year
                                GROUP BY Movie.id_kino, Movie.Название, Movie.Режиссёр, Movie.Год_выпуска
                                ORDER BY Movie.Год_выпуска";

                        using (var connection = DbConnection.GetConnection())
                        {
                            using (var cmd = new SQLiteCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@year", $"%{searchText}%");
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
                    dataTable.DefaultView.RowFilter = $@"[Название] LIKE '%{searchText}%' OR 
                                                [Режиссёр] LIKE '%{searchText}%' OR 
                                                [Жанры] LIKE '%{searchText}%'";

                    if (dataTable.DefaultView.Count == 0)
                    {
                        MessageBox.Show("Фильмы не найдены", "Результат поиска",
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
                LoadFilm();
            }
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