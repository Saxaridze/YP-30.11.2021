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
    public partial class EditService : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1234;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        Service it;
        public EditService(int id)
        {
            InitializeComponent();
            it = context.GetTable<Service>().FirstOrDefault(x => x.ID == id);
            textBox1.Text = it.Title;
            textBox2.Text = Convert.ToString(it.Cost);
            textBox3.Text = Convert.ToString(it.DurationInSeconds);
            textBox4.Text = it.Description;
            textBox5.Text = Convert.ToString(it.Discount);
            textBox6.Text = Convert.ToString(it.MainImagePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Изменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                it.Title = textBox1.Text;
                it.Cost = Convert.ToDecimal(textBox2.Text);
                it.DurationInSeconds = Convert.ToInt32(textBox3.Text);
                it.Description = textBox4.Text;
                it.Discount = Convert.ToDecimal(textBox5.Text);
                it.MainImagePath = textBox6.Text;
                context.SubmitChanges();
                this.Close();
            }
        }
    }
}
