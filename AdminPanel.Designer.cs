namespace CourseWork
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.Report = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.PanelFilm = new System.Windows.Forms.Button();
            this.PanelGenre = new System.Windows.Forms.Button();
            this.CheckUser = new System.Windows.Forms.Button();
            this.AddDisck = new System.Windows.Forms.Button();
            this.AddFilmOnDisck = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Report
            // 
            this.Report.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Report.Location = new System.Drawing.Point(558, 171);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(171, 59);
            this.Report.TabIndex = 14;
            this.Report.Text = "Создание отчётов";
            this.Report.UseVisualStyleBackColor = false;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(356, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 37);
            this.label2.TabIndex = 13;
            this.label2.Text = "Администратор";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Black;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Exit.Location = new System.Drawing.Point(770, 482);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(108, 63);
            this.Exit.TabIndex = 12;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // PanelFilm
            // 
            this.PanelFilm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PanelFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelFilm.Location = new System.Drawing.Point(234, 171);
            this.PanelFilm.Name = "PanelFilm";
            this.PanelFilm.Size = new System.Drawing.Size(173, 59);
            this.PanelFilm.TabIndex = 15;
            this.PanelFilm.Text = "Управление фильмами";
            this.PanelFilm.UseVisualStyleBackColor = false;
            this.PanelFilm.Click += new System.EventHandler(this.PanelFilm_Click);
            // 
            // PanelGenre
            // 
            this.PanelGenre.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PanelGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelGenre.Location = new System.Drawing.Point(558, 266);
            this.PanelGenre.Name = "PanelGenre";
            this.PanelGenre.Size = new System.Drawing.Size(171, 61);
            this.PanelGenre.TabIndex = 16;
            this.PanelGenre.Text = "Управление жанрами";
            this.PanelGenre.UseVisualStyleBackColor = false;
            this.PanelGenre.Click += new System.EventHandler(this.PanelGenre_Click);
            // 
            // CheckUser
            // 
            this.CheckUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CheckUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckUser.Location = new System.Drawing.Point(234, 266);
            this.CheckUser.Name = "CheckUser";
            this.CheckUser.Size = new System.Drawing.Size(173, 61);
            this.CheckUser.TabIndex = 17;
            this.CheckUser.Text = "Управление клиентами";
            this.CheckUser.UseVisualStyleBackColor = false;
            this.CheckUser.Click += new System.EventHandler(this.CheckUser_Click);
            // 
            // AddDisck
            // 
            this.AddDisck.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddDisck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDisck.Location = new System.Drawing.Point(234, 361);
            this.AddDisck.Name = "AddDisck";
            this.AddDisck.Size = new System.Drawing.Size(173, 61);
            this.AddDisck.TabIndex = 18;
            this.AddDisck.Text = "Управление носителем";
            this.AddDisck.UseVisualStyleBackColor = false;
            this.AddDisck.Click += new System.EventHandler(this.AddDisck_Click);
            // 
            // AddFilmOnDisck
            // 
            this.AddFilmOnDisck.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddFilmOnDisck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFilmOnDisck.Location = new System.Drawing.Point(558, 361);
            this.AddFilmOnDisck.Name = "AddFilmOnDisck";
            this.AddFilmOnDisck.Size = new System.Drawing.Size(171, 61);
            this.AddFilmOnDisck.TabIndex = 20;
            this.AddFilmOnDisck.Text = "Управление прокатами";
            this.AddFilmOnDisck.UseVisualStyleBackColor = false;
            this.AddFilmOnDisck.Click += new System.EventHandler(this.AddFilmOnDisck_Click);
            // 
            // Admin
            // 
            this.Admin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin.BackgroundImage")));
            this.Admin.Location = new System.Drawing.Point(52, 471);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(108, 74);
            this.Admin.TabIndex = 21;
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(48, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "О проекте*";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(958, 575);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.AddFilmOnDisck);
            this.Controls.Add(this.AddDisck);
            this.Controls.Add(this.CheckUser);
            this.Controls.Add(this.PanelGenre);
            this.Controls.Add(this.PanelFilm);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(976, 622);
            this.MinimumSize = new System.Drawing.Size(976, 622);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPanel_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Report;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button PanelFilm;
        private System.Windows.Forms.Button PanelGenre;
        private System.Windows.Forms.Button CheckUser;
        private System.Windows.Forms.Button AddDisck;
        private System.Windows.Forms.Button AddFilmOnDisck;
        private System.Windows.Forms.Button Admin;
        private System.Windows.Forms.Label label1;
    }
}