using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Oqituvchi_test
{
    public partial class Litsenziya : Form
    {
        public Litsenziya()
        {
            InitializeComponent();
        }
        
       SqlConnection sql=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True");

        private int k = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("1122334455667788")) {
                sql.Open();
                var command1 = new SqlCommand("insert into [Activate](litsenziya)values(@litsenziya)", sql);
                command1.Parameters.AddWithValue("@litsenziya", textBox1.Text);
                command1.ExecuteNonQuery();
                sql.Close();

                Admin admim = new Admin();
                admim.Show();
            }
            else
            {
                MessageBox.Show("Noto'g'ri aktivatsiya kodini kiritdingiz!!!\n\nIlimos qayta kiriting va aktivatsiya kodi to'g'riligiga etibor bering", "Ogohlantirish");
               textBox1.Text = null;
            }          
        }

        private void Litsenziya_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
