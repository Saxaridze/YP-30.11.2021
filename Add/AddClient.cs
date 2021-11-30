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
    public partial class AddClient : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=YP;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public AddClient()
        {
            InitializeComponent();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "yPDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.yPDataSet.Gender);

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
                Client NewClient = new Client { FirstName = textBox1.Text, LastName = textBox2.Text, Patronymic = textBox3.Text, Birthday = dateTimePicker1.Value, RegistrationDate = dateTimePicker2.Value, Email = textBox4.Text, Phone = textBox5.Text, GenderCode = Convert.ToString(comboBox1.SelectedValue), PhotoPath = textBox6.Text };
                context.GetTable<Client>().InsertOnSubmit(NewClient);
                context.SubmitChanges();
                this.Close();
            }
        }
    }
}
