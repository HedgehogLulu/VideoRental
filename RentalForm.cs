using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class RentalForm : Form
    {
        private AdminPanel adminPanel;
        private readonly SQLiteConnection _connection;
        private DataTable _allMovies;
        private DataTable _filteredMovies;
        private DataTable _allGenres;
        private DataTable _allClients;
        private bool _isUpdating;
        private int? _selectedMovieId = null;
        private string _selectedMovieText = null;
        private bool _isSelectingFromList = false;

        public RentalForm(AdminPanel admin)
        {
            InitializeComponent();
            this.adminPanel = admin;
            this.FormClosing += RentalForm_FormClosing;

            _connection = DbConnection.GetConnection();

            LoadAllGenres();
            LoadClients();
            LoadAllMovies();
            LoadActiveRentals();
            LoadFineRate();
            // Установка текущей даты
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(7);
            // Настройка событий для ADGV
            advancedDataGridView1.SortStringChanged += advancedDataGridView1_SortStringChanged;
            advancedDataGridView1.FilterStringChanged += advancedDataGridView1_FilterStringChanged;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            this.Close();
        }

        private void RentalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminPanel.Show();
        }

        private void LoadClients()
        {
            try
            {
                string query = "SELECT id_client, Фамилия || ' ' || Имя || ' ' || Отчество AS FullName FROM Client";
                _allClients = new DataTable();
                using (var adapter = new SQLiteDataAdapter(query, _connection))
                {
                    adapter.Fill(_allClients);
                }

                comboClient.DataSource = null;
                comboClient.Items.Clear();
                comboClient.Text = "";

                comboClient.DropDown += (s, e) =>
                {
                    if (!_isUpdating && comboClient.DataSource == null)
                    {
                        ShowAllClients();
                    }
                };

                comboClient.TextChanged += (s, e) =>
                {
                    if (_isUpdating) return;

                    string searchText = comboClient.Text;
                    int cursorPos = comboClient.SelectionStart;

                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        comboClient.DataSource = null;
                        comboClient.Items.Clear();
                        return;
                    }

                    FilterClients(searchText, cursorPos);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAllClients()
        {
            try
            {
                _isUpdating = true;
                comboClient.DataSource = _allClients.Copy();
                comboClient.DisplayMember = "FullName";
                comboClient.ValueMember = "id_client";
                comboClient.SelectedIndex = -1;
            }
            finally
            {
                _isUpdating = false;
            }
        }

        private void FilterClients(string searchText, int cursorPos)
        {
            try
            {
                _isUpdating = true;

                var filtered = _allClients.AsEnumerable()
                    .Where(row => row.Field<string>("FullName").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                comboClient.BeginUpdate();
                comboClient.DataSource = filtered.Any() ? filtered.CopyToDataTable() : null;
                comboClient.DisplayMember = "FullName";
                comboClient.ValueMember = "id_client";
                comboClient.Text = searchText;
                comboClient.SelectionStart = cursorPos;

                if (filtered.Any())
                {
                    comboClient.DroppedDown = true;
                }
            }
            finally
            {
                comboClient.EndUpdate();
                _isUpdating = false;
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

                cmbGenre.Items.Clear();
                cmbGenre.Items.Add("Все жанры", true);
                foreach (DataRow row in _allGenres.Rows)
                {
                    cmbGenre.Items.Add(row["Название"].ToString(), false);
                }

                _isUpdating = true;
                for (int i = 1; i < cmbGenre.Items.Count; i++)
                {
                    cmbGenre.SetItemChecked(i, true);
                }
                _isUpdating = false;

                UpdateGenreDisplayText();
                UpdateMoviesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки жанров: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGenreDisplayText()
        {
            if (_isUpdating) return;

            _isUpdating = true;

            bool allChecked = true;
            for (int i = 1; i < cmbGenre.Items.Count; i++)
            {
                if (!cmbGenre.GetItemChecked(i))
                {
                    allChecked = false;
                    break;
                }
            }

            if (allChecked)
            {
                cmbGenre.SetItemChecked(0, true);
                cmbGenre.Text = "Все жанры";
            }
            else
            {
                var selectedGenres = new List<string>();
                for (int i = 1; i < cmbGenre.Items.Count; i++)
                {
                    if (cmbGenre.GetItemChecked(i))
                    {
                        selectedGenres.Add(cmbGenre.Items[i].ToString());
                    }
                }

                cmbGenre.SetItemChecked(0, false);
                if (selectedGenres.Count == 0)
                {
                    cmbGenre.Text = "Жанры не выбраны";
                }
                else
                {
                    cmbGenre.Text = string.Join(", ", selectedGenres);
                }
            }

            _isUpdating = false;
        }

        private void cmbGenre_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isUpdating) return;

            _isUpdating = true;

            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < cmbGenre.Items.Count; i++)
                    {
                        cmbGenre.SetItemChecked(i, true);
                    }
                }
                else
                {
                    for (int i = 1; i < cmbGenre.Items.Count; i++)
                    {
                        cmbGenre.SetItemChecked(i, false);
                    }
                }
            }
            _isUpdating = false;

            UpdateGenreDisplayText();
            UpdateMoviesList();
        }

        private void cmbGenre_DropDownClosed(object sender, EventArgs e)
        {
            UpdateGenreDisplayText();
            UpdateMoviesList();
        }

        private void LoadAllMovies()
        {
            try
            {
                // Загружаем только фильмы, у которых есть доступные носители
                string query = @"
            SELECT DISTINCT m.id_kino, m.Название, m.Режиссёр, m.Год_выпуска, 
                   m.Название || ' (' || m.Режиссёр || ', ' || m.Год_выпуска || ')' AS DisplayText
            FROM Movie m
            WHERE EXISTS (
                SELECT 1
                FROM DisckMovie dm
                JOIN Disck d ON dm.id_носителя = d.id_disck
                WHERE dm.id_фильма = m.id_kino
                AND d.статус = 'Доступен' AND d.кол_во_копий > 0
            )
            ORDER BY m.Название";

                _allMovies = new DataTable();
                using (var adapter = new SQLiteDataAdapter(query, _connection))
                {
                    adapter.Fill(_allMovies);
                }

                if (_allMovies.Columns["id_kino"].DataType != typeof(int))
                {
                    DataTable tempTable = new DataTable();
                    tempTable.Columns.Add("id_kino", typeof(int));
                    tempTable.Columns.Add("Название", typeof(string));
                    tempTable.Columns.Add("Режиссёр", typeof(string));
                    tempTable.Columns.Add("Год_выпуска", typeof(int));
                    tempTable.Columns.Add("DisplayText", typeof(string));

                    foreach (DataRow row in _allMovies.Rows)
                    {
                        tempTable.Rows.Add(
                            Convert.ToInt32(row["id_kino"]),
                            row["Название"],
                            row["Режиссёр"],
                            Convert.ToInt32(row["Год_выпуска"]),
                            row["DisplayText"]
                        );
                    }
                    _allMovies = tempTable;
                }

                _filteredMovies = _allMovies.Copy();

                comboMovie.DataSource = null;
                comboMovie.Items.Clear();
                comboMovie.Text = "";
                comboMovie.DropDownStyle = ComboBoxStyle.DropDown;

                comboMovie.DropDown += (s, e) =>
                {
                    if (!_isUpdating)
                    {
                        ShowFilteredMovies();
                    }
                };

                comboMovie.TextChanged += (s, e) =>
                {
                    if (_isUpdating || _isSelectingFromList) return;

                    string searchText = comboMovie.Text;
                    int cursorPos = comboMovie.SelectionStart;

                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        _selectedMovieId = null;
                        _selectedMovieText = null;
                        comboMovie.DataSource = null;
                        comboMovie.Items.Clear();
                        comboDisck.DataSource = null;
                        comboDisck.Items.Clear();
                        comboDisck.Text = "";
                        ShowFilteredMovies();
                        return;
                    }

                    FilterMovies(searchText, cursorPos);
                };

                comboMovie.SelectionChangeCommitted += comboMovie_SelectionChangeCommitted;

                comboMovie.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter && comboMovie.DroppedDown && comboMovie.SelectedIndex != -1)
                    {
                        e.Handled = true;
                        comboMovie_SelectionChangeCommitted(comboMovie, EventArgs.Empty);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки фильмов: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboMovie_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _isUpdating = true;
            _isSelectingFromList = true; // Устанавливаем флаг перед изменением текста
            try
            {
                DataRowView selectedRow = comboMovie.SelectedItem as DataRowView;
                if (selectedRow == null)
                {
                    MessageBox.Show("Выбранный фильм не найден в списке.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = Convert.ToInt32(selectedRow["id_kino"]);
                string selectedText = selectedRow["DisplayText"].ToString();

                _selectedMovieId = selectedId;
                _selectedMovieText = selectedText;

                comboMovie.Text = _selectedMovieText;

                if (_selectedMovieId.HasValue)
                {
                    LoadAvailableDiscsForMovie(_selectedMovieId.Value);
                    if (comboDisck.Items.Count == 0)
                    {
                        MessageBox.Show($"Для фильма '{selectedText}' нет доступных носителей.", "Информация",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе фильма: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboMovie.SelectedIndex = -1;
                comboMovie.Text = "";
                _selectedMovieId = null;
                _selectedMovieText = null;
                comboDisck.DataSource = null;
                comboDisck.Items.Clear();
                comboDisck.Text = "";
            }
            finally
            {
                _isSelectingFromList = false; // Сбрасываем флаг после обработки
                _isUpdating = false;
            }

            UpdateRentButtonState();
        }
        private void ShowFilteredMovies()
        {
            try
            {
                _isUpdating = true;

                if (_filteredMovies == null || _filteredMovies.Rows.Count == 0)
                {
                    comboMovie.DataSource = null;
                    comboMovie.Items.Clear();
                    comboMovie.Text = _selectedMovieText ?? "";
                    comboDisck.DataSource = null;
                    comboDisck.Items.Clear();
                    comboDisck.Text = "";
                    return;
                }

                comboMovie.DataSource = _filteredMovies.Copy();
                comboMovie.DisplayMember = "DisplayText";
                comboMovie.ValueMember = "id_kino";

                if (_selectedMovieId.HasValue && !string.IsNullOrEmpty(_selectedMovieText))
                {
                    comboMovie.Text = _selectedMovieText;
                    comboMovie.SelectedValue = _selectedMovieId;
                }
                else
                {
                    comboMovie.SelectedIndex = -1;
                    comboMovie.Text = "";
                    _selectedMovieText = null;
                }
            }
            finally
            {
                _isUpdating = false;
            }
        }

        private void FilterMovies(string searchText, int cursorPos)
        {
            try
            {
                _isUpdating = true;

                // Пропускаем фильтрацию, если выбор был сделан из списка
                if (_isSelectingFromList)
                {
                    return;
                }

                var filtered = _filteredMovies.AsEnumerable()
                    .Where(row => row.Field<string>("Название").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  row.Field<string>("Режиссёр").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  row["Год_выпуска"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  row.Field<string>("DisplayText").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) // Добавляем проверку по DisplayText
                    .ToList();

                comboMovie.BeginUpdate();
                if (filtered.Any())
                {
                    var filteredTable = filtered.CopyToDataTable();
                    comboMovie.DataSource = filteredTable;
                    comboMovie.DisplayMember = "DisplayText";
                    comboMovie.ValueMember = "id_kino";
                    comboMovie.Text = searchText;
                    comboMovie.SelectionStart = cursorPos;
                    comboMovie.DroppedDown = true;
                }
                else
                {
                    comboMovie.DataSource = null;
                    comboMovie.Items.Clear();
                    comboMovie.Text = searchText;
                    comboMovie.SelectionStart = cursorPos;
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        MessageBox.Show("Фильмы не найдены.", "Информация",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    comboDisck.DataSource = null;
                    comboDisck.Items.Clear();
                    comboDisck.Text = "";
                }
            }
            finally
            {
                comboMovie.EndUpdate();
                _isUpdating = false;
            }
        }

        private void UpdateMoviesList()
        {
            if (_allMovies == null || _allGenres == null) return;

            try
            {
                var selectedGenres = new List<string>();
                for (int i = 1; i < cmbGenre.Items.Count; i++)
                {
                    if (cmbGenre.GetItemChecked(i))
                    {
                        selectedGenres.Add(cmbGenre.Items[i].ToString());
                    }
                }

                DataTable moviesToShow;

                if (cmbGenre.GetItemChecked(0)) // Все жанры
                {
                    moviesToShow = _allMovies.Copy(); // Уже отфильтровано по доступным носителям в LoadAllMovies
                }
                else if (selectedGenres.Count == 0)
                {
                    moviesToShow = _allMovies.Clone(); // Пустая таблица, если жанры не выбраны
                }
                else
                {
                    var genreIds = new List<int>();
                    foreach (DataRow row in _allGenres.Rows)
                    {
                        if (selectedGenres.Contains(row["Название"].ToString()))
                        {
                            genreIds.Add(Convert.ToInt32(row["id_genre"]));
                        }
                    }

                    if (genreIds.Count == 0)
                    {
                        moviesToShow = _allMovies.Clone();
                    }
                    else
                    {
                        // Запрос: фильмы с выбранными жанрами и хотя бы одним доступным носителем
                        string query = $@"
                    SELECT DISTINCT m.id_kino, m.Название, m.Режиссёр, m.Год_выпуска, 
                           m.Название || ' (' || m.Режиссёр || ', ' || m.Год_выпуска || ')' AS DisplayText
                    FROM Movie m
                    INNER JOIN MovieGenre mg ON mg.Gkino = m.id_kino
                    WHERE mg.Mgenre IN ({string.Join(",", genreIds)})
                    AND EXISTS (
                        SELECT 1
                        FROM DisckMovie dm
                        JOIN Disck d ON dm.id_носителя = d.id_disck
                        WHERE dm.id_фильма = m.id_kino
                        AND d.статус = 'Доступен' AND d.кол_во_копий > 0
                    )
                    ORDER BY m.Название";

                        moviesToShow = new DataTable();
                        using (var adapter = new SQLiteDataAdapter(query, _connection))
                        {
                            adapter.Fill(moviesToShow);
                        }
                    }
                }

                // Если нет доступных фильмов, очищаем списки
                if (moviesToShow.Rows.Count == 0)
                {
                    _selectedMovieId = null;
                    _selectedMovieText = null;
                    comboMovie.Text = "";
                    comboDisck.DataSource = null;
                    comboDisck.Items.Clear();
                    comboDisck.Text = "";
                    _filteredMovies = moviesToShow;
                    comboMovie.DataSource = null;
                    comboMovie.Items.Clear();
                    return;
                }

                // Проверка, существует ли выбранный фильм в новом списке
                if (_selectedMovieId.HasValue)
                {
                    var selectedMovieExists = moviesToShow.AsEnumerable()
                        .Any(row => row.Field<int>("id_kino") == _selectedMovieId);
                    if (!selectedMovieExists)
                    {
                        _selectedMovieId = null;
                        _selectedMovieText = null;
                        comboMovie.Text = "";
                        comboDisck.DataSource = null;
                        comboDisck.Items.Clear();
                        comboDisck.Text = "";
                    }
                }

                _filteredMovies = moviesToShow;

                comboMovie.DataSource = null;
                comboMovie.Items.Clear();
                ShowFilteredMovies();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления списка фильмов: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableDiscsForMovie(int movieId)
        {
            try
            {
                string query = @"
            SELECT d.id_disck, 
                   d.серийный_номер || ' (' || t.Название || ')' AS DisplayText,
                   d.Цена AS Price
            FROM Disck d
            JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
            JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
            WHERE dm.id_фильма = @movieId 
            AND d.статус = 'Доступен'
            AND d.кол_во_копий > 0
            ORDER BY d.серийный_номер";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@movieId", movieId);

                    var adapter = new SQLiteDataAdapter(cmd);
                    DataTable discsTable = new DataTable();
                    adapter.Fill(discsTable);

                    comboDisck.DataSource = discsTable;
                    comboDisck.DisplayMember = "DisplayText";
                    comboDisck.ValueMember = "id_disck";
                    comboDisck.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки носителей: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDisck.DataSource = null;
                comboDisck.Items.Clear();
                comboDisck.Text = "";
            }
        }

        private void UpdateRentButtonState()
        {
            btnRent.Enabled = comboClient.SelectedValue != null &&
                             _selectedMovieId.HasValue &&
                             comboDisck.SelectedValue != null;
        }
        // Метод для получения количества доступных копий
        private int GetAvailableCopies(int discId)
        {
            try
            {
                string query = "SELECT кол_во_копий FROM Disck WHERE id_disck = @DiscId";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@DiscId", discId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении количества копий: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка заполнения всех полей
                if (comboClient.SelectedItem == null)
                {
                    MessageBox.Show("Выберите клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboMovie.SelectedItem == null)
                {
                    MessageBox.Show("Выберите фильм!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboDisck.SelectedItem == null)
                {
                    MessageBox.Show("Выберите носитель!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Извлечение данных
                DataRowView clientRow = comboClient.SelectedItem as DataRowView;
                DataRowView discRow = comboDisck.SelectedItem as DataRowView;

                int clientId = Convert.ToInt32(clientRow["id_client"]);
                int discId = Convert.ToInt32(discRow["id_disck"]);
                DateTime issueDate = dateTimePicker1.Value;
                DateTime returnDate = dateTimePicker2.Value;
                decimal cost = Convert.ToDecimal(discRow["Price"]) * (returnDate - issueDate).Days;
                // Проверка, есть ли у клиента активный или просроченный прокат
                if (HasActiveRental(clientId))
                {
                    MessageBox.Show("Этот клиент уже имеет активный или просроченный прокат. Пожалуйста, верните текущий прокат перед оформлением нового.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка доступности копий
                int availableCopies = GetAvailableCopies(discId);
                if (availableCopies <= 0)
                {
                    MessageBox.Show("Нет доступных копий этого носителя!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Определение статуса на основе даты возврата
                string status = returnDate.Date < DateTime.Now.Date ? "Просрочен" : "Активен";

                // Создаём новое соединение
                using (var connection = DbConnection.GetConnection())
                {
                    // Уменьшение количества копий и обновление статуса
                    string updateQuery = @"
                UPDATE Disck 
                SET кол_во_копий = кол_во_копий - 1,
                    статус = CASE WHEN кол_во_копий - 1 = 0 THEN 'В прокате' ELSE 'Доступен' END
                WHERE id_disck = @DiscId";

                    using (var cmd = new SQLiteCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@DiscId", discId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Не удалось обновить количество копий носителя!", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Вставка записи в Rental
                    string insertQuery = @"
                INSERT INTO Rental (стоимость_руб, дата_выдачи, дата_возврата, Клиент, Носитель, статус)
                VALUES (@Cost, @IssueDate, @ReturnDate, @ClientId, @DiscId, @Status)";

                    using (var cmd = new SQLiteCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Cost", cost);
                        cmd.Parameters.AddWithValue("@IssueDate", issueDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ReturnDate", returnDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ClientId", clientId);
                        cmd.Parameters.AddWithValue("@DiscId", discId);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Очистка формы после успешного оформления
                comboClient.SelectedIndex = -1;
                comboMovie.SelectedIndex = -1;
                comboDisck.Items.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now.AddDays(7);

                // Обновление списка активных прокатов
                LoadActiveRentals();
                if (_selectedMovieId.HasValue)
                {
                    LoadAvailableDiscsForMovie(_selectedMovieId.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении проката: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadActiveRentals()
        {
            try
            {
                // обновление просчроенным статусом
                string updateOverdueQuery = @"
            UPDATE Rental
            SET статус = 'Просрочен'
            WHERE дата_возврата < CURRENT_DATE
            AND статус = 'Активен'";

                using (var cmd = new SQLiteCommand(updateOverdueQuery, _connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // загрузка активных и просроченных прокатов
                string query = @"
            SELECT r.id_прокат, 
                   c.Фамилия || ' ' || c.Имя || ' ' || c.Отчество AS Клиент,
                   GROUP_CONCAT(m.Название, ', ') AS Фильмы,
                   d.серийный_номер || ' (' || t.Название || ')' AS Носитель,
                   r.дата_выдачи AS [Дата выдачи],
                   r.дата_возврата AS [Дата возврата],
                   r.стоимость_руб AS Стоимость,
                   r.статус AS Статус
            FROM Rental r
            JOIN Client c ON r.Клиент = c.id_client
            JOIN Disck d ON r.Носитель = d.id_disck
            JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
            JOIN Movie m ON dm.id_фильма = m.id_kino
            JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
            WHERE r.статус IN ('Активен', 'Просрочен')
            GROUP BY r.id_прокат, c.Фамилия, c.Имя, c.Отчество, d.серийный_номер, t.Название, 
                     r.дата_выдачи, r.дата_возврата, r.стоимость_руб, r.статус";

                using (var adapter = new SQLiteDataAdapter(query, _connection))
                {
                    DataTable rentalsTable = new DataTable();
                    adapter.Fill(rentalsTable);
                    advancedDataGridView1.DataSource = rentalsTable;
                }
                UpdateReturnButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки активных прокатов: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRentButtonState();
        }

        private void comboDisck_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRentButtonState();
            CalculateRentalCost();
        }
        private void CalculateRentalCost()
        {
            try
            {
                if (comboDisck.SelectedItem == null)
                {
                    label9.Text = "Выберите носитель";
                    return;
                }

                DataRowView selectedDisc = comboDisck.SelectedItem as DataRowView;
                if (selectedDisc == null)
                {
                    label9.Text = "Ошибка: носитель недоступен";
                    return;
                }

                decimal pricePerDay = Convert.ToDecimal(selectedDisc["Price"]);
                DateTime issueDate = dateTimePicker1.Value;
                DateTime returnDate = dateTimePicker2.Value;

                if (returnDate < issueDate)
                {
                    label9.Text = "Ошибка: дата возврата раньше выдачи";
                    return;
                }

                TimeSpan rentalPeriod = returnDate - issueDate;
                int rentalDays = rentalPeriod.Days;
                if (rentalDays == 0) rentalDays = 1;

                decimal totalCost = pricePerDay * rentalDays;
                label9.Text = $"{totalCost:F2} руб. ({rentalDays} дн.)";
            }
            catch (Exception ex)
            {
                label9.Text = "Ошибка расчета";
                MessageBox.Show($"Ошибка при расчете стоимости: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateRentalCost();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CalculateRentalCost();
        }
        
        private void UpdateReturnButtonState()
        {
            btnReturn.Enabled = advancedDataGridView1.SelectedRows.Count > 0;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (advancedDataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите прокат для возврата!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем ID выбранного проката
                int rentalId = Convert.ToInt32(advancedDataGridView1.SelectedRows[0].Cells["id_прокат"].Value);

                // обновляем дату возврата в таблице Rental
                string updateQuery = @"
                 UPDATE Rental 
                SET дата_фактического_возврата = @CurrentDate,
                статус = 'Завершен'
                 WHERE id_прокат = @RentalId";
                
                string updateDiscQuery = @"
                UPDATE Disck 
                SET кол_во_копий = кол_во_копий + 1,
                статус = CASE WHEN кол_во_копий + 1 > 0 THEN 'Доступен' ELSE 'В прокате' END
                WHERE id_disck = (SELECT Носитель FROM Rental WHERE id_прокат = @RentalId)";

                using (var cmd = new SQLiteCommand(updateDiscQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("@RentalId", rentalId);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SQLiteCommand(updateQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("@RentalId", rentalId);
                    cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now.ToString("yyyy-MM-dd"));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Возврат успешно оформлен!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем список активных прокатов
                        LoadActiveRentals();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось оформить возврат!", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при возврате носителя: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Метод для проверки активных прокатов клиента
        private bool HasActiveRental(int clientId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Rental WHERE Клиент = @ClientId AND статус IN ('Активен', 'Просрочен')";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@ClientId", clientId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке активных прокатов: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        private void RentalForm_Load(object sender, EventArgs e)
        {
            // Настройка сортировки для всех столбцов
            foreach (DataGridViewColumn column in advancedDataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void advancedDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateReturnButtonState();
        }
        private void LoadFineRate()
        {
            try
            {
                string query = "SELECT fine_rate FROM Settings WHERE id = 1";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        numericUpDown1.Value = Convert.ToDecimal(result);
                    }
                    else
                    {
                        MessageBox.Show("Штрафная ставка не найдена в настройках.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки штрафной ставки: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Settings SET fine_rate = @FineRate WHERE id = 1";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@FineRate", numericUpDown1.Value);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Штрафная ставка успешно обновлена.", "Успех",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить штрафную ставку.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения штрафной ставки: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }
}