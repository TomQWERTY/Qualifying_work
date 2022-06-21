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
        Create,
        Set
    }

    public partial class FormPassword : Form
    {
        Form1 form1;
        Mode mode;
        Npg npg;

        public FormPassword(Form1 f1, Mode m)
        {
            form1 = f1;
            mode = m;
            npg = form1.npg;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Login:
                    {
                        this.Text = "Вхід";
                        break;
                    }
                case Mode.Change:
                    {
                        this.Text = "Зміна паролю";
                        checkBoxHidePassword.Top += textBoxLogin.Top - textBoxPass.Top;
                        buttonSignin.Top += textBoxLogin.Top - textBoxPass.Top;
                        textBoxPass.Top = textBoxLogin.Top;
                        textBoxLogin.Visible = false;
                        labelLogin.Visible = false;
                        labelPass.Visible = false;
                        labelOldPass.Visible = true;
                        this.Height = 133;
                        break;
                    }
            }
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
            npg.StartWork();
            switch (mode)
            {
                case (Mode.Login):
                    {
                        DataTable res = npg.Query("select * from users where username=\'" + textBoxLogin.Text + "\'");
                        if (res.Rows.Count > 0)
                        {
                            rightPassword = res.Rows[0][2].ToString();
                            if (hashedPassword == rightPassword)
                            {
                                form1.user = new User(Convert.ToInt32(res.Rows[0][0]), textBoxLogin.Text, Convert.ToBoolean(res.Rows[0][3]));
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
                        break;
                    }
                case (Mode.Change):
                    {
                        rightPassword =
                            npg.Query("select password from users where username=\'" + form1.user.UserName + "\'").Rows[0][0].ToString();
                        if (hashedPassword == rightPassword)
                        {
                            mode = Mode.Set;
                            labelOldPass.Visible = false;
                            labelNewPass.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Невірний пароль!");
                        }
                        break;
                    }
                case (Mode.Set):
                    {
                        npg.Query("update users set password=\'" + hashedPassword + "\' where username=\'" + form1.user.UserName + "\'");
                        this.DialogResult = DialogResult.OK;
                        break;
                    }
                case (Mode.Create):
                    {
                        try
                        {
                            if (npg.Query("insert into users(username, password, is_admin)" +
                            " values(\'" + textBoxLogin.Text + "\', \'" + hashedPassword + "\', false)") != null)
                            {
                                form1.user = new User(Convert.ToInt32(npg.Query("select id from users where username=\'" +
                                    textBoxLogin.Text + "\'").Rows[0][0]), textBoxLogin.Text, false);
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == "login_taken")
                            {
                                MessageBox.Show("Помилка! Даний логін вже зайнятий.");
                            }
                            npg.FinishWork();
                        }
                        break;
                    }
            }
            npg.FinishWork();
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