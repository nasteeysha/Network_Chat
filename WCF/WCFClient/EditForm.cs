using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class EditForm : Form
    {

        
        /// public static string connStr = @"Data Source=LAPTOP-NQ4AHNK7;Initial Catalog=second;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        

        //должен быть экземпляр данного класса
        Client client = new Client();
        Car fcar = new Car();
        public int temp;

        public EditForm(int id)
        {
            InitializeComponent();
            temp = id;
            textBox2.Text = client.GetmyDataClient().Rows[id][2].ToString();
            
            textBox1.Text = client.GetmyDataClient().Rows[id][1].ToString();
            textBox3.Text = client.GetmyDataClient().Rows[id][3].ToString();

            textBox4.Text = client.GetmyDataClient().Rows[id][4].ToString();
            textBox5.Text = client.GetmyDataClient().Rows[id][5].ToString();


        }
        public EditForm()
        {
            InitializeComponent();
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fcar.CARBRAND = textBox1.Text;
                fcar.CARPRICE = int.Parse(textBox2.Text);
                fcar.DATAPROIZVODSTVA = int.Parse(textBox3.Text);
                fcar.PROBEG = int.Parse(textBox4.Text);
                fcar.SELLER = textBox5.Text;


                client.InsertClient(fcar);
                this.DialogResult = DialogResult.OK;
            }

           
            
            catch
            {
                MessageBox.Show("Ошибка!", "Вы ввели данные в неправильном формате, проверьте правильность введенных данных и повторите попытку.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int ibd = (int)client.GetmyDataClient().Rows[temp][0];
                
                fcar.CARBRAND = textBox1.Text;
                fcar.CARPRICE = int.Parse(textBox2.Text);
                fcar.DATAPROIZVODSTVA = int.Parse(textBox3.Text);
                fcar.PROBEG = int.Parse(textBox4.Text);
                fcar.SELLER = textBox5.Text;

                client.UpdateClient(fcar, ibd);

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Вы ввели данные в неправильном формате, проверьте правильность введенных данных и повторите попытку.");
            }
        }

       
    }
}
