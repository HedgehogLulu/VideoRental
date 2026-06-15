
namespace CourseWork
{
    partial class FilmEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilmEditForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbGenre = new System.Windows.Forms.Label();
            this.NumYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.Director = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.NameFilm = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbGenre = new CheckComboBoxTest.CheckedComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Menu;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(419, 253);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 37);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(207, 253);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 37);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbGenre
            // 
            this.lbGenre.AutoSize = true;
            this.lbGenre.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbGenre.Location = new System.Drawing.Point(28, 188);
            this.lbGenre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGenre.Name = "lbGenre";
            this.lbGenre.Size = new System.Drawing.Size(65, 24);
            this.lbGenre.TabIndex = 16;
            this.lbGenre.Text = "Жанр:";
            // 
            // NumYear
            // 
            this.NumYear.Location = new System.Drawing.Point(220, 139);
            this.NumYear.Margin = new System.Windows.Forms.Padding(4);
            this.NumYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.NumYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.NumYear.Name = "NumYear";
            this.NumYear.Size = new System.Drawing.Size(160, 22);
            this.NumYear.TabIndex = 15;
            this.NumYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblYear.Location = new System.Drawing.Point(28, 139);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(127, 24);
            this.lblYear.TabIndex = 14;
            this.lblYear.Text = "Год выпуска:";
            // 
            // Director
            // 
            this.Director.Location = new System.Drawing.Point(220, 89);
            this.Director.Margin = new System.Windows.Forms.Padding(4);
            this.Director.Name = "Director";
            this.Director.Size = new System.Drawing.Size(332, 22);
            this.Director.TabIndex = 13;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDirector.Location = new System.Drawing.Point(28, 89);
            this.lblDirector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(101, 24);
            this.lblDirector.TabIndex = 12;
            this.lblDirector.Text = "Режиссер:";
            // 
            // NameFilm
            // 
            this.NameFilm.Location = new System.Drawing.Point(220, 40);
            this.NameFilm.Margin = new System.Windows.Forms.Padding(4);
            this.NameFilm.Name = "NameFilm";
            this.NameFilm.Size = new System.Drawing.Size(332, 22);
            this.NameFilm.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(28, 40);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 24);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Название фильма:";
            // 
            // cmbGenre
            // 
            this.cmbGenre.CheckOnClick = true;
            this.cmbGenre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbGenre.DropDownHeight = 1;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.IntegralHeight = false;
            this.cmbGenre.Location = new System.Drawing.Point(220, 184);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(332, 23);
            this.cmbGenre.TabIndex = 22;
            this.cmbGenre.ValueSeparator = ", ";
            // 
            // FilmEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(590, 325);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbGenre);
            this.Controls.Add(this.NumYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.Director);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.NameFilm);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(608, 372);
            this.MinimumSize = new System.Drawing.Size(608, 372);
            this.Name = "FilmEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить";
            ((System.ComponentModel.ISupportInitialize)(this.NumYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbGenre;
        private System.Windows.Forms.NumericUpDown NumYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox Director;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox NameFilm;
        private System.Windows.Forms.Label lblTitle;
        private CheckComboBoxTest.CheckedComboBox cmbGenre;
    }
}