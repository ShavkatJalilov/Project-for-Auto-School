using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oqituvchi_test.Talaba
{
    public partial class TestBoshlash : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True");
        public TestBoshlash()
        {
            InitializeComponent();
        }

     
        public int sav_soni()
        {
            int k = 0;
            sql.Open();

            var command = new SqlCommand($"select * from Savollar ", sql);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                k++;
            }
            reader.Close();
            sql.Close();
            return k;
        }
        public int var_soni()
        {
            int k = 0;
            sql.Open();

            var command = new SqlCommand($"select * from Variantlar ", sql);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                k++;
            }
            reader.Close();
            sql.Close();
            return k;
        }
    

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            if (guna2ComboBox1.SelectedIndex != -1)
            {
                    sql.Open();
                    var command = new SqlCommand($"insert into [TestTuri](nomi)values(@nomi)", sql);
                    command.Parameters.AddWithValue("@nomi", guna2ComboBox1.SelectedItem.ToString());
                    command.ExecuteNonQuery();
                    sql.Close();

                    this.Visible = false;
                    Talaba.testishlash testishlash = new Talaba.testishlash();
                    testishlash.Show();                
            }
            else
            {
                MessageBox.Show("Test turini tablang", "Ogohlantirish");
            }
        }

        private void TestBoshlash_Load(object sender, EventArgs e)
        {
            sql.Open();
            var cmd = new SqlCommand($"select  nomi from Turi", sql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                guna2ComboBox1.Items.Add(reader.GetString(0));
            }
            sql.Close();

          }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Admin admin = new Admin();
            admin.Show();                
        }
    }
}
