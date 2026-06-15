namespace CourseWork
{
    partial class GenreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenreForm));
            this.UpdateGenre = new System.Windows.Forms.Button();
            this.DeleteGenre = new System.Windows.Forms.Button();
            this.AddGenre = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateGenre
            // 
            this.UpdateGenre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UpdateGenre.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.UpdateGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateGenre.Location = new System.Drawing.Point(762, 353);
            this.UpdateGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateGenre.Name = "UpdateGenre";
            this.UpdateGenre.Size = new System.Drawing.Size(129, 58);
            this.UpdateGenre.TabIndex = 22;
            this.UpdateGenre.Text = "Обновить";
            this.UpdateGenre.UseVisualStyleBackColor = false;
            this.UpdateGenre.Click += new System.EventHandler(this.UpdateGenre_Click);
            // 
            // DeleteGenre
            // 
            this.DeleteGenre.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DeleteGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteGenre.Location = new System.Drawing.Point(762, 251);
            this.DeleteGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteGenre.Name = "DeleteGenre";
            this.DeleteGenre.Size = new System.Drawing.Size(129, 58);
            this.DeleteGenre.TabIndex = 21;
            this.DeleteGenre.Text = "Удалить ";
            this.DeleteGenre.UseVisualStyleBackColor = false;
            this.DeleteGenre.Click += new System.EventHandler(this.DeleteGenre_Click);
            // 
            // AddGenre
            // 
            this.AddGenre.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddGenre.Location = new System.Drawing.Point(762, 158);
            this.AddGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddGenre.Name = "AddGenre";
            this.AddGenre.Size = new System.Drawing.Size(129, 53);
            this.AddGenre.TabIndex = 20;
            this.AddGenre.Text = "Добавить";
            this.AddGenre.UseVisualStyleBackColor = false;
            this.AddGenre.Click += new System.EventHandler(this.AddGenre_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Back.Location = new System.Drawing.Point(40, 486);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(93, 60);
            this.Back.TabIndex = 18;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(73, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(640, 370);
            this.dataGridView1.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(66, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 37);
            this.label4.TabIndex = 24;
            this.label4.Text = "Жанры";
            // 
            // GenreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(943, 575);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UpdateGenre);
            this.Controls.Add(this.DeleteGenre);
            this.Controls.Add(this.AddGenre);
            this.Controls.Add(this.Back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(961, 622);
            this.MinimumSize = new System.Drawing.Size(961, 622);
            this.Name = "GenreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genre";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenreForm_FormClosing);
            this.Load += new System.EventHandler(this.GenreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateGenre;
        private System.Windows.Forms.Button DeleteGenre;
        private System.Windows.Forms.Button AddGenre;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
    }
}