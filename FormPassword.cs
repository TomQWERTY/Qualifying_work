using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Qualifying_work
{
    public enum Mode
    {
        Login,
        Change,
        Set
    }

    public partial class FormPassword : Form
    {
        Form1 form1;
        Mode mode;
        Npg npg;
        int attempts;

        public FormPassword(Form1 f1, Mode m)
        {
            form1 = f1;
            mode = m;
            //form1.FormClosed += (object sender, FormClosedEventArgs e) => this.Close();
            npg = form1.npg;
            attempts = 0;
            InitializeComponent();
        }

        private void buttonSignin_Click(object sender, EventArgs e)
        {
            string rightPassword = "";
            string enteredPassword = textBoxPass.Text;
            byte[] passwordBytes = Encoding.Unicode.GetBytes(enteredPassword);
            SHA512 shaM = new SHA512Managed();
            byte[] hashedPasswordBytes = shaM.ComputeHash(passwordBytes);
            string hashedPassword = "";
            foreach (byte b in hashedPasswordBytes)
            {
                hashedPassword += string.Format("{0:x2}", b);
            }
            switch (mode)
            {
                case (Mode.Login):
                    {
                        npg.StartWork();
                        DataTable res = npg.Query("select password, is_admin from users where username=\'" + textBoxLogin.Text + "\'");
                        if (res.Rows.Count > 0)
                        {
                            rightPassword = res.Rows[0][0].ToString();
                            if (hashedPassword == rightPassword)
                            {
                                form1.user = new User(textBoxLogin.Text, Convert.ToBoolean(res.Rows[0][1]));
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("Помилка! Невірний пароль.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Помилка! Користувача з даним логіном не існує.");
                        }
                        npg.FinishWork();
                        break;
                    }
                case (Mode.Change):
                    {
                        rightPassword = npg.Query("select * from passwords").Rows[0][0].ToString();
                        if (hashedPassword == rightPassword)
                        {
                            textBoxPass.Text = "";
                            labelPass.Text = "Введіть новий пароль";
                            labelPass.Location = new Point((this.Width - 20) / 2 - labelPass.Width / 2, labelPass.Location.Y);
                            mode = Mode.Set;
                        }
                        else
                        {
                            MessageBox.Show("Невірний пароль!");
                            attempts++;
                            if (attempts > 3)
                            {
                                textBoxPass.Text = "";
                                textBoxPass.Enabled = false;
                                buttonSignin.Enabled = false;
                            }
                        }
                        break;
                    }
                case (Mode.Set):
                    {
                        npg.StartWork();
                        if (npg.Query("insert into users(username, password) values(\'" + textBoxLogin.Text + "\', \'" + hashedPassword + "\')") != null)
                        {
                            form1.user = new User(textBoxLogin.Text, false);
                            this.DialogResult = DialogResult.OK;
                        }
                        npg.FinishWork();
                        break;
                    }
            }  
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            textBoxPass.Text = "";
            labelPass.Text = "Введіть поточний пароль";
            labelPass.Location = new Point((this.Width - 20) / 2 - labelPass.Width / 2, labelPass.Location.Y);
            mode = Mode.Change;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mode = Mode.Login;
            textBoxPass.Text = "";
            labelPass.Text = "Пароль";
            labelPass.Location = new Point((this.Width - 20) / 2 - labelPass.Width / 2, labelPass.Location.Y);
        }

        private void checkBoxHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHidePassword.Checked)
            {
                textBoxPass.PasswordChar = '*';
            }
            else
            {
                textBoxPass.PasswordChar = Convert.ToChar(Char.ConvertFromUtf32(0));
            }
        }
    }
}