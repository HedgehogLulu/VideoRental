using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace CourseWork
{
    public partial class Report : Form
    {
        private AdminPanel adminPanel;
        private readonly SQLiteConnection _connection;
        private DataTable _allGenres;
        private DataTable _allClients;
        private bool _isUpdating;

        public Report(AdminPanel admin)
        {
            InitializeComponent();
            this.adminPanel = admin;
            this.FormClosing += Report_FormClosing;
            _connection = DbConnection.GetConnection();
            // Настройка событий для ADGV
            advancedDataGridView1.SortStringChanged += advancedDataGridView1_SortStringChanged;
            advancedDataGridView1.FilterStringChanged += advancedDataGridView1_FilterStringChanged;
            advancedDataGridView2.SortStringChanged += advancedDataGridView2_SortStringChanged;
            advancedDataGridView2.FilterStringChanged += advancedDataGridView2_FilterStringChanged;
            advancedDataGridView3.SortStringChanged += advancedDataGridView3_SortStringChanged;
            advancedDataGridView3.FilterStringChanged += advancedDataGridView3_FilterStringChanged;
            LoadAllGenres();
            LoadClients();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            this.Close();
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
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

                cbCustomers.DataSource = null;
                cbCustomers.Items.Clear();
                cbCustomers.Text = "";

                cbCustomers.DropDown += (s, e) =>
                {
                    if (!_isUpdating && cbCustomers.DataSource == null)
                    {
                        ShowAllClients();
                    }
                };

                cbCustomers.TextChanged += (s, e) =>
                {
                    if (_isUpdating) return;

                    string searchText = cbCustomers.Text;
                    int cursorPos = cbCustomers.SelectionStart;

                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        cbCustomers.DataSource = null;
                        cbCustomers.Items.Clear();
                        return;
                    }

                    FilterClients(searchText, cursorPos);
                };

                cbCustomers.SelectedIndexChanged += (s, e) => UpdateReportButtonState();
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
                cbCustomers.DataSource = _allClients.Copy();
                cbCustomers.DisplayMember = "FullName";
                cbCustomers.ValueMember = "id_client";
                cbCustomers.SelectedIndex = -1;
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

                cbCustomers.BeginUpdate();
                cbCustomers.DataSource = filtered.Any() ? filtered.CopyToDataTable() : null;
                cbCustomers.DisplayMember = "FullName";
                cbCustomers.ValueMember = "id_client";
                cbCustomers.Text = searchText;
                cbCustomers.SelectionStart = cursorPos;

                if (filtered.Any())
                {
                    cbCustomers.DroppedDown = true;
                }
            }
            finally
            {
                cbCustomers.EndUpdate();
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
        }

        private void cmbGenre_DropDownClosed(object sender, EventArgs e)
        {
            UpdateGenreDisplayText();
        }

        private void UpdateReportButtonState()
        {
            bool hasGenreSelection = cmbGenre.GetItemChecked(0) || cmbGenre.CheckedItems.Count > 0;
            btnReport.Enabled = (radioAvailable.Checked || radioRented.Checked || radioRepair.Checked) && hasGenreSelection;
            button1.Enabled = cbCustomers.SelectedValue != null;
        }

        private void radioAvailable_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReportButtonState();
        }

        private void radioRented_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReportButtonState();
        }

        private void radioRepair_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReportButtonState();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                var selectedGenres = new List<string>();
                for (int i = 1; i < cmbGenre.Items.Count; i++)
                {
                    if (cmbGenre.GetItemChecked(i))
                    {
                        selectedGenres.Add(cmbGenre.Items[i].ToString());
                    }
                }

                if (selectedGenres.Count == 0 && !cmbGenre.GetItemChecked(0))
                {
                    MessageBox.Show("Выберите хотя бы один жанр!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var genreIds = new List<int>();
                if (!cmbGenre.GetItemChecked(0))
                {
                    foreach (DataRow row in _allGenres.Rows)
                    {
                        if (selectedGenres.Contains(row["Название"].ToString()))
                        {
                            genreIds.Add(Convert.ToInt32(row["id_genre"]));
                        }
                    }
                }

                if (radioRented.Checked)
                {
                    query = @"
                SELECT GROUP_CONCAT(m.Название, '; ') AS Фильмы,
                       d.серийный_номер AS 'Серийный номер', 
                       t.Название AS 'Тип носителя', 
                       (SELECT COUNT(*) 
                        FROM Rental r2 
                        WHERE r2.Носитель = d.id_disck 
                        AND r2.статус = 'Активен') AS 'Количество в прокате',
                       'В прокате' AS Статус
                FROM Rental r
                JOIN Disck d ON r.Носитель = d.id_disck
                JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
                JOIN Movie m ON dm.id_фильма = m.id_kino
                WHERE r.статус = 'Активен'";
                    if (genreIds.Count > 0)
                    {
                        query += $"\nAND m.id_kino IN (SELECT DISTINCT Gkino FROM MovieGenre WHERE Mgenre IN ({string.Join(",", genreIds)}))";
                    }
                    query += "\nGROUP BY d.id_disck, d.серийный_номер, t.Название, d.кол_во_копий\nORDER BY d.серийный_номер";
                }
                else if (radioAvailable.Checked)
                {
                    query = @"
                SELECT GROUP_CONCAT(m.Название, '; ') AS Фильмы,
                       d.серийный_номер AS 'Серийный номер', 
                       t.Название AS 'Тип носителя', 
                       d.кол_во_копий AS 'Доступное количество',
                       d.статус AS Статус
                FROM Disck d
                JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
                JOIN Movie m ON dm.id_фильма = m.id_kino
                WHERE d.статус = 'Доступен'";
                    if (genreIds.Count > 0)
                    {
                        query += $"\nAND m.id_kino IN (SELECT DISTINCT Gkino FROM MovieGenre WHERE Mgenre IN ({string.Join(",", genreIds)}))";
                    }
                    query += "\nGROUP BY d.id_disck, d.серийный_номер, t.Название, d.кол_во_копий\nORDER BY d.серийный_номер";
                }
                else if (radioRepair.Checked)
                {
                    query = @"
                SELECT GROUP_CONCAT(m.Название, '; ') AS Фильмы, 
                       d.серийный_номер AS 'Серийный номер', 
                       t.Название AS 'Тип носителя', 
                       d.кол_во_копий AS 'Общее количество копий', 
                       d.статус AS Статус
                FROM Disck d
                JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
                JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
                JOIN Movie m ON dm.id_фильма = m.id_kino
                WHERE d.статус = 'На ремонте'";
                    if (genreIds.Count > 0)
                    {
                        query += $"\nAND m.id_kino IN (SELECT DISTINCT Gkino FROM MovieGenre WHERE Mgenre IN ({string.Join(",", genreIds)}))";
                    }
                    query += "\nGROUP BY d.id_disck, d.серийный_номер, t.Название, d.кол_во_копий\nORDER BY d.серийный_номер";
                }
                else
                {
                    MessageBox.Show("Выберите тип отчета!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Данные для отчета не найдены.", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        advancedDataGridView1.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
        SELECT r.id_прокат AS 'ID аренды', 
               c.Фамилия || ' ' || c.Имя || ' ' || c.Отчество AS Клиент, 
               GROUP_CONCAT(m.Название, '; ') AS Фильмы, 
               d.серийный_номер AS 'Серийный номер', 
               r.дата_выдачи AS 'Дата выдачи', 
               r.дата_возврата AS 'Дата возврата',
               r.стоимость_руб AS 'Стоимость проката (руб)', 
               r.статус AS Статус
        FROM Rental r
        JOIN Client c ON r.Клиент = c.id_client
        JOIN Disck d ON r.Носитель = d.id_disck
        JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
        JOIN Movie m ON dm.id_фильма = m.id_kino
        WHERE r.статус IN ('Активен', 'Просрочен')
        GROUP BY r.id_прокат, c.Фамилия, c.Имя, c.Отчество, d.серийный_номер, r.дата_выдачи, r.дата_возврата, r.стоимость_руб, r.статус
        ORDER BY r.дата_выдачи";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Текущие аренды не найдены.", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        advancedDataGridView2.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePicker3.Value;
                DateTime endDate = dateTimePicker4.Value;
                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала периода не может быть позже даты окончания.", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal fineRate = GetFineRate(); // Получаем штрафную ставку

                string query = @"
        SELECT r.id_прокат AS 'ID аренды',
               c.id_client AS 'ID клиента', 
               d.серийный_номер AS 'Серийный номер', 
               t.Название AS 'Тип носителя',
               r.дата_выдачи AS 'Дата выдачи', 
               r.дата_возврата AS 'Дата возврата',
               r.дата_фактического_возврата AS 'Фактическая дата возврата',
               ROUND(julianday(COALESCE(r.дата_фактического_возврата, @EndDate)) - julianday(r.дата_возврата), 2) AS 'Дней просрочки',
               r.стоимость_руб AS 'Стоимость проката (руб)', 
               ROUND(julianday(COALESCE(r.дата_фактического_возврата, @EndDate)) - julianday(r.дата_возврата), 2) * @FineRate AS 'Долг (руб)'
        FROM Rental r
        JOIN Client c ON r.Клиент = c.id_client
        JOIN Disck d ON r.Носитель = d.id_disck
        JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
        JOIN Movie m ON dm.id_фильма = m.id_kino
        JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
        WHERE r.дата_возврата BETWEEN @StartDate AND @EndDate
          AND (
              (r.дата_фактического_возврата IS NOT NULL AND r.дата_фактического_возврата > r.дата_возврата)
              OR
              (r.дата_фактического_возврата IS NULL AND @EndDate > r.дата_возврата)
          )
        GROUP BY r.id_прокат, c.Фамилия, c.Имя, c.Отчество, d.серийный_номер, t.Название, 
                 r.дата_выдачи, r.дата_возврата, r.дата_фактического_возврата, r.стоимость_руб, r.статус
        ORDER BY r.дата_возврата, c.Фамилия";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FineRate", fineRate);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show($"За период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy} просроченные возвраты не найдены.",
                                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        advancedDataGridView2.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
        SELECT id_client AS 'ID клиента', 
               Фамилия, 
               Имя, 
               Отчество, 
               Моб_телефон AS Телефон
        FROM Client
        ORDER BY Фамилия, Имя, Отчество";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Клиенты не найдены.", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        advancedDataGridView3.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePicker5.Value;
                DateTime endDate = dateTimePicker6.Value;
                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала периода не может быть позже даты окончания.", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal fineRate = GetFineRate(); // Получаем штрафную ставку

                string query = @"
        SELECT c.id_client AS 'ID клиента', 
               c.Фамилия || ' ' || c.Имя || ' ' || c.Отчество AS Клиент, 
               c.Моб_телефон AS 'Телефон клиента',
               COUNT(DISTINCT r.id_прокат) AS 'Количество просрочек',
               SUM(ROUND(julianday(COALESCE(r.дата_фактического_возврата, @EndDate)) - julianday(r.дата_возврата), 2) * @FineRate) AS 'Общая сумма долга (руб)',
               MIN(r.дата_возврата) AS 'Планируемая дата возврата'
        FROM Rental r
        JOIN Client c ON r.Клиент = c.id_client
        JOIN Disck d ON r.Носитель = d.id_disck
        WHERE r.дата_возврата BETWEEN @StartDate AND @EndDate
          AND (
              (r.дата_фактического_возврата IS NOT NULL AND r.дата_фактического_возврата > r.дата_возврата)
              OR
              (r.дата_фактического_возврата IS NULL AND @EndDate > r.дата_возврата)
          )
        GROUP BY c.id_client, c.Фамилия, c.Имя, c.Отчество, c.Моб_телефон
        ORDER BY 'Общая сумма долга (руб)' DESC, c.Фамилия";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FineRate", fineRate);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show($"За период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy} должники не найдены.",
                                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        advancedDataGridView3.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomers.SelectedItem == null)
                {
                    MessageBox.Show("Выберите клиента!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRowView clientRow = cbCustomers.SelectedItem as DataRowView;
                int clientId = Convert.ToInt32(clientRow["id_client"]);
                string clientName = clientRow["FullName"].ToString();

                string query = @"
        SELECT r.id_прокат AS 'ID аренды', 
               GROUP_CONCAT(m.Название, '; ') AS Фильмы, 
               d.серийный_номер AS 'Серийный номер', 
               t.Название AS 'Тип носителя',
               r.дата_выдачи AS 'Дата выдачи', 
               r.дата_возврата AS 'Дата возврата',
               r.дата_фактического_возврата AS 'Фактическая дата возврата',
               r.стоимость_руб AS 'Стоимость проката (руб)'
        FROM Rental r
        JOIN Client c ON r.Клиент = c.id_client
        JOIN Disck d ON r.Носитель = d.id_disck
        JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
        JOIN Movie m ON dm.id_фильма = m.id_kino
        JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
        WHERE r.Клиент = @ClientId
        GROUP BY r.id_прокат, d.серийный_номер, t.Название, r.дата_выдачи, r.дата_возврата, 
                 r.дата_фактического_возврата, r.стоимость_руб, r.статус
        ORDER BY r.дата_выдачи";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@ClientId", clientId);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show($"Для клиента {clientName} история прокатов не найдена.", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        advancedDataGridView3.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала периода не может быть позже даты окончания.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
        SELECT 
            GROUP_CONCAT(m.Название, '; ') AS Фильмы,
            d.серийный_номер AS 'Серийный номер',   
            t.Название AS 'Тип носителя',
            COUNT(DISTINCT r.id_прокат) AS 'Количество прокатов',
            SUM(r.стоимость_руб) AS 'Общая выручка (руб)',
            AVG(r.стоимость_руб) AS 'Средняя стоимость проката (руб)'
        FROM Rental r
        JOIN Disck d ON r.Носитель = d.id_disck
        JOIN DisckMovie dm ON dm.id_носителя = d.id_disck
        JOIN Movie m ON dm.id_фильма = m.id_kino
        JOIN TypeDisck t ON d.Тип_носителя = t.id_Dtype
        WHERE r.дата_выдачи BETWEEN @StartDate AND @EndDate
          AND r.статус = 'Завершен'
        GROUP BY d.id_disck, t.Название
        ORDER BY 'Общая выручка (руб)' DESC";

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        if (reportTable.Rows.Count == 0)
                        {
                            MessageBox.Show($"За период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy} данные о выручке не найдены.",
                                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            advancedDataGridView2.DataSource = null;
                            return;
                        }

                        // Подсчёт итогов
                        int totalRentals = reportTable.AsEnumerable().Sum(row => Convert.ToInt32(row["Количество прокатов"]));
                        decimal totalRevenue = reportTable.AsEnumerable().Sum(row => Convert.ToDecimal(row["Общая выручка (руб)"]));
                        decimal avgRentalCost = reportTable.AsEnumerable().Average(row => Convert.ToDecimal(row["Средняя стоимость проката (руб)"]));

                        // Добавляем строку с итогом
                        DataRow totalRow = reportTable.NewRow();
                        totalRow["Фильмы"] = "ИТОГО:";
                        totalRow["Серийный номер"] = "";
                        totalRow["Тип носителя"] = "";
                        totalRow["Количество прокатов"] = totalRentals;
                        totalRow["Общая выручка (руб)"] = totalRevenue;
                        totalRow["Средняя стоимость проката (руб)"] = Math.Round(avgRentalCost, 2);
                        reportTable.Rows.Add(totalRow);

                        advancedDataGridView2.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                advancedDataGridView2.DataSource = null;
            }
        }


        private decimal GetFineRate()
        {
            try
            {
                string query = "SELECT fine_rate FROM Settings WHERE id = 1";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 100; // Дефолтное значение
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения штрафной ставки: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 100; // Дефолтное значение в случае ошибки
            }
        }

        private void ExportEcxel_Click(object sender, EventArgs e)
        {
            try
            {
                if (advancedDataGridView3.DataSource == null || ((DataTable)advancedDataGridView3.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта.", "Информация",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable reportTable = (DataTable)advancedDataGridView3.DataSource;
                DateTime currentDate = DateTime.Now;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Report");
                    worksheet.Cell(1, 1).Value = "Отчет по клиентам";
                    worksheet.Cell(2, 1).Value = $"Дата формирования: {currentDate:dd.MM.yyyy HH:mm}";

                    for (int i = 0; i < reportTable.Columns.Count; i++)
                    {
                        worksheet.Cell(4, i + 1).Value = reportTable.Columns[i].ColumnName;
                        worksheet.Cell(4, i + 1).Style.Font.Bold = true;
                    }

                    for (int i = 0; i < reportTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < reportTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 5, j + 1).Value = reportTable.Rows[i][j].ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    saveFileDialog1.FileName = $"Clients_Report_{currentDate:yyyyMMdd_HHmmss}.xlsx";
                    saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show($"Отчет успешно сохранен как {saveFileDialog1.FileName}", "Успех",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                if (advancedDataGridView1.DataSource == null || ((DataTable)advancedDataGridView1.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта.", "Информация",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable reportTable = (DataTable)advancedDataGridView1.DataSource;
                DateTime currentDate = DateTime.Now;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Report");
                    worksheet.Cell(1, 1).Value = "Отчет по носителям";
                    worksheet.Cell(2, 1).Value = $"Дата формирования: {currentDate:dd.MM.yyyy HH:mm}";

                    for (int i = 0; i < reportTable.Columns.Count; i++)
                    {
                        worksheet.Cell(4, i + 1).Value = reportTable.Columns[i].ColumnName;
                        worksheet.Cell(4, i + 1).Style.Font.Bold = true;
                    }

                    for (int i = 0; i < reportTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < reportTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 5, j + 1).Value = reportTable.Rows[i][j].ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    saveFileDialog1.FileName = $"Media_Report_{currentDate:yyyyMMdd_HHmmss}.xlsx";
                    saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show($"Отчет успешно сохранен как {saveFileDialog1.FileName}", "Успех",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ElExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (advancedDataGridView2.DataSource == null || ((DataTable)advancedDataGridView2.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта.", "Информация",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable reportTable = (DataTable)advancedDataGridView2.DataSource;
                DateTime currentDate = DateTime.Now;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Report");
                    worksheet.Cell(1, 1).Value = "Отчет по прокатам";
                    worksheet.Cell(2, 1).Value = $"Дата формирования: {currentDate:dd.MM.yyyy HH:mm}";

                    for (int i = 0; i < reportTable.Columns.Count; i++)
                    {
                        worksheet.Cell(4, i + 1).Value = reportTable.Columns[i].ColumnName;
                        worksheet.Cell(4, i + 1).Style.Font.Bold = true;
                    }

                    for (int i = 0; i < reportTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < reportTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 5, j + 1).Value = reportTable.Rows[i][j].ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    saveFileDialog1.FileName = $"Rentals_Report_{currentDate:yyyyMMdd_HHmmss}.xlsx";
                    saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show($"Отчет успешно сохранен как {saveFileDialog1.FileName}", "Успех",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void advancedDataGridView3_FilterStringChanged(object sender, EventArgs e)
        {
            // Применяем фильтр к текущим данным
            if (advancedDataGridView3.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = advancedDataGridView3.FilterString;
            }
        }

        private void advancedDataGridView3_SortStringChanged(object sender, EventArgs e)
        {
            // Применяем сортировку к текущей таблице данных
            if (advancedDataGridView3.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.Sort = advancedDataGridView3.SortString;
            }
        }
    }
}