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
    public partial class CourseEditForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private Course _course;
        public CourseEditForm(Course course)
        {
            InitializeComponent();
            _course = course;

            textBox1.Text = course.courseName;
            dateTimePicker1.Value = course.startDate;
            dateTimePicker2.Value = course.endDate;
            textBox4.Text = course.description;
        }
        public CourseEditForm()
        {
            InitializeComponent();
        }

        private void CourseEditForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Дата окончания не может быть меньше даты начала");
                return;
            }

            var courseData = new
            {
                courseName = textBox1.Text,
                startDate = dateTimePicker1.Value.ToUniversalTime(),
                endDate = dateTimePicker2.Value.ToUniversalTime(),
                description = textBox4.Text
            };

            var json = JsonConvert.SerializeObject(courseData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (_course == null)
            {
                await _httpClient.PostAsync("https://localhost:7209/api/Course", content);
            }
            else
            {
                await _httpClient.PutAsync($"https://localhost:7209/api/Course/{_course.courseID}", content);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
