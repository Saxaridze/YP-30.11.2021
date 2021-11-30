using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Подай_на_16
{
    public partial class EditClient : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=YP;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        Client it;
        public EditClient(int id)
        {
            InitializeComponent();
            it = context.GetTable<Client>().FirstOrDefault(x => x.ID == id);
            comboBox1.DataSource = context.GetTable<Gender>().ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Code";
            textBox1.Text = it.FirstName;
            textBox2.Text = it.LastName;
            textBox3.Text = it.Patronymic;
            dateTimePicker1.Value = it.Birthday;
            dateTimePicker2.Value = it.RegistrationDate;
            textBox4.Text = it.Email;
            textBox5.Text = it.Phone;
            comboBox1.SelectedValue = it.GenderCode;
            textBox6.Text = it.PhotoPath;
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
                it.FirstName = textBox1.Text;
                it.LastName = textBox2.Text;
                it.Patronymic = textBox3.Text;
                it.Birthday = dateTimePicker1.Value;
                it.RegistrationDate = dateTimePicker2.Value;
                it.Email = textBox4.Text;
                it.Phone = textBox5.Text;
                it.GenderCode = Convert.ToString(comboBox1.SelectedValue);
                it.PhotoPath = textBox6.Text;
                context.SubmitChanges();
                this.Close();
            }
        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "yPDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.yPDataSet.Gender);

        }
    }
}
