using System;
using System.Drawing;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork
{
    public partial class DisckManagementForm : Form
    {
        private AdminPanel adminPanel;
        private DataTable dataTable;
        private int? currentDisckId = null;
        private DataTable moviesDataTable;

        public DisckManagementForm(AdminPanel admin)
        {
            InitializeComponent();
            adminPanel = admin;
            this.FormClosing += DisckManagementForm_FormClosing;

            // Настройка событий для ADGV
            advancedDataGridView1.SortStringChanged += advancedDataGridView1_SortStringChanged;
            advancedDataGridView1.FilterStringChanged += advancedDataGridView1_FilterStringChanged;
            advancedDataGridView2.SortStringChanged += advancedDataGridView2_SortStringChanged;
            advancedDataGridView2.FilterStringChanged += advancedDataGridView2_FilterStringChanged;

            advancedDataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
            advancedDataGridView1.SelectionChanged += AdvancedDataGridView1_SelectionChanged;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void DisckManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminPanel.Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            this.Close();
        }

        private void AddDisck_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                DisckInfoForm disckInfo = new DisckInfoForm(connection);
                disckInfo.ShowDialog();
            }
            LoadDisck();
        }
        private void LoadDisck()
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query = @"SELECT d.id_disck, d.серийный_номер, d.статус, d.состояние, 
                                   d.кол_во_копий, d.Цена, t.Название AS Тип_носителя
                                   FROM Disck d
                                   JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype";
                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataTable.Columns["id_disck"].ColumnName = "ID";
                        dataTable.Columns["серийный_номер"].ColumnName = "Серийный номер";
                        dataTable.Columns["статус"].ColumnName = "Статус";
                        dataTable.Columns["состояние"].ColumnName = "Состояние";
                        dataTable.Columns["кол_во_копий"].ColumnName = "Копии";
                        dataTable.Columns["Тип_носителя"].ColumnName = "Тип";
                        advancedDataGridView1.DataSource = dataTable;
                        advancedDataGridView1.AutoResizeColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisckManagementForm_Load(object sender, EventArgs e)
        {
            LoadDisck();
            // Настройка сортировки для всех столбцов
            foreach (DataGridViewColumn column in advancedDataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            foreach (DataGridViewColumn column in advancedDataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

        }

        private void btUptateDisck_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите носитель для редактирования!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int disckId = Convert.ToInt32(advancedDataGridView1.SelectedRows[0].Cells["ID"].Value);
            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                DisckInfoForm disckInfo = new DisckInfoForm(connection, disckId);
                disckInfo.ShowDialog();

                LoadDisck(); // Обновляем список после редактирования
            }
        }
        private void LoadDiscsForMoviesTab()
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query = @"SELECT d.id_disck, d.серийный_номер, t.Название AS Тип_носителя, 
                           d.кол_во_фильмов, 
                           (SELECT GROUP_CONCAT(m.Название, ', ') 
                            FROM DisckMovie dm 
                            JOIN Movie m ON dm.id_фильма = m.id_kino 
                            WHERE dm.id_носителя = d.id_disck) AS Фильмы
                           FROM Disck d
                           JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        moviesDataTable = new DataTable(); 
                        adapter.Fill(moviesDataTable);
                        moviesDataTable.Columns["id_disck"].ColumnName = "ID";
                        moviesDataTable.Columns["серийный_номер"].ColumnName = "Серийный номер";
                        moviesDataTable.Columns["Тип_носителя"].ColumnName = "Тип";
                        moviesDataTable.Columns["кол_во_фильмов"].ColumnName = "Кол-во фильмов";
                        moviesDataTable.Columns["Фильмы"].ColumnName = "Список фильмов";
                        advancedDataGridView2.DataSource = moviesDataTable;
                        advancedDataGridView2.AutoResizeColumns(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int> GetCurrentMoviesOnDisc(int discId)
        {
            List<int> currentMovies = new List<int>();

            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query = "SELECT id_фильма FROM DisckMovie WHERE id_носителя = @discId";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@discId", discId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currentMovies.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения текущих фильмов: " + ex.Message, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return currentMovies;
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (advancedDataGridView2.SelectedRows.Count > 0)
            {
                currentDisckId = Convert.ToInt32(advancedDataGridView2.SelectedRows[0].Cells["ID"].Value);
            }
        }
        private void btnUpdateFilm_Click(object sender, EventArgs e)
        {
            if (currentDisckId == null)
            {
                MessageBox.Show("Выберите носитель из таблицы!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем текущие фильмы на носителе
            List<int> currentMovies = GetCurrentMoviesOnDisc(currentDisckId.Value);

            using (var connection = DbConnection.GetConnection())
            {
                var movieSelectionForm = new MovieSelectionForm(connection, currentMovies);
                if (movieSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Удаляем старые фильмы
                        string deleteQuery = "DELETE FROM DisckMovie WHERE id_носителя = @discId";
                        using (var cmd = new SQLiteCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@discId", currentDisckId);
                            cmd.ExecuteNonQuery();
                        }

                        // Добавляем новые фильмы
                        foreach (int movieId in movieSelectionForm.SelectedMovieIds)
                        {
                            string insertQuery = @"INSERT INTO DisckMovie (id_фильма, id_носителя) 
                                      VALUES (@movieId, @discId)";
                            using (var cmd = new SQLiteCommand(insertQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@movieId", movieId);
                                cmd.Parameters.AddWithValue("@discId", currentDisckId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Обновляем количество фильмов
                        string updateQuery = @"UPDATE Disck 
                                   SET кол_во_фильмов = @count
                                   WHERE id_disck = @discId";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@count", movieSelectionForm.SelectedMovieIds.Count);
                            cmd.Parameters.AddWithValue("@discId", currentDisckId);
                            cmd.ExecuteNonQuery();
                        }

                        LoadDiscsForMoviesTab();
                        LoadMoviesForDisc(currentDisckId.Value);
                        MessageBox.Show("Изменения сохранены!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка сохранения изменений: " + ex.Message, "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabFilm)
            {
                LoadDiscsForMoviesTab();
            }
        }

        private void btnRemoveDisck_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите носитель(и) для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    foreach (DataGridViewRow row in advancedDataGridView1.SelectedRows)
                    {
                        var disckId = row.Cells["ID"].Value;
                        if (disckId == null) continue;

                        string deleteQuery = "DELETE FROM  Disck WHERE id_disck = @id";
                        using (var cmd = new SQLiteCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", disckId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadDisck(); 
                    MessageBox.Show("Носитель(и) удален(ы)!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AdvancedDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count > 0)
            {
                int discId = Convert.ToInt32(advancedDataGridView1.SelectedRows[0].Cells["ID"].Value);
                LoadMoviesForDisc(discId);
            }
        }
        // Метод для загрузки фильмов выбранного носителя
        private void LoadMoviesForDisc(int discId)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query = @"SELECT m.Название AS 'Название фильма'
                          FROM Movie m
                          JOIN DisckMovie dm ON m.id_kino = dm.id_фильма
                          WHERE dm.id_носителя = @discId
                          ORDER BY m.Название";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@discId", discId);

                        var adapter = new SQLiteDataAdapter(cmd);
                        DataTable moviesTable = new DataTable();
                        adapter.Fill(moviesTable);
                        // Настройка отображения
                        dataGridView1.DataSource = moviesTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки фильмов: " + ex.Message, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void FilterMovies(string searchText)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = $"[Название фильма] LIKE '%{searchText}%'";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Если не выбран носитель - ничего не делаем
            if (advancedDataGridView1.SelectedRows.Count == 0) return;

            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // Если поле поиска пустое, загружаем все фильмы для выбранного носителя
                int discId = Convert.ToInt32(advancedDataGridView1.SelectedRows[0].Cells["ID"].Value);
                LoadMoviesForDisc(discId);
            }
            else
            {
                // Если есть текст - фильтруем результаты
                FilterMovies(searchText);
            }
        }

        private void SearchDiscs(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadDisck(); // Если строка поиска пуста, показываем все носители
                return;
            }

            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query;
                    SQLiteCommand cmd;

                    // Если введены только цифры - ищем в ID и серийном номере
                    if (searchText.All(char.IsDigit))
                    {
                        // Пробуем найти по точному ID
                        if (int.TryParse(searchText, out int searchId))
                        {
                            query = @"SELECT d.id_disck AS ID, d.серийный_номер AS 'Серийный номер', d.статус AS Статус, 
                              d.состояние AS Состояние, d.кол_во_копий AS Копии, 
                              d.кол_во_фильмов AS 'Кол-во фильмов', t.Название AS Тип
                              FROM Disck d
                              JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                              WHERE d.id_disck = @id OR d.серийный_номер LIKE @serial
                              ORDER BY 
                                CASE WHEN d.id_disck = @id THEN 0 ELSE 1 END,
                                d.id_disck";

                            cmd = new SQLiteCommand(query, connection);
                            cmd.Parameters.AddWithValue("@id", searchId);
                            cmd.Parameters.AddWithValue("@serial", $"%{searchText}%");
                        }
                        else // Если число слишком большое для ID
                        {
                            query = @"SELECT d.id_disck AS ID, d.серийный_номер AS 'Серийный номер', d.статус AS Статус, 
                              d.состояние AS Состояние, d.кол_во_копий AS Копии, 
                              d.кол_во_фильмов AS 'Кол-во фильмов', t.Название AS Тип
                              FROM Disck d
                              JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                              WHERE d.серийный_номер LIKE @serial
                              ORDER BY d.id_disck";

                            cmd = new SQLiteCommand(query, connection);
                            cmd.Parameters.AddWithValue("@serial", $"%{searchText}%");
                        }

                        var adapter = new SQLiteDataAdapter(cmd);
                        var searchTable = new DataTable();
                        adapter.Fill(searchTable);

                        if (searchTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Носители не найдены", "Результат поиска",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        advancedDataGridView1.DataSource = searchTable;
                    }
                    else // Если введен текст с буквами - используем RowFilter
                    {
                        // Убедимся, что dataTable загружена
                        if (dataTable == null)
                        {
                            LoadDisck();
                        }

                        // Применяем фильтр к существующей таблице
                        dataTable.DefaultView.RowFilter = $@"[Серийный номер] LIKE '%{searchText}%' OR 
                                                    [Статус] LIKE '%{searchText}%' OR 
                                                    [Состояние] LIKE '%{searchText}%' OR 
                                                    [Тип] LIKE '%{searchText}%'";

                        if (dataTable.DefaultView.Count == 0)
                        {
                            MessageBox.Show("Носители не найдены", "Результат поиска",
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDisck();
            }
        }
        private void SearchDiscsWithMovies(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadDiscsForMoviesTab(); // Если строка поиска пуста, показываем все носители
                return;
            }

            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    string query;
                    SQLiteCommand cmd;

                    // Если введены только цифры - ищем в ID и серийном номере
                    if (searchText.All(char.IsDigit))
                    {
                        // Пробуем найти по точному ID
                        if (int.TryParse(searchText, out int searchId))
                        {
                            query = @"SELECT d.id_disck AS ID, d.серийный_номер AS 'Серийный номер', 
                              t.Название AS Тип, d.кол_во_фильмов AS 'Кол-во фильмов',
                              (SELECT GROUP_CONCAT(m.Название, ', ') 
                               FROM DisckMovie dm 
                               JOIN Movie m ON dm.id_фильма = m.id_kino 
                               WHERE dm.id_носителя = d.id_disck) AS 'Список фильмов'
                              FROM Disck d
                              JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                              WHERE d.id_disck = @id OR d.серийный_номер LIKE @serial
                              ORDER BY 
                                CASE WHEN d.id_disck = @id THEN 0 ELSE 1 END,
                                d.id_disck";

                            cmd = new SQLiteCommand(query, connection);
                            cmd.Parameters.AddWithValue("@id", searchId);
                            cmd.Parameters.AddWithValue("@serial", $"%{searchText}%");
                        }
                        else // Если число слишком большое для ID
                        {
                            query = @"SELECT d.id_disck AS ID, d.серийный_номер AS 'Серийный номер', 
                              t.Название AS Тип, d.кол_во_фильмов AS 'Кол-во фильмов',
                              (SELECT GROUP_CONCAT(m.Название, ', ') 
                               FROM DisckMovie dm 
                               JOIN Movie m ON dm.id_фильма = m.id_kino 
                               WHERE dm.id_носителя = d.id_disck) AS 'Список фильмов'
                              FROM Disck d
                              JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                              WHERE d.серийный_номер LIKE @serial
                              ORDER BY d.id_disck";

                            cmd = new SQLiteCommand(query, connection);
                            cmd.Parameters.AddWithValue("@serial", $"%{searchText}%");
                        }

                        var adapter = new SQLiteDataAdapter(cmd);
                        var searchTable = new DataTable();
                        adapter.Fill(searchTable);

                        if (searchTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Носители с фильмами не найдены", "Результат поиска",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        advancedDataGridView2.DataSource = searchTable;
                    }
                    else // Если введен текст с буквами - используем RowFilter
                    {
                        // Убедимся, что moviesDataTable загружена
                        if (moviesDataTable == null)
                        {
                            LoadDiscsForMoviesTab();
                        }

                        // Применяем фильтр к существующей таблице
                        moviesDataTable.DefaultView.RowFilter = $@"[Серийный номер] LIKE '%{searchText}%' OR 
                                                          [Тип] LIKE '%{searchText}%' OR 
                                                          [Список фильмов] LIKE '%{searchText}%'";

                        if (moviesDataTable.DefaultView.Count == 0)
                        {
                            MessageBox.Show("Носители с фильмами не найдены", "Результат поиска",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            moviesDataTable.DefaultView.RowFilter = string.Empty; // Сбрасываем фильтр
                            return;
                        }

                        advancedDataGridView2.DataSource = moviesDataTable.DefaultView;
                    }

                        // Подсветка найденных результатов
                        foreach (DataGridViewRow row in advancedDataGridView2.Rows)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDiscsForMoviesTab();
            }
        }
        private void Source_Click(object sender, EventArgs e)
        {
            string searchText = textBox2.Text.Trim();

            if (tabControl1.SelectedTab == tabInfo)
            {
                SearchDiscs(searchText); // Поиск на вкладке "Носитель"
            }
            else if (tabControl1.SelectedTab == tabFilm)
            {
                SearchDiscsWithMovies(searchText); // Поиск на вкладке "Фильмы"
            }
        }

        private void ResetSearch_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            if (tabControl1.SelectedTab == tabInfo)
            {
                LoadDisck();
                if (dataTable != null)
                {
                    dataTable.DefaultView.RowFilter = string.Empty; // Сбрасываем фильтр
                }
                // Сброс подсветки для вкладки "Носитель"
                foreach (DataGridViewRow row in advancedDataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            else if (tabControl1.SelectedTab == tabFilm)
            {
                LoadDiscsForMoviesTab();
                if (moviesDataTable != null)
                {
                    moviesDataTable.DefaultView.RowFilter = string.Empty; // Сбрасываем фильтр
                }
                // Сброс подсветки для вкладки "Фильмы"
                foreach (DataGridViewRow row in advancedDataGridView2.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
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

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            // Применяем фильтр к текущим данным
            if (advancedDataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = advancedDataGridView1.FilterString;
            }
        }

        private void advancedDataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            // Применяем фильтр к текущим данным
            if (advancedDataGridView2.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = advancedDataGridView2.FilterString;
            }
        }

        private void advancedDataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            // Применяем сортировку к текущей таблице данных
            if (advancedDataGridView2.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.Sort = advancedDataGridView2.SortString;
            }
        }
    }
}
