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
    public partial class TableForm : Form
    {
        

        //public static string connStr = @"Data Source=LAPTOP-NQ4AHNK7;Initial Catalog=l3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

       
        Client client = new Client();
       
       

        public TableForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = client.GetmyDataClient();
            dataGridView1.Columns[0].Visible = false;

            
        }
        

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = dataGridView1.CurrentCell.RowIndex;
            var edform = new EditForm(id);
            if (edform.ShowDialog(this) == DialogResult.OK)
            {
                dataGridView1.DataSource = client.GetmyDataClient();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int ThisRow = dataGridView1.CurrentCell.RowIndex;
                int id = int.Parse(dataGridView1["id", ThisRow].EditedFormattedValue.ToString());
                string name = client.ProcClient(id);
                DialogResult res = MessageBox.Show(name, "Вы уверены, что хотите удалить этот объект?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    client.DeleteClient(id);
                    dataGridView1.DataSource = client.GetmyDataClient();
                }
            }
            else
            {
                MessageBox.Show("Ошибка!", "Вы не выбрали данные для удаления! Проверьте правильность выбранных полей и повторите попытку снова.");
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var form3 = new EditForm();
                if (form3.ShowDialog(this) == DialogResult.OK)
                {
                    dataGridView1.DataSource = client.GetmyDataClient();
                }
            }
            else
            {
                MessageBox.Show("Ошибка!", "Вы не выбрали данные для редактирования! Проверьте правильность выбранных полей и повторите попытку снова.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = client.RefreshViewClient((string)textBox1.Text);
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
