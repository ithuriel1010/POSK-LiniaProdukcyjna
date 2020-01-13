using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiniaProdukcyjnaApp
{
    public partial class Form2 : Form
    {
        String login;
        String haslo;
        String poprawnehaslo = "haslo";
        String poprawnylogin = "login";
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            haslo = textBox2.Text;

            if(login==poprawnylogin && haslo==poprawnehaslo)
            {
                Form1 m = new Form1();
                m.Show();
                this.Hide();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                label4.Text = "Niepoprawe hasło lub login";
            }
        }
    }
}
