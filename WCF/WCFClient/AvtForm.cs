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
    public partial class AvtForm : Form
    {
        public AvtForm()
        {
            InitializeComponent();
            textBox1.Text = "Введите логин";
            textBox2.Text = "Введите пароль";
            textBox1.ForeColor = Color.Indigo;
            textBox2.ForeColor = Color.Indigo;
            
        }

        Client client = new Client();

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;
            try
            {

                var key = client.LoginClient(loginUser, passUser);

                if (key == 1)
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    TableForm form = new TableForm();
                    
                    //this.Hide();
                    form.ShowDialog();
                    

                }
                else if (key == 0)
                {
                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception) { MessageBox.Show("Упс, ошибка!"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Indigo;
            }
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


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите логин";
                textBox1.ForeColor = Color.Indigo;
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Введите пароль";
                textBox2.ForeColor = Color.Indigo;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrForm sign_form = new RegistrForm();
            sign_form.Show();
            //this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
