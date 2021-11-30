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
    public partial class AddClientService : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public AddClientService()
        {
            InitializeComponent();
        }

        private void AddClientService_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_1234DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this._1234DataSet.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_1234DataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this._1234DataSet.Client);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Добавить", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                ClientService NewClientService = new ClientService { ClientID = Convert.ToInt32(comboBox1.SelectedValue), ServiceID = Convert.ToInt32(comboBox2.SelectedValue), StartTime = dateTimePicker1.Value, Comment = textBox1.Text };
                context.GetTable<ClientService>().InsertOnSubmit(NewClientService);
                context.SubmitChanges();
            }
        }
    }
}
