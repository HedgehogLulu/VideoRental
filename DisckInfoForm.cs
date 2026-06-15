using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class DisckInfoForm : Form
    {
        private readonly SQLiteConnection _connection;
        private int? _disckId; // null для добавления, число для редактирования
        public DisckInfoForm(SQLiteConnection connection, int? disckId = null)
        {
            InitializeComponent();
            _connection = connection;
            _disckId = disckId;

            // Загружаем типы носителей из БД в ComboBox
            LoadDisckTypes();

            if (_disckId.HasValue)
            {
                this.Text = "Редактировать";
                LoadDisckData();
            }
            else
            {
                this.Text = "Добавить";
                label8.Text = GetNextDisckId().ToString();
            }
        }
        private int GetNextDisckId()
        {
            try
            {
                string query = "SELECT seq FROM sqlite_sequence WHERE name='Disck'";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) + 1 : 1;
                }
            }
            catch
            {
                return 1; // Если что-то пошло не так, возвращаем 1
            }
        }

        private void LoadDisckTypes()
        {
            try
            {
                string query = "SELECT Название FROM TypeDisck";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbType.Items.Clear();
                        while (reader.Read())
                        {
                            cmbType.Items.Add(reader["Название"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов носителей: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDisckData()
        {
            try
            {
                string query = "SELECT * FROM Disck WHERE id_disck = @id";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@id", _disckId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label8.Text = reader["id_disck"].ToString();
                            txtSerial.Text = reader["серийный_номер"].ToString();
                            cmbStatus.SelectedItem = reader["статус"].ToString();
                            cmbCondition.SelectedItem = reader["состояние"].ToString();
                            numCopies.Value = Convert.ToInt32(reader["кол_во_копий"]);

                            // Загружаем тип носителя
                            int typeId = Convert.ToInt32(reader["Тип_носителя"]);

                            numPrice.Value = Convert.ToInt32(reader["Цена"]);
                            LoadDisckType(typeId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных носителя: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDisckType(int typeId)
        {
            try
            {
                string query = "SELECT Название FROM TypeDisck WHERE id_Dtype = @id";
                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@id", typeId);
                    var typeName = cmd.ExecuteScalar()?.ToString();
                    if (typeName != null)
                    {
                        cmbType.SelectedItem = typeName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типа носителя: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetDisckTypeId(string typeName)
        {
            string query = "SELECT id_Dtype FROM TypeDisck WHERE Название = @name";
            using (var cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@name", typeName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private bool CheckSerialNumberUnique(string serialNumber, int? excludeId = null)
        {
            string query = "SELECT COUNT(*) FROM Disck WHERE серийный_номер = @serial";
            if (excludeId.HasValue)
            {
                query += " AND id_disck != @id";
            }

            using (var cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@serial", serialNumber);
                if (excludeId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@id", excludeId.Value);
                }

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSerial.Text))
            {
                MessageBox.Show("Введите серийный номер!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип носителя!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCondition.SelectedItem == null)
            {
                MessageBox.Show("Выберите состояние!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!CheckSerialNumberUnique(txtSerial.Text.Trim(), _disckId))
            {
                MessageBox.Show("Носитель с таким серийным номером уже существует!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int typeId = GetDisckTypeId(cmbType.SelectedItem.ToString());

                string query;

                int newId = 0; // Переменная для хранения нового ID
                if (_disckId.HasValue)
                {
                    query = @"UPDATE Disck SET 
                            серийный_номер = @serial,
                            статус = @status,
                            состояние = @condition,
                            кол_во_копий = @copies,
                            Тип_носителя = @typeId,
                            Цена = @price
                            WHERE id_disck = @id";
                }
                else
                {
                    query = @"INSERT INTO Disck (серийный_номер, статус, состояние, кол_во_копий, Тип_носителя, Цена)
                            VALUES (@serial, @status, @condition, @copies, @typeId, @price);
                            SELECT last_insert_rowid();";
                }

                using (var cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@serial", txtSerial.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@condition", cmbCondition.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@copies", (int)numCopies.Value);
                    cmd.Parameters.AddWithValue("@typeId", typeId);
                    cmd.Parameters.AddWithValue("@price", (int)numPrice.Value);

                    if (_disckId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@id", _disckId.Value);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Получаем новый ID и сохраняем его
                        newId = Convert.ToInt32(cmd.ExecuteScalar());
                        label8.Text = newId.ToString(); // Отображаем ID на форме
                    }

                    MessageBox.Show("Данные сохранены успешно!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    // Если это добавление нового носителя, сохраняем ID
                    if (!_disckId.HasValue)
                    {
                        _disckId = newId; // Сохраняем новый ID
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
