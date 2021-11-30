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
    public partial class AddService : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public AddService()
        {
            InitializeComponent();
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
                Service NewService = new Service { Title = textBox1.Text, Cost = Convert.ToDecimal(textBox2.Text), DurationInSeconds = Convert.ToInt32(textBox3.Text), Description = textBox4.Text, Discount = Convert.ToDecimal(textBox5.Text), MainImagePath = textBox6.Text };
                context.GetTable<Service>().InsertOnSubmit(NewService);
                context.SubmitChanges();
            }
        }
    }
}
