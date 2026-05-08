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
    public partial class MyRequestsForm : Form
    {
        public MyRequestsForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private readonly HttpClient _httpClient = new HttpClient();

        private async Task LoadRequests()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);
                var response = await _httpClient.GetStringAsync($"https://localhost:7209/api/requests/user/{Session.UserId}");
                
                var requests = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Request>>(response);

                var tableData = requests.Select(r => new
                {
                    Курс = r.Course?.courseName,
                    Статус = r.Status?.StatusName
                }).ToList();

                if (requests == null || requests.Count == 0)
                {
                    MessageBox.Show("Заявок нет");
                    return;
                }

                dataGridView1.DataSource = tableData;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
        private async void MyRequestsForm_Load(object sender, EventArgs e)
        {
            await LoadRequests();
        }
    }
}
