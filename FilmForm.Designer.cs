namespace CourseWork
{
    partial class FilmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilmForm));
            this.Back = new System.Windows.Forms.Button();
            this.DeleteFilm = new System.Windows.Forms.Button();
            this.AddFilm = new System.Windows.Forms.Button();
            this.UpdateFilm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ResetSearch = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Back.Location = new System.Drawing.Point(22, 506);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(93, 45);
            this.Back.TabIndex = 13;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // DeleteFilm
            // 
            this.DeleteFilm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DeleteFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteFilm.Location = new System.Drawing.Point(753, 289);
            this.DeleteFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteFilm.Name = "DeleteFilm";
            this.DeleteFilm.Size = new System.Drawing.Size(146, 58);
            this.DeleteFilm.TabIndex = 16;
            this.DeleteFilm.Text = "Удалить ";
            this.DeleteFilm.UseVisualStyleBackColor = false;
            this.DeleteFilm.Click += new System.EventHandler(this.DeleteFilm_Click);
            // 
            // AddFilm
            // 
            this.AddFilm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFilm.Location = new System.Drawing.Point(753, 223);
            this.AddFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddFilm.Name = "AddFilm";
            this.AddFilm.Size = new System.Drawing.Size(146, 53);
            this.AddFilm.TabIndex = 15;
            this.AddFilm.Text = "Добавить";
            this.AddFilm.UseVisualStyleBackColor = false;
            this.AddFilm.Click += new System.EventHandler(this.AddFilm_Click);
            // 
            // UpdateFilm
            // 
            this.UpdateFilm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.UpdateFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateFilm.Location = new System.Drawing.Point(753, 368);
            this.UpdateFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateFilm.Name = "UpdateFilm";
            this.UpdateFilm.Size = new System.Drawing.Size(146, 58);
            this.UpdateFilm.TabIndex = 17;
            this.UpdateFilm.Text = "Редактировать";
            this.UpdateFilm.UseVisualStyleBackColor = false;
            this.UpdateFilm.Click += new System.EventHandler(this.UpdateFilm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(63, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 37);
            this.label3.TabIndex = 18;
            this.label3.Text = "Управление фильмами";
            // 
            // ResetSearch
            // 
            this.ResetSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ResetSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetSearch.Location = new System.Drawing.Point(635, 99);
            this.ResetSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetSearch.Name = "ResetSearch";
            this.ResetSearch.Size = new System.Drawing.Size(110, 29);
            this.ResetSearch.TabIndex = 26;
            this.ResetSearch.Text = "Сброс";
            this.ResetSearch.UseVisualStyleBackColor = false;
            this.ResetSearch.Click += new System.EventHandler(this.ResetSearch_Click);
            // 
            // Source
            // 
            this.Source.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Source.Location = new System.Drawing.Point(498, 100);
            this.Source.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(110, 29);
            this.Source.TabIndex = 25;
            this.Source.Text = "Поиск";
            this.Source.UseVisualStyleBackColor = false;
            this.Source.Click += new System.EventHandler(this.Source_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 103);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 22);
            this.textBox1.TabIndex = 24;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView1.Location = new System.Drawing.Point(70, 165);
            this.advancedDataGridView1.MinimumSize = new System.Drawing.Size(70, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RowHeadersWidth = 40;
            this.advancedDataGridView1.RowTemplate.Height = 24;
            this.advancedDataGridView1.Size = new System.Drawing.Size(643, 321);
            this.advancedDataGridView1.TabIndex = 27;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            // 
            // FilmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(956, 575);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.ResetSearch);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UpdateFilm);
            this.Controls.Add(this.DeleteFilm);
            this.Controls.Add(this.AddFilm);
            this.Controls.Add(this.Back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(974, 622);
            this.MinimumSize = new System.Drawing.Size(974, 622);
            this.Name = "FilmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeFilm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FilmForm_FormClosing);
            this.Load += new System.EventHandler(this.FilmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button DeleteFilm;
        private System.Windows.Forms.Button AddFilm;
        private System.Windows.Forms.Button UpdateFilm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResetSearch;
        private System.Windows.Forms.Button Source;
        private System.Windows.Forms.TextBox textBox1;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
    }
}