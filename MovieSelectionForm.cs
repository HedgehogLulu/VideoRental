using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class MovieSelectionForm : Form
    {
        public List<int> SelectedMovieIds { get; private set; } = new List<int>();
        private Dictionary<string, int> movieTitleToId = new Dictionary<string, int>();
        private SQLiteConnection _connection;
        private List<int> _previouslySelected;

        private List<string> _allMovies = new List<string>();
        private HashSet<int> _allSelectedIds = new HashSet<int>();

        public MovieSelectionForm(SQLiteConnection connection, List<int> previouslySelected = null)
        {
            InitializeComponent();
            _connection = connection;
            _previouslySelected = previouslySelected ?? new List<int>();
            textBox1.TextChanged += textBox1_TextChanged;
            checkedListBoxMovies.ItemCheck += CheckedListBoxMovies_ItemCheck;
            LoadMovies();
        }
        private void LoadMovies()
        {
            try
            {
                checkedListBoxMovies.Items.Clear();
                movieTitleToId.Clear();
                _allMovies.Clear();

                string query = "SELECT id_kino, Название, Режиссёр, Год_выпуска FROM Movie";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int movieId = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string director = reader.GetString(2);
                            int year = reader.GetInt32(3);

                            string displayText = $"{title} ({year}, {director})";
                            movieTitleToId[displayText] = movieId;
                              _allMovies.Add(displayText);

                            // Добавляем элемент и отмечаем, если он был выбран ранее
                            int index = checkedListBoxMovies.Items.Add(displayText);
                            if (_previouslySelected.Contains(movieId))
                            {
                                checkedListBoxMovies.SetItemChecked(index, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки фильмов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Обновляем выборы перед подтверждением
            UpdateSelectedIdsFromUI();
            SelectedMovieIds = _allSelectedIds.ToList();
            DialogResult = DialogResult.OK;
            Close();

        }
        private void FilterMovies(string searchText)
        {
            // Сохраняем текущие выборы перед обновлением списка
            UpdateSelectedIdsFromUI();

            checkedListBoxMovies.Items.Clear();

            var moviesToShow = string.IsNullOrWhiteSpace(searchText)
                ? _allMovies
                : _allMovies.Where(m => m.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var movie in moviesToShow)
            {
                int index = checkedListBoxMovies.Items.Add(movie);
                if (movieTitleToId.TryGetValue(movie, out int movieId) && _allSelectedIds.Contains(movieId))
                {
                    checkedListBoxMovies.SetItemChecked(index, true);
                }
            }
        }

        private void UpdateSelectedIdsFromUI()
        {
            foreach (var item in checkedListBoxMovies.CheckedItems)
            {
                if (movieTitleToId.TryGetValue(item.ToString(), out int movieId))
                {
                    _allSelectedIds.Add(movieId);
                }
            }
        }

        private void CheckedListBoxMovies_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Обрабатываем изменение состояния checkbox в реальном времени
            string movieTitle = checkedListBoxMovies.Items[e.Index].ToString();
            if (movieTitleToId.TryGetValue(movieTitle, out int movieId))
            {
                if (e.NewValue == CheckState.Checked)
                {
                    _allSelectedIds.Add(movieId);
                }
                else
                {
                    _allSelectedIds.Remove(movieId);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterMovies(textBox1.Text);
        }
    }
}

