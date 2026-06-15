namespace CourseWork
{
    partial class DisckManagementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisckManagementForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.btnRemoveDisck = new System.Windows.Forms.Button();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.btUptateDisck = new System.Windows.Forms.Button();
            this.AddDisck = new System.Windows.Forms.Button();
            this.tabFilm = new System.Windows.Forms.TabPage();
            this.btnUpdateFilm = new System.Windows.Forms.Button();
            this.advancedDataGridView2 = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ResetSearch = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.tabFilm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabFilm);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(71, 144);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 609);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabInfo
            // 
            this.tabInfo.BackColor = System.Drawing.Color.Lavender;
            this.tabInfo.Controls.Add(this.btnRemoveDisck);
            this.tabInfo.Controls.Add(this.advancedDataGridView1);
            this.tabInfo.Controls.Add(this.btUptateDisck);
            this.tabInfo.Controls.Add(this.AddDisck);
            this.tabInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabInfo.Location = new System.Drawing.Point(4, 34);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(963, 571);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Носитель";
            // 
            // btnRemoveDisck
            // 
            this.btnRemoveDisck.BackColor = System.Drawing.SystemColors.Menu;
            this.btnRemoveDisck.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveDisck.Location = new System.Drawing.Point(684, 511);
            this.btnRemoveDisck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveDisck.Name = "btnRemoveDisck";
            this.btnRemoveDisck.Size = new System.Drawing.Size(225, 55);
            this.btnRemoveDisck.TabIndex = 22;
            this.btnRemoveDisck.Text = "Удалить ";
            this.btnRemoveDisck.UseVisualStyleBackColor = false;
            this.btnRemoveDisck.Click += new System.EventHandler(this.btnRemoveDisck_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.MinimumSize = new System.Drawing.Size(40, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RowHeadersWidth = 40;
            this.advancedDataGridView1.RowTemplate.Height = 24;
            this.advancedDataGridView1.Size = new System.Drawing.Size(960, 506);
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            // 
            // btUptateDisck
            // 
            this.btUptateDisck.BackColor = System.Drawing.SystemColors.Menu;
            this.btUptateDisck.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btUptateDisck.Location = new System.Drawing.Point(357, 511);
            this.btUptateDisck.Margin = new System.Windows.Forms.Padding(4);
            this.btUptateDisck.Name = "btUptateDisck";
            this.btUptateDisck.Size = new System.Drawing.Size(222, 55);
            this.btUptateDisck.TabIndex = 21;
            this.btUptateDisck.Text = "Редактировать";
            this.btUptateDisck.UseVisualStyleBackColor = false;
            this.btUptateDisck.Click += new System.EventHandler(this.btUptateDisck_Click);
            // 
            // AddDisck
            // 
            this.AddDisck.BackColor = System.Drawing.SystemColors.Menu;
            this.AddDisck.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDisck.Location = new System.Drawing.Point(29, 510);
            this.AddDisck.Margin = new System.Windows.Forms.Padding(4);
            this.AddDisck.Name = "AddDisck";
            this.AddDisck.Size = new System.Drawing.Size(213, 56);
            this.AddDisck.TabIndex = 20;
            this.AddDisck.Text = "Добавить";
            this.AddDisck.UseVisualStyleBackColor = false;
            this.AddDisck.Click += new System.EventHandler(this.AddDisck_Click);
            // 
            // tabFilm
            // 
            this.tabFilm.BackColor = System.Drawing.Color.Lavender;
            this.tabFilm.Controls.Add(this.btnUpdateFilm);
            this.tabFilm.Controls.Add(this.advancedDataGridView2);
            this.tabFilm.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabFilm.Location = new System.Drawing.Point(4, 34);
            this.tabFilm.Name = "tabFilm";
            this.tabFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilm.Size = new System.Drawing.Size(963, 571);
            this.tabFilm.TabIndex = 1;
            this.tabFilm.Text = "Фильмы";
            // 
            // btnUpdateFilm
            // 
            this.btnUpdateFilm.BackColor = System.Drawing.SystemColors.Menu;
            this.btnUpdateFilm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdateFilm.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateFilm.Location = new System.Drawing.Point(3, 527);
            this.btnUpdateFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateFilm.Name = "btnUpdateFilm";
            this.btnUpdateFilm.Size = new System.Drawing.Size(957, 41);
            this.btnUpdateFilm.TabIndex = 19;
            this.btnUpdateFilm.Text = "Редактировать";
            this.btnUpdateFilm.UseVisualStyleBackColor = false;
            this.btnUpdateFilm.Click += new System.EventHandler(this.btnUpdateFilm_Click);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView2.MinimumSize = new System.Drawing.Size(40, 0);
            this.advancedDataGridView2.Name = "advancedDataGridView2";
            this.advancedDataGridView2.ReadOnly = true;
            this.advancedDataGridView2.RowHeadersWidth = 40;
            this.advancedDataGridView2.RowTemplate.Height = 24;
            this.advancedDataGridView2.Size = new System.Drawing.Size(960, 513);
            this.advancedDataGridView2.TabIndex = 1;
            this.advancedDataGridView2.TimeFilter = false;
            this.advancedDataGridView2.SortStringChanged += new System.EventHandler(this.advancedDataGridView2_SortStringChanged);
            this.advancedDataGridView2.FilterStringChanged += new System.EventHandler(this.advancedDataGridView2_FilterStringChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(64, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 37);
            this.label3.TabIndex = 19;
            this.label3.Text = "Управление носителями";
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Back.Location = new System.Drawing.Point(75, 777);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(183, 52);
            this.Back.TabIndex = 20;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1096, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(330, 566);
            this.dataGridView1.TabIndex = 21;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbTitle.Location = new System.Drawing.Point(1100, 32);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(249, 31);
            this.lbTitle.TabIndex = 37;
            this.lbTitle.Text = "Фильм на носителе";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1096, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 31);
            this.textBox1.TabIndex = 38;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(71, 96);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(600, 31);
            this.textBox2.TabIndex = 39;
            // 
            // ResetSearch
            // 
            this.ResetSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ResetSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetSearch.Location = new System.Drawing.Point(885, 82);
            this.ResetSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetSearch.Name = "ResetSearch";
            this.ResetSearch.Size = new System.Drawing.Size(123, 45);
            this.ResetSearch.TabIndex = 43;
            this.ResetSearch.Text = "Сброс";
            this.ResetSearch.UseVisualStyleBackColor = false;
            this.ResetSearch.Click += new System.EventHandler(this.ResetSearch_Click);
            // 
            // Source
            // 
            this.Source.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Source.Location = new System.Drawing.Point(719, 82);
            this.Source.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(123, 45);
            this.Source.TabIndex = 42;
            this.Source.Text = "Поиск";
            this.Source.UseVisualStyleBackColor = false;
            this.Source.Click += new System.EventHandler(this.Source_Click);
            // 
            // DisckManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1497, 863);
            this.Controls.Add(this.ResetSearch);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1515, 910);
            this.MinimumSize = new System.Drawing.Size(1515, 910);
            this.Name = "DisckManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisckManagementForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisckManagementForm_FormClosing);
            this.Load += new System.EventHandler(this.DisckManagementForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.tabFilm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabFilm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button AddDisck;
        private System.Windows.Forms.Button btnUpdateFilm;
        private System.Windows.Forms.Button btUptateDisck;
        private System.Windows.Forms.Button btnRemoveDisck;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private ADGV.AdvancedDataGridView advancedDataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button ResetSearch;
        private System.Windows.Forms.Button Source;
    }
}