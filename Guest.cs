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
    public partial class Guest : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public Guest()
        {
            InitializeComponent();
            Table<ClientService> CliSer = context.GetTable<ClientService>();
            dataGridView1.DataSource = CliSer.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox1.Text = "Поиск";
                Table<Gender> gender = context.GetTable<Gender>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                groupBox1.Text = "Поиск по LastName";
                Table<Client> product = context.GetTable<Client>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Text = "Поиск по Title";
                Table<Service> acc = context.GetTable<Service>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                groupBox1.Text = "Поискпо ClientID";
                Table<ClientService> CliSer = context.GetTable<ClientService>();
                dataGridView1.DataSource = CliSer.ToList();
            }
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 3;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
            if (comboBox1.SelectedIndex == 0)
            {
                var v = context.GetTable<Gender>().Where(x => x.Name.Contains(textBox1.Text));
                dataGridView1.DataSource = v.ToList();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Shop F = new Shop();
            this.Hide();
            F.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enter F1 = new Enter();
            this.Hide();
            F1.Show();
        }
    }
}
