namespace CourseWork
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.tabControlReports = new System.Windows.Forms.TabControl();
            this.tabPageMedia = new System.Windows.Forms.TabPage();
            this.Excel = new System.Windows.Forms.Button();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.radioRepair = new System.Windows.Forms.RadioButton();
            this.cmbGenre = new CheckComboBoxTest.CheckedComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.radioRented = new System.Windows.Forms.RadioButton();
            this.radioAvailable = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageRentals = new System.Windows.Forms.TabPage();
            this.ElExcel = new System.Windows.Forms.Button();
            this.advancedDataGridView2 = new ADGV.AdvancedDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBoxCurrentRentals = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxOverdue = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPageCustomers = new System.Windows.Forms.TabPage();
            this.ExportEcxel = new System.Windows.Forms.Button();
            this.advancedDataGridView3 = new ADGV.AdvancedDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBoxCustomerRentals = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.groupBoxDebtors = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControlReports.SuspendLayout();
            this.tabPageMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.tabPageRentals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxCurrentRentals.SuspendLayout();
            this.groupBoxOverdue.SuspendLayout();
            this.tabPageCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxCustomerRentals.SuspendLayout();
            this.groupBoxDebtors.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(488, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "Генерация отчётов";
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Back.Location = new System.Drawing.Point(66, 726);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(108, 45);
            this.Back.TabIndex = 35;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // tabControlReports
            // 
            this.tabControlReports.Controls.Add(this.tabPageMedia);
            this.tabControlReports.Controls.Add(this.tabPageRentals);
            this.tabControlReports.Controls.Add(this.tabPageCustomers);
            this.tabControlReports.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlReports.Location = new System.Drawing.Point(62, 86);
            this.tabControlReports.Name = "tabControlReports";
            this.tabControlReports.SelectedIndex = 0;
            this.tabControlReports.Size = new System.Drawing.Size(1185, 620);
            this.tabControlReports.TabIndex = 36;
            // 
            // tabPageMedia
            // 
            this.tabPageMedia.BackColor = System.Drawing.Color.Lavender;
            this.tabPageMedia.Controls.Add(this.Excel);
            this.tabPageMedia.Controls.Add(this.advancedDataGridView1);
            this.tabPageMedia.Controls.Add(this.radioRepair);
            this.tabPageMedia.Controls.Add(this.cmbGenre);
            this.tabPageMedia.Controls.Add(this.btnReport);
            this.tabPageMedia.Controls.Add(this.radioRented);
            this.tabPageMedia.Controls.Add(this.radioAvailable);
            this.tabPageMedia.Controls.Add(this.label4);
            this.tabPageMedia.Controls.Add(this.label1);
            this.tabPageMedia.Location = new System.Drawing.Point(4, 36);
            this.tabPageMedia.Name = "tabPageMedia";
            this.tabPageMedia.Size = new System.Drawing.Size(1177, 580);
            this.tabPageMedia.TabIndex = 0;
            this.tabPageMedia.Text = "Носители";
            // 
            // Excel
            // 
            this.Excel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Excel.BackgroundImage")));
            this.Excel.Location = new System.Drawing.Point(1057, 14);
            this.Excel.Name = "Excel";
            this.Excel.Size = new System.Drawing.Size(59, 43);
            this.Excel.TabIndex = 51;
            this.Excel.UseVisualStyleBackColor = true;
            this.Excel.Click += new System.EventHandler(this.Excel_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.advancedDataGridView1.Location = new System.Drawing.Point(46, 155);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RowHeadersWidth = 51;
            this.advancedDataGridView1.RowTemplate.Height = 24;
            this.advancedDataGridView1.Size = new System.Drawing.Size(1070, 403);
            this.advancedDataGridView1.TabIndex = 48;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            // 
            // radioRepair
            // 
            this.radioRepair.Location = new System.Drawing.Point(721, 81);
            this.radioRepair.Name = "radioRepair";
            this.radioRepair.Size = new System.Drawing.Size(171, 34);
            this.radioRepair.TabIndex = 47;
            this.radioRepair.Text = "На ремонте";
            this.radioRepair.CheckedChanged += new System.EventHandler(this.radioRepair_CheckedChanged);
            // 
            // cmbGenre
            // 
            this.cmbGenre.CheckOnClick = true;
            this.cmbGenre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbGenre.DropDownHeight = 1;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.IntegralHeight = false;
            this.cmbGenre.Location = new System.Drawing.Point(46, 81);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(332, 34);
            this.cmbGenre.TabIndex = 46;
            this.cmbGenre.ValueSeparator = ", ";
            this.cmbGenre.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cmbGenre_ItemCheck);
            this.cmbGenre.DropDownClosed += new System.EventHandler(this.cmbGenre_DropDownClosed);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.Menu;
            this.btnReport.Enabled = false;
            this.btnReport.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReport.Location = new System.Drawing.Point(902, 63);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(214, 55);
            this.btnReport.TabIndex = 45;
            this.btnReport.Text = "Сформировать";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // radioRented
            // 
            this.radioRented.Location = new System.Drawing.Point(565, 81);
            this.radioRented.Name = "radioRented";
            this.radioRented.Size = new System.Drawing.Size(150, 30);
            this.radioRented.TabIndex = 3;
            this.radioRented.Text = "В прокате";
            this.radioRented.CheckedChanged += new System.EventHandler(this.radioRented_CheckedChanged);
            // 
            // radioAvailable
            // 
            this.radioAvailable.Location = new System.Drawing.Point(409, 81);
            this.radioAvailable.Name = "radioAvailable";
            this.radioAvailable.Size = new System.Drawing.Size(150, 36);
            this.radioAvailable.TabIndex = 7;
            this.radioAvailable.Text = "В наличии";
            this.radioAvailable.CheckedChanged += new System.EventHandler(this.radioAvailable_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Фильтр по наличию носителя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фильтр по жанру";
            // 
            // tabPageRentals
            // 
            this.tabPageRentals.BackColor = System.Drawing.Color.Lavender;
            this.tabPageRentals.Controls.Add(this.ElExcel);
            this.tabPageRentals.Controls.Add(this.advancedDataGridView2);
            this.tabPageRentals.Controls.Add(this.groupBox2);
            this.tabPageRentals.Controls.Add(this.groupBoxCurrentRentals);
            this.tabPageRentals.Controls.Add(this.groupBoxOverdue);
            this.tabPageRentals.Location = new System.Drawing.Point(4, 36);
            this.tabPageRentals.Name = "tabPageRentals";
            this.tabPageRentals.Size = new System.Drawing.Size(1177, 580);
            this.tabPageRentals.TabIndex = 1;
            this.tabPageRentals.Text = "Прокат";
            // 
            // ElExcel
            // 
            this.ElExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ElExcel.BackgroundImage")));
            this.ElExcel.Location = new System.Drawing.Point(25, 141);
            this.ElExcel.Name = "ElExcel";
            this.ElExcel.Size = new System.Drawing.Size(85, 85);
            this.ElExcel.TabIndex = 51;
            this.ElExcel.UseVisualStyleBackColor = true;
            this.ElExcel.Click += new System.EventHandler(this.ElExcel_Click);
            // 
            // advancedDataGridView2
            // 
            this.advancedDataGridView2.AllowUserToAddRows = false;
            this.advancedDataGridView2.AllowUserToDeleteRows = false;
            this.advancedDataGridView2.AutoGenerateContextFilters = true;
            this.advancedDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.advancedDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView2.DateWithTime = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.advancedDataGridView2.Location = new System.Drawing.Point(18, 241);
            this.advancedDataGridView2.Name = "advancedDataGridView2";
            this.advancedDataGridView2.ReadOnly = true;
            this.advancedDataGridView2.RowHeadersWidth = 36;
            this.advancedDataGridView2.RowTemplate.Height = 24;
            this.advancedDataGridView2.Size = new System.Drawing.Size(1130, 320);
            this.advancedDataGridView2.TabIndex = 49;
            this.advancedDataGridView2.TimeFilter = false;
            this.advancedDataGridView2.SortStringChanged += new System.EventHandler(this.advancedDataGridView2_SortStringChanged);
            this.advancedDataGridView2.FilterStringChanged += new System.EventHandler(this.advancedDataGridView2_FilterStringChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(747, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 204);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выручка за период";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 27);
            this.label5.TabIndex = 50;
            this.label5.Text = "По";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 27);
            this.label3.TabIndex = 49;
            this.label3.Text = "С";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(56, 97);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker2.TabIndex = 48;
            this.dateTimePicker2.Value = new System.DateTime(2025, 5, 5, 18, 58, 40, 167);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(56, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker1.TabIndex = 47;
            this.dateTimePicker1.Value = new System.DateTime(2025, 5, 5, 18, 58, 40, 167);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Menu;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(17, 144);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(245, 46);
            this.button6.TabIndex = 46;
            this.button6.Text = "Сформировать";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBoxCurrentRentals
            // 
            this.groupBoxCurrentRentals.Controls.Add(this.button3);
            this.groupBoxCurrentRentals.Location = new System.Drawing.Point(18, 31);
            this.groupBoxCurrentRentals.Name = "groupBoxCurrentRentals";
            this.groupBoxCurrentRentals.Size = new System.Drawing.Size(300, 124);
            this.groupBoxCurrentRentals.TabIndex = 0;
            this.groupBoxCurrentRentals.TabStop = false;
            this.groupBoxCurrentRentals.Text = "Текущие аренды";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Menu;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(39, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 46);
            this.button3.TabIndex = 46;
            this.button3.Text = "Сформировать";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBoxOverdue
            // 
            this.groupBoxOverdue.Controls.Add(this.label6);
            this.groupBoxOverdue.Controls.Add(this.label7);
            this.groupBoxOverdue.Controls.Add(this.dateTimePicker4);
            this.groupBoxOverdue.Controls.Add(this.dateTimePicker3);
            this.groupBoxOverdue.Controls.Add(this.button2);
            this.groupBoxOverdue.Location = new System.Drawing.Point(362, 33);
            this.groupBoxOverdue.Name = "groupBoxOverdue";
            this.groupBoxOverdue.Size = new System.Drawing.Size(341, 202);
            this.groupBoxOverdue.TabIndex = 1;
            this.groupBoxOverdue.TabStop = false;
            this.groupBoxOverdue.Text = "Просроченные аренды";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 27);
            this.label6.TabIndex = 54;
            this.label6.Text = "По";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 27);
            this.label7.TabIndex = 53;
            this.label7.Text = "С";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker4.Location = new System.Drawing.Point(92, 95);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker4.TabIndex = 52;
            this.dateTimePicker4.Value = new System.DateTime(2025, 5, 5, 18, 58, 40, 167);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker3.Location = new System.Drawing.Point(92, 55);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker3.TabIndex = 51;
            this.dateTimePicker3.Value = new System.DateTime(2025, 5, 5, 18, 58, 40, 167);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Menu;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(41, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 52);
            this.button2.TabIndex = 46;
            this.button2.Text = "Сформировать";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPageCustomers
            // 
            this.tabPageCustomers.BackColor = System.Drawing.Color.Lavender;
            this.tabPageCustomers.Controls.Add(this.ExportEcxel);
            this.tabPageCustomers.Controls.Add(this.advancedDataGridView3);
            this.tabPageCustomers.Controls.Add(this.groupBox1);
            this.tabPageCustomers.Controls.Add(this.groupBoxCustomerRentals);
            this.tabPageCustomers.Controls.Add(this.groupBoxDebtors);
            this.tabPageCustomers.Location = new System.Drawing.Point(4, 36);
            this.tabPageCustomers.Name = "tabPageCustomers";
            this.tabPageCustomers.Size = new System.Drawing.Size(1177, 580);
            this.tabPageCustomers.TabIndex = 2;
            this.tabPageCustomers.Text = "Клиенты";
            // 
            // ExportEcxel
            // 
            this.ExportEcxel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExportEcxel.BackgroundImage")));
            this.ExportEcxel.Location = new System.Drawing.Point(47, 161);
            this.ExportEcxel.Name = "ExportEcxel";
            this.ExportEcxel.Size = new System.Drawing.Size(85, 85);
            this.ExportEcxel.TabIndex = 50;
            this.ExportEcxel.UseVisualStyleBackColor = true;
            this.ExportEcxel.Click += new System.EventHandler(this.ExportEcxel_Click);
            // 
            // advancedDataGridView3
            // 
            this.advancedDataGridView3.AllowUserToAddRows = false;
            this.advancedDataGridView3.AllowUserToDeleteRows = false;
            this.advancedDataGridView3.AutoGenerateContextFilters = true;
            this.advancedDataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.advancedDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView3.DateWithTime = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView3.DefaultCellStyle = dataGridViewCellStyle6;
            this.advancedDataGridView3.Location = new System.Drawing.Point(47, 255);
            this.advancedDataGridView3.Name = "advancedDataGridView3";
            this.advancedDataGridView3.ReadOnly = true;
            this.advancedDataGridView3.RowHeadersWidth = 51;
            this.advancedDataGridView3.RowTemplate.Height = 24;
            this.advancedDataGridView3.Size = new System.Drawing.Size(1070, 303);
            this.advancedDataGridView3.TabIndex = 49;
            this.advancedDataGridView3.TimeFilter = false;
            this.advancedDataGridView3.SortStringChanged += new System.EventHandler(this.advancedDataGridView3_SortStringChanged);
            this.advancedDataGridView3.FilterStringChanged += new System.EventHandler(this.advancedDataGridView3_FilterStringChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(47, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 126);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список клиентов";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Menu;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(33, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(181, 47);
            this.button5.TabIndex = 47;
            this.button5.Text = "Сформировать";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBoxCustomerRentals
            // 
            this.groupBoxCustomerRentals.Controls.Add(this.button1);
            this.groupBoxCustomerRentals.Controls.Add(this.cbCustomers);
            this.groupBoxCustomerRentals.Location = new System.Drawing.Point(734, 37);
            this.groupBoxCustomerRentals.Name = "groupBoxCustomerRentals";
            this.groupBoxCustomerRentals.Size = new System.Drawing.Size(362, 151);
            this.groupBoxCustomerRentals.TabIndex = 3;
            this.groupBoxCustomerRentals.TabStop = false;
            this.groupBoxCustomerRentals.Text = "Аренды по клиентам";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Menu;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(19, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 47);
            this.button1.TabIndex = 46;
            this.button1.Text = "Сформировать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbCustomers
            // 
            this.cbCustomers.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCustomers.Location = new System.Drawing.Point(19, 43);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(300, 31);
            this.cbCustomers.TabIndex = 0;
            // 
            // groupBoxDebtors
            // 
            this.groupBoxDebtors.Controls.Add(this.label8);
            this.groupBoxDebtors.Controls.Add(this.label9);
            this.groupBoxDebtors.Controls.Add(this.dateTimePicker6);
            this.groupBoxDebtors.Controls.Add(this.dateTimePicker5);
            this.groupBoxDebtors.Controls.Add(this.button4);
            this.groupBoxDebtors.Location = new System.Drawing.Point(392, 37);
            this.groupBoxDebtors.Name = "groupBoxDebtors";
            this.groupBoxDebtors.Size = new System.Drawing.Size(291, 186);
            this.groupBoxDebtors.TabIndex = 2;
            this.groupBoxDebtors.TabStop = false;
            this.groupBoxDebtors.Text = "Должники";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 27);
            this.label8.TabIndex = 54;
            this.label8.Text = "По";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 27);
            this.label9.TabIndex = 53;
            this.label9.Text = "С";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker6.Location = new System.Drawing.Point(58, 88);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker6.TabIndex = 52;
            this.dateTimePicker6.Value = new System.DateTime(2025, 5, 5, 18, 58, 40, 167);
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker5.Location = new System.Drawing.Point(58, 48);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker5.TabIndex = 51;
            this.dateTimePicker5.Value = new System.DateTime(2025, 5, 5, 18, 58, 40, 167);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Menu;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(19, 124);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(251, 47);
            this.button4.TabIndex = 47;
            this.button4.Text = "Сформировать";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1304, 793);
            this.Controls.Add(this.tabControlReports);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1322, 840);
            this.MinimumSize = new System.Drawing.Size(1322, 840);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Report_FormClosing);
            this.tabControlReports.ResumeLayout(false);
            this.tabPageMedia.ResumeLayout(false);
            this.tabPageMedia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.tabPageRentals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxCurrentRentals.ResumeLayout(false);
            this.groupBoxOverdue.ResumeLayout(false);
            this.groupBoxOverdue.PerformLayout();
            this.tabPageCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxCustomerRentals.ResumeLayout(false);
            this.groupBoxDebtors.ResumeLayout(false);
            this.groupBoxDebtors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TabControl tabControlReports;
        private System.Windows.Forms.TabPage tabPageMedia;
        private System.Windows.Forms.TabPage tabPageRentals;
        private System.Windows.Forms.GroupBox groupBoxCurrentRentals;
        private System.Windows.Forms.GroupBox groupBoxOverdue;
        private System.Windows.Forms.TabPage tabPageCustomers;
        private System.Windows.Forms.GroupBox groupBoxDebtors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioRented;
        private System.Windows.Forms.RadioButton radioAvailable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxCustomerRentals;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private CheckComboBoxTest.CheckedComboBox cmbGenre;
        private System.Windows.Forms.RadioButton radioRepair;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private ADGV.AdvancedDataGridView advancedDataGridView2;
        private ADGV.AdvancedDataGridView advancedDataGridView3;
        private System.Windows.Forms.Button Excel;
        private System.Windows.Forms.Button ElExcel;
        private System.Windows.Forms.Button ExportEcxel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
    }
}