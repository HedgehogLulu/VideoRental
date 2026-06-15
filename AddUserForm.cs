using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddUserForm : Form
    {
        private readonly SQLiteConnection _connection;
        private readonly int? _clientId; // null для добавления, число для редактирования

        public AddUserForm(SQLiteConnection connection, int? clientId = null)
        {
            InitializeComponent();
            _connection = connection;
            _clientId = clientId;

            // Если передали ID - это режим редактирования
            if (_clientId.HasValue)
            {
                this.Text = "Редактировать";
                lbTitle.Text = "Редактирование данных клиента";
                btnSave.Text = "Сохранить";
                LoadClientData();
            }
        }

        // Загрузка данных клиента для редактирования
        private void LoadClientData()
        {
            string query = "SELECT * FROM Client WHERE id_client = @id";
            using (var cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@id", _clientId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        SurName.Text = reader["Фамилия"].ToString();
                        FullName.Text = reader["Имя"].ToString();
                        PartName.Text = reader["Отчество"].ToString();
                        Phone.Text = reader["Моб_телефон"].ToString();
                    }
                }
            }
        }
        private bool IsValidRussianPhoneNumber(string phone)
        {
            // Проверяем российские форматы: +7XXXXXXXXXX или 8XXXXXXXXXX (11 цифр)
            return Regex.IsMatch(phone, @"^(\+7|8)[0-9]{10}$");
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(SurName.Text))
            {
                MessageBox.Show("Введите фамилию!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SurName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(FullName.Text))
            {
                MessageBox.Show("Введите имя!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone.Text))
            {
                MessageBox.Show("Введите номер телефона!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Phone.Focus();
                return false;
            }

            if (!IsValidRussianPhoneNumber(Phone.Text))
            {
                MessageBox.Show("Введите корректный российский номер телефона!\nФормат: +7XXXXXXXXXX или 8XXXXXXXXXX",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Phone.Focus();
                return false;
            }

            return true;
        }
        private bool CheckForDuplicateClient()
        {
            // Проверка по полному совпадению всех данных
            string fullCheckQuery = @"SELECT COUNT(*) FROM Client 
                                    WHERE Фамилия = @surname 
                                    AND Имя = @name 
                                    AND Отчество = @patronymic 
                                    AND Моб_телефон = @phone
                                    AND (@id IS NULL OR id_client != @id)";

            // Проверка только по телефону (как уникальному идентификатору)
            string phoneCheckQuery = @"SELECT COUNT(*) FROM Client 
                                     WHERE Моб_телефон = @phone
                                     AND (@id IS NULL OR id_client != @id)";

            using (var cmd = new SQLiteCommand(fullCheckQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@surname", SurName.Text.Trim());
                cmd.Parameters.AddWithValue("@name", FullName.Text.Trim());
                cmd.Parameters.AddWithValue("@patronymic", PartName.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", Phone.Text.Trim());
                cmd.Parameters.AddWithValue("@id", _clientId ?? (object)DBNull.Value);

                int fullMatchCount = Convert.ToInt32(cmd.ExecuteScalar());
                if (fullMatchCount > 0)
                {
                    MessageBox.Show("Клиент с такими данными уже существует!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            using (var cmd = new SQLiteCommand(phoneCheckQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@phone", Phone.Text.Trim());
                cmd.Parameters.AddWithValue("@id", _clientId ?? (object)DBNull.Value);

                int phoneMatchCount = Convert.ToInt32(cmd.ExecuteScalar());
                if (phoneMatchCount > 0)
                {
                    DialogResult result = MessageBox.Show("Клиент с таким телефоном уже существует! Продолжить сохранение?", "Предупреждение",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return result != DialogResult.Yes;
                }
            }

            return false;
        }
        private bool SaveClientData()
        {
            try
            {
                if (_clientId.HasValue)
                {
                    // Обновление существующего клиента
                    string updateQuery = @"UPDATE Client SET 
                                        Фамилия = @surname,
                                        Имя = @name,
                                        Отчество = @patronymic,
                                        Моб_телефон = @phone
                                        WHERE id_client = @id";

                    using (var cmd = new SQLiteCommand(updateQuery, _connection))
                    {
                        cmd.Parameters.AddWithValue("@surname", SurName.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", FullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@patronymic", PartName.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", Phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", _clientId.Value);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected == 0)
                        {
                            MessageBox.Show("Не удалось обновить данные клиента!", "Ошибка",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    // Добавление нового клиента
                    string insertQuery = @"INSERT INTO Client (Фамилия, Имя, Отчество, Моб_телефон) 
                                        VALUES (@surname, @name, @patronymic, @phone)";

                    using (var cmd = new SQLiteCommand(insertQuery, _connection))
                    {
                        cmd.Parameters.AddWithValue("@surname", SurName.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", FullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@patronymic", PartName.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", Phone.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (CheckForDuplicateClient()) return;

            if (SaveClientData())
            {
                MessageBox.Show(_clientId.HasValue ? "Данные клиента обновлены!" : "Клиент успешно добавлен!",
                              "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}