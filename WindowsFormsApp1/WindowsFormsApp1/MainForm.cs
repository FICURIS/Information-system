using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm(string token)
        {
            InitializeComponent();
            _token = token;

            ParseToken();
            SetupByRole();
        }

        private void ParseToken()
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(_token);

            var userIdClaim = jwt.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim != null)
                _userId = int.Parse(userIdClaim.Value);

            var roleClain = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            _role = roleClain?.Value ?? "User";
        }

        private void SetupByRole()
        {
            if (_role != "Admin")
            {
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void OpenForm(Form form)
        {
            panel3.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel3.Controls.Add(form);
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private string _token;
        private int _userId;
        private string _role;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm(new CoursesForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new MyRequestsForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenForm(new ManageCoursesForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenForm(new AllRequestsForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();

            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
