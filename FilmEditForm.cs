using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FilmEditForm : Form
    {
        private readonly SQLiteConnection _connection;
        private readonly int? _filmId;
        private DataTable _allGenres;
        public FilmEditForm(SQLiteConnection connection, int? filmId = null)
        {
            InitializeComponent();
            _connection = connection;
            _filmId = filmId;

            LoadAllGenres();

            if (_filmId.HasValue)
            {
                this.Text = "Редактировать";
                btnSave.Text = "Сохранить";
                LoadFilmData();
            }
        }
        private void LoadAllGenres()
        {
            try
            {
                _allGenres = new DataTable();
                string query = "SELECT id_genre, Название FROM Genre";
                using (var adapter = new SQLiteDataAdapter(query, _connection))
                {
                    adapter.Fill(_allGenres);
                }

                // Настраиваем CheckedComboBox
                cmbGenre.Items.Clear();
                foreach (DataRow row in _allGenres.Rows)
                {
                    cmbGenre.Items.Add(row["Название"].ToString(), false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки жанров: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFilmData()
        {
            try
            {
                string query = "SELECT * FROM Movie WHERE id_kino = @id";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@id", _filmId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NameFilm.Text = reader["Название"].ToString();
                            Director.Text = reader["Режиссёр"].ToString();
                            NumYear.Value = Convert.ToInt32(reader["Год_выпуска"]);
                        }
                    }
                }
                query = @"SELECT Genre.id_genre, Genre.Название 
                             FROM MovieGenre 
                             INNER JOIN Genre ON MovieGenre.Mgenre =Genre.id_genre
                             WHERE MovieGenre.Gkino = @filmId";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@filmId", _filmId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string genreName = reader["Название"].ToString();
                            int index = cmbGenre.Items.IndexOf(genreName);
                            if (index >= 0)
                            {
                                cmbGenre.SetItemChecked(index, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных фильма: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(NameFilm.Text))
            {
                MessageBox.Show("Введите название фильма!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameFilm.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(Director.Text))
            {
                MessageBox.Show("Введите режиссёра!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Director.Focus();
                return false;
            }

            if (cmbGenre.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один жанр!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool CheckForDuplicateFilm()
        {
            string query = @"SELECT COUNT(*) FROM Movie 
                           WHERE Название = @title 
                           AND Режиссёр = @director 
                           AND Год_выпуска = @year
                           AND id_kino != @id";

            using (var cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@title", NameFilm.Text.Trim());
                cmd.Parameters.AddWithValue("@director", Director.Text.Trim());
                cmd.Parameters.AddWithValue("@year", (int)NumYear.Value);
                cmd.Parameters.AddWithValue("@id", _filmId ?? -1); // Если _filmId null, используем -1

                int duplicateCount = Convert.ToInt32(cmd.ExecuteScalar());
                if (duplicateCount > 0)
                {
                    MessageBox.Show("Фильм с такими данными уже существует!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            return false;
        }
        private void SaveFilmData()
        {
            try
            {
                // Сохраняем основную информацию о фильме
                string query;
                if (_filmId.HasValue)
                {
                    query = @"UPDATE Movie SET 
                            Название = @title,
                            Режиссёр = @director,
                            Год_выпуска = @year
                            WHERE id_kino = @id";
                }
                else
                {
                    query = @"INSERT INTO Movie (Название, Режиссёр, Год_выпуска)
                            VALUES (@title, @director, @year);
                        SELECT last_insert_rowid();";
                }

                int filmId;
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@title", NameFilm.Text.Trim());
                    cmd.Parameters.AddWithValue("@director", Director.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", (int)NumYear.Value);

                    if (_filmId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@id", _filmId.Value);
                        cmd.ExecuteNonQuery();
                        filmId = _filmId.Value;
                    }
                    else
                    {
                        filmId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                // Удаляем старые связи с жанрами (для режима редактирования)
                if (_filmId.HasValue)
                {
                    query = "DELETE FROM MovieGenre WHERE Gkino = @filmId";
                    using (var cmd = new SQLiteCommand(query, _connection))
                    {
                        cmd.Parameters.AddWithValue("@filmId", filmId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Добавляем новые связи с жанрами
                query = "INSERT INTO MovieGenre (Mgenre, Gkino) VALUES (@genreId, @filmId)";
                foreach (var checkedItem in cmbGenre.CheckedItems)
                {
                    string genreName = checkedItem.ToString();
                    var genreRow = _allGenres.Select($"Название = '{genreName.Replace("'", "''")}'").FirstOrDefault();

                    if (genreRow != null)
                    {
                        using (var cmd = new SQLiteCommand(query, _connection))
                        {
                            cmd.Parameters.AddWithValue("@genreId", genreRow["id_genre"]);
                            cmd.Parameters.AddWithValue("@filmId", filmId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Данные сохранены успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (CheckForDuplicateFilm()) return;

            SaveFilmData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
