using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Linq;
using System.Data.SqlClient;

namespace Подай_на_16
{
    public partial class Podai_na_16 : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        int clientID = 0;
        int serviceID = 0;
        int clientServiceID = 0;
        public Podai_na_16()
        {
            InitializeComponent();
            Table<ClientService> CliSer = context.GetTable<ClientService>();
            dataGridView1.DataSource = CliSer.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 3;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox1.Text = "Поиск";
                Table<Gender> gender = context.GetTable<Gender>();//выбор таблицы
                dataGridView1.DataSource = gender.ToList();//вывод таблицы в dataGridView
            }
            if (comboBox1.SelectedIndex == 1)
            {
                groupBox1.Text = "Поиск по LastName";
                Table<Client> product = context.GetTable<Client>();//выбор таблицы
                dataGridView1.DataSource = product.ToList();//вывод таблицы в dataGridView
            }
            if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Text = "Поиск по Title";
                Table<Service> acc = context.GetTable<Service>();//выбор таблицы
                dataGridView1.DataSource = acc.ToList();//вывод таблицы в dataGridView
            }
            if (comboBox1.SelectedIndex == 3)
            {
                groupBox1.Text = "Поиск по ClientID";
                Table<ClientService> CliSer = context.GetTable<ClientService>();//выбор таблицы
                dataGridView1.DataSource = CliSer.ToList();//вывод таблицы в dataGridView
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
            if (comboBox1.SelectedIndex == 1)
            {
                var v = context.GetTable<Client>().Where(x => x.LastName.Contains(textBox1.Text));
                dataGridView1.DataSource = v.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                var v = context.GetTable<Service>().Where(x => x.Title.Contains(textBox1.Text));
                dataGridView1.DataSource = v.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                string sql = "Select *From [ClientService] Where [ClientID] Like N'%" + textBox1.Text + "%' ";
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(conStr);
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                AddClient F1 = new AddClient();
                F1.Show();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                AddService F2 = new AddService();
                F2.Show();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                AddClientService F3 = new AddClientService();
                F3.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox1.Text = "Поиск";
                Table<Gender> gender = context.GetTable<Gender>();//выбор таблицы
                dataGridView1.DataSource = gender.ToList();//вывод таблицы в dataGridView
            }
            if (comboBox1.SelectedIndex == 1)
            {
                groupBox1.Text = "Поиск по LastName";
                Table<Client> product = context.GetTable<Client>();//выбор таблицы
                dataGridView1.DataSource = product.ToList();//вывод таблицы в dataGridView
            }
            if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Text = "Поиск по Title";
                Table<Service> acc = context.GetTable<Service>();//выбор таблицы
                dataGridView1.DataSource = acc.ToList();//вывод таблицы в dataGridView
            }
            if (comboBox1.SelectedIndex == 3)
            {
                groupBox1.Text = "Поиск по ClientID";
                Table<ClientService> CliSer = context.GetTable<ClientService>();//выбор таблицы
                dataGridView1.DataSource = CliSer.ToList();//вывод таблицы в dataGridView
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Enter F4 = new Enter();
                this.Hide();
                F4.Show();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    Gender DeliteGender = context.GetTable<Gender>().OrderByDescending(x => x.Code).FirstOrDefault();
                    context.GetTable<Gender>().DeleteOnSubmit(DeliteGender);
                    context.SubmitChanges();
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    Client DeliteClient = context.GetTable<Client>().OrderByDescending(x => x.ID).FirstOrDefault();
                    context.GetTable<Client>().DeleteOnSubmit(DeliteClient);
                    context.SubmitChanges();
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    Service DeliteService = context.GetTable<Service>().OrderByDescending(x => x.ID).FirstOrDefault();
                    context.GetTable<Service>().DeleteOnSubmit(DeliteService);
                    context.SubmitChanges();
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {  
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    ClientService DeliteClientService = context.GetTable<ClientService>().OrderByDescending(x => x.ID).FirstOrDefault();
                    context.GetTable<ClientService>().DeleteOnSubmit(DeliteClientService);
                    context.SubmitChanges();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 && clientID != 0)
            {
                EditClient F = new EditClient(clientID);
                F.ShowDialog();
                clientID = 0;
            }
            if (comboBox1.SelectedIndex == 2 && serviceID != 0)
            {
                EditService F = new EditService(serviceID);
                F.ShowDialog();
                serviceID = 0;
            }
            if (comboBox1.SelectedIndex == 3 && clientServiceID != 0)
            {
                EditClientService F = new EditClientService(clientServiceID);
                F.ShowDialog();
                clientServiceID = 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                clientID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                serviceID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                clientServiceID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Shop F = new Shop();
            this.Hide();
            F.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Shop F = new Shop();
            this.Hide();
            F.Show();
        }
    }
}
