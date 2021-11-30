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
    public partial class EditClientService : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=YP;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        ClientService it;
        public EditClientService(int id)
        {
            InitializeComponent();
            it = context.GetTable<ClientService>().FirstOrDefault(x => x.ID == id);
            comboBox1.DataSource = context.GetTable<Client>().ToList();
            comboBox1.DisplayMember = "LastName";
            comboBox1.ValueMember = "ID";
            comboBox2.DataSource = context.GetTable<Service>().ToList();
            comboBox2.DisplayMember = "Title";
            comboBox2.ValueMember = "ID";
            comboBox1.SelectedValue = it.ClientID;
            comboBox2.SelectedValue = it.ServiceID;
            dateTimePicker1.Value = it.StartTime;
            textBox1.Text = it.Comment;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditClientService_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "yPDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.yPDataSet.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "yPDataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.yPDataSet.Service);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Изменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                it.ClientID = Convert.ToInt32(comboBox1.SelectedValue);
                it.ServiceID = Convert.ToInt32(comboBox1.SelectedValue);
                it.StartTime = dateTimePicker1.Value;
                it.Comment = textBox1.Text;
                context.SubmitChanges();
                this.Close();
            }
        }
    }
}
