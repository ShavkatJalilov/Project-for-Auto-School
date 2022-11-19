using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Oqituvchi_test
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            timer1.Start();
           
        }
         SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True");

        int k = 0;
        private void Loading_Load(object sender, EventArgs e)
        {
            sql.Open();
            var command = new SqlCommand($"select litsenziya from Activate", sql);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals("1122334455667788"))
                {
                    k++;
                }
            }
            sql.Close();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Bar1.Value += 2;
            Bar1.Text = Bar1.Value.ToString() + "%";
            if (Bar1.Value == 100)
            {
                if (k != 0)
                {
                    timer1.Enabled = false;
                    Admin form1 = new Admin();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    timer1.Enabled = false;
                    Litsenziya litsenziya = new Litsenziya();
                    litsenziya.Show();
                    this.Hide();
                }
            }
            try
            {
                panel2.Width += 3;
                if (panel2.Width >= 470)
                {
                    if (k != 0)
                    {
                        timer1.Stop();
                        Admin uz = new Admin();
                        uz.Show();
                        this.Hide();
                    }
                    else
                    {
                        timer1.Stop();
                        Litsenziya litsenziya = new Litsenziya();
                        litsenziya.Show();
                        this.Hide();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading ?");
            }
        }
     

        private void Bar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
