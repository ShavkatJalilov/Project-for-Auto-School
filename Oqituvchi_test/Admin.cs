using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Oqituvchi_test
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True");

        private void btnChiqish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       

        private void Admin_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            labelNotugri.Visible = false;

        }      

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                panel1.Visible = true;
                btnTalabaKirish.Visible = false;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                panel1.Visible = false;
                btnTalabaKirish.Visible = true;
            }
        }

        private void btnOqituvchiKirish_Click_1(object sender, EventArgs e)
        {
            sql.Open();
            int k = 0, j=0;

            var sqlcommand = new SqlCommand("select Logins,Parols from Login", sql);
            var reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals(txtFoydalanuvchi.Text) && reader.GetString(1).Equals(txtParol.Text))
                {
                    k++;
                    break;
                }               
            }

            if (k != 0)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login yoki parol xato!!");
            }
            sql.Close();
        }
        private void btnTalabaKirish_Click_1(object sender, EventArgs e)
        {              
                Talaba.TestBoshlash talaba = new Talaba.TestBoshlash();
                talaba.Show();
                this.Close();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
