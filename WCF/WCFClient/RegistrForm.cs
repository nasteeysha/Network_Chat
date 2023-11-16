using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class RegistrForm : Form
    {
        Client client = new Client();
        public RegistrForm()
        {
            InitializeComponent();
            textBox1.Text = "Введите логин";
            textBox2.Text = "Введите пароль";
            textBox1.ForeColor = Color.Indigo;
            textBox2.ForeColor = Color.Indigo;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Indigo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usrlogin = textBox1.Text;
            var password = textBox2.Text;
            int key = client.RegistrationClient(usrlogin, password);
            if (key == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                AvtForm login_form = new AvtForm();
                this.Hide();
                login_form.ShowDialog();
            }
            else
            if (key == 0)
            {
                MessageBox.Show("Аккаунт с таким именем уже существует");
            }
            else
            {
                MessageBox.Show("Не получилось создать");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите пароль")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Indigo;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Indigo;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите пароль")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Indigo;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Введите пароль";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите логин";
                textBox1.ForeColor = Color.Gray;
            }
        }
    }
}
