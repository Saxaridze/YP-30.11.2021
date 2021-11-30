using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Подай_на_16
{
    public partial class Enter : Form
    {
        public Enter()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "Danil";
            string password = "1234";
            if (textBox1.Text==login && textBox2.Text == password)
            {
                MessageBox.Show("Добро пожаловать "+login, "Собщение");
                Podai_na_16 F1 = new Podai_na_16();
                this.Hide();
                F1.Show();
            }
            else
            {
                MessageBox.Show("Не верный пароль");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           DialogResult result = MessageBox.Show("Вы уверены продолжить, как Гость?","Сообщение",MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Guest F2 = new Guest();
                this.Hide();
                F2.Show();
            }
        }
    }
}
