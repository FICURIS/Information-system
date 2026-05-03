using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ManageCoursesForm : Form
    {
        public ManageCoursesForm()
        {
            InitializeComponent();
        }

        

        private void ManageCoursesForm_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new CourseEditForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadCourses();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                MessageBox.Show("Выберите курс");
                return;
            }
            var course = (Course)dataGridView1.CurrentRow.DataBoundItem;
            var form = new CourseEditForm(course);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadCourses();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            var course = (Course)dataGridView1.CurrentRow.DataBoundItem;
            var confirm = MessageBox.Show("Удалить курс?", "Подтверждение", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _httpClient.DeleteAsync($"https://localhost:7209/api/course/{course.courseID}");
                await LoadCourses();
            }
        }

        private readonly HttpClient _httpClient = new HttpClient();

        private async Task LoadCourses()
        {
            var responce = await _httpClient.GetAsync("https://localhost:7209/api/course");

            if (responce.IsSuccessStatusCode)
            {
                var json = await responce.Content.ReadAsStringAsync();
                var courses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Course>>(json);

                dataGridView1.DataSource = courses;
            }
        }
    }
}