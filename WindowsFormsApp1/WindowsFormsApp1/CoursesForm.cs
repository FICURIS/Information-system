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


    }
}
