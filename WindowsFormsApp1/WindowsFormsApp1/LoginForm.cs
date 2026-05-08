using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    
    public partial class LoginForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var loginData = new
            {
                login = textLogin.Text,
                password = textPassword.Text
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "https://localhost:7209/api/auth/login",
                content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(responseJson);
                string token = data.token;

                Session.Token = token;
                var obj = JObject.Parse(responseJson);
                Session.Token = obj["token"].ToString();

                var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(Session.Token);

                Session.UserId = int.Parse(
                    jwt.Claims.First(c => c.Type == "UserId").Value
                );

                MessageBox.Show("Успешный вход!");
                var main = new MainForm(Session.Token);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }

}
