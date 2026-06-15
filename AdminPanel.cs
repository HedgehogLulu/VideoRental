using System;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AdminPanel : Form
    {
        private Form1 parentForm;
        private FilmForm filmForm;
        private DisckManagementForm disck;
        private ViewUser User;
        private GenreForm genre;
        private Report GenerationReport;
        private RentalForm Rental;
        private Admin Admini;
        public AdminPanel(Form1 parent)
        {
            InitializeComponent();
            parentForm = parent; // Сохраняем ссылку на родительскую форму
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void PanelFilm_Click(object sender, EventArgs e)
        {
            if (filmForm == null || filmForm.IsDisposed)
            {
                filmForm = new FilmForm(this);
            }
            filmForm.Show();
            this.Hide();
        }

        private void AddDisck_Click(object sender, EventArgs e)
        {
            if (disck == null || disck.IsDisposed)
            {
                disck = new DisckManagementForm(this);
            }
            disck.Show();
            this.Hide();
        }

        private void CheckUser_Click(object sender, EventArgs e)
        {
            if (User == null || User.IsDisposed)
            {
                User = new ViewUser(this);
            }
            User.Show();
            this.Hide();
        }

        private void PanelGenre_Click(object sender, EventArgs e)
        {
            if (genre == null || genre.IsDisposed)
            {
                genre = new GenreForm(this);
            }
            genre.Show();
            this.Hide();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            if (GenerationReport == null || GenerationReport.IsDisposed)
            {
                GenerationReport= new Report(this);
            }
            GenerationReport.Show();
            this.Hide();
        }

        private void AddFilmOnDisck_Click(object sender, EventArgs e)
        {
            if (Rental == null || Rental.IsDisposed)
            {
                Rental = new RentalForm(this);
            }
            Rental.Show();
            this.Hide();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            if (Admini == null || Admini.IsDisposed)
            {
                Admini = new Admin(this);
            }
            Admini.Show();
        }
    }
}