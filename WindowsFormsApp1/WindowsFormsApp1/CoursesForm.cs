using Newtonsoft.Json;
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
    public partial class CoursesForm : Form
    {
        public CoursesForm()
        {
            InitializeComponent();
        }

        private async void CoursesForm_Load(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private readonly HttpClient _httpClient = new HttpClient();
        private async Task LoadCourses()
        {

            var response = await _httpClient.GetStringAsync("https://localhost:7209/api/course");
            var courses = JsonConvert.DeserializeObject<List<Course>>(response);

            dataGridView1.DataSource = courses;

            dataGridView1.Columns["CourseID"].Visible = false;
            dataGridView1.Columns["CourseName"].HeaderText = "Название";
            dataGridView1.Columns["StartDate"].HeaderText = "Дата начала";
            dataGridView1.Columns["EndDate"].HeaderText = "Дата окончания";
            dataGridView1.Columns["Description"].HeaderText = "Описание";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите курс.");
                return;
            }

            var course = (Course)dataGridView1.CurrentRow.DataBoundItem;

            var request = new
            {
                userID = Session.UserId,
                courseID = course.courseID,
                statusID = 1,
                createdDate = DateTime.UtcNow
            };
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);

                var response = await _httpClient.PostAsync("https://localhost:7209/api/request", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Заявка успешно отправлена!");
                }
                else
                {
                    MessageBox.Show("Ошибка при отправке заявки: " + response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
