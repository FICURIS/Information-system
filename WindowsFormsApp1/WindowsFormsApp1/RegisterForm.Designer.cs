namespace WindowsFormsApp1
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textLastName = new System.Windows.Forms.MaskedTextBox();
            this.textFirstName = new System.Windows.Forms.MaskedTextBox();
            this.textMiddleName = new System.Windows.Forms.MaskedTextBox();
            this.textEmail = new System.Windows.Forms.MaskedTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(249, 45);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(119, 22);
            this.textLogin.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(249, 92);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(119, 22);
            this.textPassword.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Регистрация";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Имя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Отчество";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email";
            // 
            // textLastName
            // 
            this.textLastName.Location = new System.Drawing.Point(249, 132);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(119, 22);
            this.textLastName.TabIndex = 9;
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(249, 174);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(119, 22);
            this.textFirstName.TabIndex = 10;
            // 
            // textMiddleName
            // 
            this.textMiddleName.Location = new System.Drawing.Point(249, 220);
            this.textMiddleName.Name = "textMiddleName";
            this.textMiddleName.Size = new System.Drawing.Size(119, 22);
            this.textMiddleName.TabIndex = 11;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(249, 262);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(119, 22);
            this.textEmail.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(708, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 39);
            this.button5.TabIndex = 13;
            this.button5.Text = "Выход";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textMiddleName);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.textLastName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.MaskedTextBox textPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox textLastName;
        private System.Windows.Forms.MaskedTextBox textFirstName;
        private System.Windows.Forms.MaskedTextBox textMiddleName;
        private System.Windows.Forms.MaskedTextBox textEmail;
        private System.Windows.Forms.Button button5;
    }
}