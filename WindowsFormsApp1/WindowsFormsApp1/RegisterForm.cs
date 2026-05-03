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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new HttpClient();

        private async void button1_Click(object sender, EventArgs e)
        {
            var user = new
            {
                login = textLogin.Text,
                password = textPassword.Text,
                lastName = textLastName.Text,
                firstName = textFirstName.Text,
                middleName = textMiddleName.Text,
                email = textEmail.Text
            };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "https://localhost:7209/api/auth/register",
                content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();

                var createdUser = JsonConvert.DeserializeObject<User>(responseJson);

                if (createdUser == null)
                {
                    MessageBox.Show("Ошибка при получении пользователя");
                    return;
                }

                await AddPhoneNumber(createdUser.UserID);

                MessageBox.Show("Регистрация успешна!");

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Ошибка: " + error);
            }
        }
        private async Task AddPhoneNumber(int userId)
        {
            var phone = new
            {
                userID = userId,
                number = maskedTextBox1.Text
            };

            var json = JsonConvert.SerializeObject(phone);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "https://localhost:7209/api/phonenumber",
                content);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Ошибка при добавлении телефона");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();

            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
